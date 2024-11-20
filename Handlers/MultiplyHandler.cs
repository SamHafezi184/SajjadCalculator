using MediatR;
using SajjadCalculator.Requests;
using SajjadCalculator.Utils;

namespace SajjadCalculator.Handlers
{
    public class MultiplyHandler :IRequestHandler<MultiplyRequest , double>
    {
        public Task<double> Handle(MultiplyRequest request, CancellationToken cancellationToken)
        {
            double result = request.Num1 * request.Num2;
            ArithmeticValidator.ValidateResult(result);
            return Task.FromResult(result);
        }
    }
}
