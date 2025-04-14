using Entity = CareerCompass.DataContext.Entities;

namespace CareerCompass.Services.Models.Auth
{
    public static class Profiles
    {
        public static Entity.User ToUser(this Register model, string encryptedPassword, string salt)
        {
            var user = new Entity.User
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Password = encryptedPassword,
                Salt = salt
            };

            return user;
        }
    }
}
