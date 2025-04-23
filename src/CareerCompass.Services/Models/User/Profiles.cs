using CareerCompass.DataContext.Entities;
using CareerCompass.DataContext.Enums;
using CareerCompass.Services.Enums;
using CareerCompass.Services.Extensions;
using CareerCompass.Services.Models.Enums;
using System.Linq;
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

        static void ApplyGradesToSchoolYear(Entity.SchoolYear entityYear, SchoolYear modelYear)
        {
            foreach (var subject in modelYear.Subjects)
            {
                if (modelYear.Grades.TryGetValue(subject.Name, out var grade))
                {
                    var property = entityYear.Grades.GetType().GetProperty(subject.Name);
                    if (property == null)
                        continue;

                    property.SetValue(entityYear.Grades, (short)grade);
                }
            }
        }

        public static Entity.User FromUpdateModel(this Entity.User entity, MasterData model)
        {
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.FieldOfStudy = model.FieldOfStudy ?? string.Empty;
            entity.Goal = (CareerGoal)model.CareerGoal.Value;

            var modelSkills = model.Skills.Select(x => (Skills)x.Value).ToList();
            var toAddSkills = modelSkills.Except(entity.Skills).ToList();
            var toRemoveSkills = entity.Skills.Except(modelSkills).ToList();

            foreach (var skill in toAddSkills)
            {
                entity.AddSkill(skill);
            }

            foreach (var skill in toRemoveSkills)
            {
                entity.RemoveSkill(skill);
            }

            var modelInterests = model.AreasOfInterest.Select(x => (AreaOfInterest)x.Value).ToList();
            var toAddInterests = modelInterests.Except(entity.AreasOfInterest).ToList();
            var toRemoveInterests = entity.AreasOfInterest.Except(modelInterests).ToList();

            foreach (var area in toAddInterests)
            {
                entity.AddAreaOfInterest(area);
            }

            foreach (var area in toRemoveInterests)
            {
                entity.RemoveAreaOfInterest(area);
            }

            var newSchoolYears = model.SchoolYears.Where(x => !entity.SchoolYears.Any(y => y.Year == x.Year));
            var deletedSchoolYears = entity.SchoolYears.Where(x => !model.SchoolYears.Any(y => y.Year == x.Year)).ToList();
            var updatedSchoolYears = entity.SchoolYears.Where(x => model.SchoolYears.Any(y => y.Year == x.Year)).ToList();

            foreach (var modelYear in newSchoolYears)
            {
                var newSchoolYear = new Entity.SchoolYear
                {
                    Id = Guid.NewGuid(),
                    Year = modelYear.Year
                };

                ApplyGradesToSchoolYear(newSchoolYear, modelYear);
                entity.AddSchoolYear(newSchoolYear);
            }

            foreach (var existingYear in updatedSchoolYears)
            {
                var modelYear = model.SchoolYears.FirstOrDefault(x => x.Year == existingYear.Year);
                if (modelYear == null)
                    continue;

                ApplyGradesToSchoolYear(existingYear, modelYear);
            }

            foreach (var modelYear in deletedSchoolYears)
            {
                entity.RemoveSchoolYear(modelYear);
            }

            return entity; 
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
