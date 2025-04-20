using CareerCompass.Services.Models.Enums;
using EntityEnum = CareerCompass.DataContext.Enums;

namespace CareerCompass.Services.Models.User
{
    public class SchoolYear
    {
        public EntityEnum.SchoolYear Year { get; set; }

        public List<EnumModel> Subjects { get; set; } = new List<EnumModel>();

        public Dictionary<string, int> Grades { get; set; } = new Dictionary<string, int>();
    }
}
