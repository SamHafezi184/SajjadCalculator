using MediatR;
using SajjadCalculator.Requests;
using SajjadCalculator.Utils;

namespace SajjadCalculator.Handlers
{
    public class SubtractHandler : IRequestHandler<SubtractRequest, double>
    {
        public Task<double> Handle(SubtractRequest request, CancellationToken cancellationToken)
        {
            double result = request.Num1 - request.Num2;

            // Check for overflow or invalid result
            if (double.IsInfinity(result) || double.IsNaN(result))
            {
                throw new ArithmeticException("The result exceeds the maximum allowed value for a double.");
            }
            ArithmeticValidator.ValidateResult(result);
            return Task.FromResult(result);
        }
    }
}
