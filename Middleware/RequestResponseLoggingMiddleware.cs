using Serilog;

namespace SajjadCalculator.Middleware
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestResponseLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Log request
            context.Request.EnableBuffering();
            var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
            context.Request.Body.Position = 0; 
            // Reset the stream position for further processing
            Log.Information("Request {Method} {Path} {Body}", context.Request.Method, context.Request.Path, requestBody);

            // Capture response
            var originalBodyStream = context.Response.Body;
            using var responseBodyStream = new MemoryStream();
            context.Response.Body = responseBodyStream;

            await _next(context); // Call the next middleware

            // Log response
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var responseBody = await new StreamReader(context.Response.Body).ReadToEndAsync();
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            Log.Information("Response {StatusCode} {Body}", context.Response.StatusCode, responseBody);

            // Copy the response back to the original stream
            await responseBodyStream.CopyToAsync(originalBodyStream);
        }
    }
}
