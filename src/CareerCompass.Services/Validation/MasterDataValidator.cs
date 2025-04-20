using CareerCompass.Services.Models.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCompass.Services.Validation
{
    public class MasterDataValidator 
        : AbstractValidator<MasterData>
    {
        public MasterDataValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.");

            RuleFor(x => x.AreaOfInterests)
                .NotNull()
                .Must(x => x.Count >= 2)
                .WithMessage("At least 2 areas of interest are required.")
                .Must(x => x.Distinct().Count() == x.Count)
                .WithMessage("Duplicate areas of interest are not allowed.");

            RuleFor(x => x.Skills)
                .NotNull()
                .Must(x => x.Count <= 3)
                .WithMessage("You can have at most 3 skills.")
                .Must(x => x.Distinct().Count() == x.Count)
                .WithMessage("Duplicate skills are not allowed.");
        }
    }
}
