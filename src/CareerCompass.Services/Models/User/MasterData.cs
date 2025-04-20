using CareerCompass.DataContext.Enums;

namespace CareerCompass.Services.Models.User
{
    public class MasterData
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string? FieldOfStudy { get; set; }

        public List<Skills> Skills { get; set; } = new List<Skills>();

        public List<AreaOfInterest> AreaOfInterests { get; set; } = new List<AreaOfInterest>();

        public CareerGoal CareerGoal { get; set; }
    }
}
