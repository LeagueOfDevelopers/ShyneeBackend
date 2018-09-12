using CryptoHelper;

namespace ShyneeBackend.Helpers
{
    public static class Hasher
    {
        public static string HashPassword(string password)
        {
            return Crypto.HashPassword(password);
        }

        public static bool VerifyPassword(string hash, string password)
        {
            return Crypto.VerifyHashedPassword(hash, password);
        }
    }
}
