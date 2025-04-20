using CareerCompass.DataContext.Enums;
using CareerCompass.Services.Enums;
using CareerCompass.Services.Extensions;
using CareerCompass.Services.Models.Enums;
using Entity = CareerCompass.DataContext.Entities;

namespace CareerCompass.Services.Models.User
{
    public static class Profiles
    {
        public static UserInfo ToModel(this Entity.User entity)
        {
            var model = new UserInfo
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email
            };

            return model;
        }

        public static MasterData ToMasterData(this Entity.User entity)
        {
            var model = new MasterData
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                FieldOfStudy = entity.FieldOfStudy,
                CareerGoal = new EnumModel(entity.Goal.ToString(), (int)entity.Goal, entity.Goal.GetDescription()),
                Skills = entity.Skills.Select(x => new EnumModel(x.ToString(), (int)x, x.GetDescription())).ToList(),
                AreasOfInterest = entity.AreasOfInterest.Select(x => new EnumModel(x.ToString(), (int)x, x.GetDescription())).ToList()
            };

            foreach (var year in entity.SchoolYears)
            {
                var yearModel = new SchoolYear { Year = year.Year };

                foreach (var subjectEnum in Enum.GetValues(typeof(SubjectType)))
                {
                    var subjectName = subjectEnum.ToString();

                    var property = year.Grades.GetType().GetProperty(subjectName!);

                    if (property == null)
                    {
                        continue;
                    }

                    var propertyValue = property.GetValue(year.Grades) as short?;

                    if (!propertyValue.HasValue)
                    {
                        continue;
                    }

                    var enumVal = (SubjectType)subjectEnum;

                    yearModel.Subjects.Add(new EnumModel(enumVal.ToString(), (int)enumVal, enumVal.GetDescription()));
                    yearModel.Grades.Add(subjectName!, propertyValue.Value);
                }

                model.SchoolYears.Add(yearModel);
            }

            return model;
        }
    }
}
