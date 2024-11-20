using MediatR;
namespace SajjadCalculator.Requests
{
    public class MultiplyRequest : IRequest<double>
    {
        public double Num1 { get; set; }
        public double Num2 { get; set; }

    }
}
