using CareerCompass.Services.Models.User;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;

namespace CareerCompass.Services.Validation
{
    public class MasterDataValidator : AbstractValidator<MasterData>
    {
        public MasterDataValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.");

            RuleFor(x => x.SchoolYears)
                .NotNull().WithMessage("School years are required.")
                .Must(schoolYears => schoolYears?.Count is >= 3 and <= 4)
                .WithMessage("You must have between 3 and 4 school years.")
                .Must(HaveNoDuplicateSubjects)
                .WithMessage("Each school year must have unique subjects.")
                .Must(HaveNoDuplicateYears)
                .WithMessage("Duplicate school years are not allowed.");

            RuleForEach(x => x.SchoolYears)
                .ChildRules(schoolYear =>
                {
                    schoolYear.RuleForEach(y => y.Grades)
                        .ChildRules(subject =>
                        {
                            subject.RuleFor(s => s.Value)
                                .InclusiveBetween(1, 5)
                                .WithMessage("Grade must be between 1 and 5.");
                        });
                });

            RuleFor(x => x.AreasOfInterest)
                .NotNull().WithMessage("Areas of interest are required.")
                .Must(areas => areas?.Count == 2)
                .WithMessage("Exactly 2 areas of interest are required.")
                .Must(areas => areas?.Distinct().Count() == areas?.Count)
                .WithMessage("Duplicate areas of interest are not allowed.");

            RuleFor(x => x.Skills)
                .NotNull().WithMessage("Skills are required.")
                .Must(skills => skills?.Count <= 3)
                .WithMessage("You can have at most 3 skills.")
                .Must(skills => skills?.Distinct().Count() == skills?.Count)
                .WithMessage("Duplicate skills are not allowed.");
        }

        private bool HaveNoDuplicateSubjects(List<SchoolYear> schoolYears)
        {
            if (schoolYears == null) return true;

            foreach (var year in schoolYears)
            {
                var subjects = year?.Subjects;
                if (subjects == null) continue;

                var subjectNames = subjects.Select(s => s.Name);
                if (subjectNames.Distinct().Count() != subjectNames.Count())
                    return false;
            }
            return true;
        }

        private bool HaveNoDuplicateYears(List<SchoolYear> schoolYears)
        {
            if (schoolYears == null) return true;

            var yearNumbers = schoolYears.Select(y => y.Year);
            return yearNumbers.Distinct().Count() == yearNumbers.Count();
        }
    }
}
