using CareerCompass.DataContext.Enums;
using CareerCompass.Services.Models.Enums;

namespace CareerCompass.Services.Models.User
{
    public class MasterData
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string? FieldOfStudy { get; set; }

        public List<EnumModel> Skills { get; set; } = new List<EnumModel>();

        public List<EnumModel> AreasOfInterest { get; set; } = new List<EnumModel>();

        public EnumModel CareerGoal { get; set; }

        public List<SchoolYear> SchoolYears { get; set; } = new List<SchoolYear>();
    }
}
