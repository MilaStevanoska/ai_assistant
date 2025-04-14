namespace CareerCompass.Services.Models.Auth
{
    public class Register
    {
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }
    }
}
