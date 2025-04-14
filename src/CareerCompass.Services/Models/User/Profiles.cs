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
    }
}
