namespace CareerCompass.Services.Constants
{
    public class Regex
    {
        public const string Email = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        public const string Password = @"^(?=.*[A-Z])(?=.*[^a-zA-Z0-9]).{8,}$";
    }
}
