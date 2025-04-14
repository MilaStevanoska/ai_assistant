using CareerCompass.Services.Constants;
using CareerCompass.Services.Models.Auth;
using FluentValidation;

namespace CareerCompass.Services.Validation
{
    public class RegisterValidator
        : AbstractValidator<Register>, IValidator<Register>
    {
        public RegisterValidator()
        {
            RuleFor(user => user.FirstName)
                .NotEmpty().WithMessage("First name is required.");

            RuleFor(user => user.LastName)
                .NotEmpty().WithMessage("Last name is required.");

            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Email is required.")
                .Matches(Regex.Email).WithMessage("A valid email address is required.");

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("Password is required.")
                .Matches(Regex.Password).WithMessage("A valid strong password is required.");
        }
    }
}
