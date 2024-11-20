using MediatR;
using SajjadCalculator.Requests;
using SajjadCalculator.Utils;

namespace SajjadCalculator.Handlers
{
    public class DivideHandler : IRequestHandler<DivideRequest, double>
    {
        public Task<double> Handle(DivideRequest request, CancellationToken cancellationToken)
        {
            if (request.Num2 == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            double result = request.Num1 / request.Num2;
            ArithmeticValidator.ValidateResult(result);
            return Task.FromResult(result);
        }
    }
}
