namespace CareerCompass.Services.Abstractions.Services
{
    public interface ICryptographyService
    {
        bool VerifyHash(string clearText, string hash, string salt);

        string EncryptHash(string clearText, byte[] salt);

        byte[] EncryptHash(byte[] data, byte[] salt);

        byte[] GenerateRandomSalt();
    }
}
