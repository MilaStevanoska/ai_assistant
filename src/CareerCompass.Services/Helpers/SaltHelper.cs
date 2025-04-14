namespace CareerCompass.Services.Helpers
{
    using System.Security.Cryptography;

    internal static class SaltHelper
    {
        public static byte[] GenerateRandomSaltBytes(int size = 24)
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                var bytes = new byte[size];
                rng.GetBytes(bytes);
                return bytes;
            }
        }
    }
}
