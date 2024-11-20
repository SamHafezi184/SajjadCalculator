using System.Net;
using System.Text.Json;

namespace SajjadCalculator.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (DivideByZeroException ex)
            {
                // Handle Division by Zero exception
                await HandleExceptionAsync(context, ex, HttpStatusCode.BadRequest, "Division by zero is not allowed.");
            }
            catch (ArithmeticException ex)
            {
                await HandleExceptionAsync(context, ex, HttpStatusCode.BadRequest, "Arithmetic overflow: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Handle other exceptions (optional)
                await HandleExceptionAsync(context, ex, HttpStatusCode.InternalServerError, "An unexpected error occurred.");
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception, HttpStatusCode statusCode, string message)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var errorResponse = new
            {
                StatusCode = context.Response.StatusCode,
                Message = message
            };

            var errorJson = JsonSerializer.Serialize(errorResponse);
            return context.Response.WriteAsync(errorJson);
        }
    }
}
