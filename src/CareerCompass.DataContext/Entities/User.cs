using CareerCompass.DataContext.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCompass.DataContext.Entities
{
    public class User
    {
        private ICollection<Skills> skills = [];
        private ICollection<AreaOfInterest> areasOfInterest = [];

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

        public virtual IEnumerable<Skills> Skills { get => skills; }

        public virtual IEnumerable<AreaOfInterest> AreasOfInterest { get => areasOfInterest; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public virtual IEnumerable<SchoolYear> SchoolYears { get; private set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        public void AddSkill(Skills skill)
        {
            if (!skills.Contains(skill))
            {
                skills.Add(skill);
            }
        }

        public void RemoveSkill(Skills skill)
        {
            skills.Remove(skill);
        }

        public void AddAreaOfInterest(AreaOfInterest area)
        {
            if (!areasOfInterest.Contains(area))
            {
                areasOfInterest.Add(area);
            }
        }

        public void RemoveAreaOfInterest(AreaOfInterest area)
        {
            areasOfInterest.Remove(area);
        }
    }
}
