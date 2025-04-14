using CareerCompass.Services.Constants;
using CareerCompass.Services.Models.Auth;
using FluentValidation;

namespace CareerCompass.Services.Validation
{
    public class LoginValidator
        : AbstractValidator<Login>, IValidator<Login>
    {
        public LoginValidator()
        {
            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Email is required.")
                .Matches(Regex.Email).WithMessage("A valid email address is required.");

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("Password is required.")
                .Matches(Regex.Password).WithMessage("A valid strong password is required.");
        }
    }
}
