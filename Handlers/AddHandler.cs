using MediatR;
using SajjadCalculator.Requests;
using SajjadCalculator.Utils;
namespace SajjadCalculator.Handlers
{
    public class AddHandler : IRequestHandler<AddRequest, double>
    {
        public Task<double> Handle(AddRequest request, CancellationToken cancellationToken)
        {
            double result = request.Num1 + request.Num2;
            ArithmeticValidator.ValidateResult(result);
            return Task.FromResult(result);
        }
    }
}
