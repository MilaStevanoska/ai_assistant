using CareerCompass.Services.Abstractions.Services;
using CareerCompass.Services.Helpers;
using System.Security.Cryptography;
using System.Text;

namespace CareerCompass.Services.Services
{
    public class CryptographyService
        : ICryptographyService
    {
        private static readonly int ITERATIONS = 100000;
        private static readonly int HASH_SIZE = 24;
        private static readonly int SALT_SIZE = 24;

        private static Encoding Encoding => Encoding.UTF8;

        public byte[] EncryptHash(byte[] data, byte[] salt)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(data, salt, ITERATIONS, HashAlgorithmName.SHA256))
            {
                return pbkdf2.GetBytes(HASH_SIZE);
            }
        }

        public string EncryptHash(string clearText, byte[] salt)
        {
            var hash = EncryptHash(Encoding.GetBytes(clearText), salt);
            return Convert.ToBase64String(hash);
        }

        public byte[] GenerateRandomSalt()
        {
            return SaltHelper.GenerateRandomSaltBytes(SALT_SIZE);
        }

        public bool VerifyHash(string clearText, string hash, string salt)
        {
            var testHash = EncryptHash(Encoding.GetBytes(clearText), Convert.FromBase64String(salt));
            return ComparatorHelper.ExplicitEquals(Convert.FromBase64String(hash), testHash);
        }
    }
}
