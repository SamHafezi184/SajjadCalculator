using FluentValidation;
using SajjadCalculator.Requests;

namespace SajjadCalculator.Validators
{
    public class SubtractRequestValidator : AbstractValidator<SubtractRequest>
    {
        public SubtractRequestValidator()
        {
            RuleFor(x => x.Num1).NotNull().WithMessage("Num1 cannot be null.")
                                 .Must(IsValidNumber).WithMessage("Num1 must be a valid number.");

            RuleFor(x => x.Num2).NotNull().WithMessage("Num2 cannot be null.")
                                 .Must(IsValidNumber).WithMessage("Num2 must be a valid number.");
        }

        private bool IsValidNumber(double value)
        {
            return !double.IsNaN(value) && !double.IsInfinity(value);
        }
    }

}
