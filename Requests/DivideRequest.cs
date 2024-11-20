using MediatR;

namespace SajjadCalculator.Requests
{
    public class DivideRequest : IRequest<double>
    {
        public double Num1 { get; set; }
        public double Num2 { get; set; }

    }
}
