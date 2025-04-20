using CareerCompass.DataContext.Enums;
using System.ComponentModel.DataAnnotations;

namespace CareerCompass.DataContext.Entities
{
    public class User
    {
        public User() { }

        public User(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Salt { get; set; } = string.Empty;

        public string FieldOfStudy { get; set; } = string.Empty;

        public CareerGoal Goal { get; set; }

        public virtual List<Skills> Skills { get; private set; } = new List<Skills>();

        public virtual List<AreaOfInterest> AreasOfInterest { get; private set; } = new List<AreaOfInterest>();

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public virtual IEnumerable<SchoolYear> SchoolYears { get; private set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        public void AddSkill(Skills skill)
        {
            if (!Skills.Contains(skill))
            {
                Skills.Add(skill);
            }
        }

        public void RemoveSkill(Skills skill)
        {
            Skills.Remove(skill);
        }

        public void AddAreaOfInterest(AreaOfInterest area)
        {
            if (!AreasOfInterest.Contains(area))
            {
                AreasOfInterest.Add(area);
            }
        }

        public void RemoveAreaOfInterest(AreaOfInterest area)
        {
            AreasOfInterest.Remove(area);
        }

        public void AddSchoolYear(SchoolYear schoolYear)
        {
            if (SchoolYears.Any(x => x.Year == schoolYear.Year))
            {
                return;
            }

            ((ICollection<SchoolYear>)SchoolYears).Add(schoolYear);
        }

        public void RemoveSchoolYear(SchoolYear schoolYear)
        {
            if (!SchoolYears.Contains(schoolYear))
            {
                return;
            }

            ((ICollection<SchoolYear>)SchoolYears).Remove(schoolYear);
        }
    }
}
