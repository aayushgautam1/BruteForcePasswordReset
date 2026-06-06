using System;
using System.Security.Cryptography;
using System.Text;

namespace BruteForcePasswordReset.Core
{
    public class PasswordManager
    {
        private readonly Random _rnd = new Random();

        // Generate random password with length randomly chosen from [4,6) => 4 or 5
        public string GenerateRandomPassword()
        {
            int length = _rnd.Next(4, 6); // returns 4 or 5
            var sb = new StringBuilder(length);
            var charset = AppConfig.Charset;
            for (int i = 0; i < length; i++)
            {
                int idx = _rnd.Next(charset.Length);
                sb.Append(charset[idx]);
            }
            return sb.ToString();
        }

        // Compute SHA256 hash of (password + salt). Returns hex string.
        public string ComputeHash(string password)
        {
            using (var sha = SHA256.Create())
            {
                var input = Encoding.UTF8.GetBytes(password + AppConfig.Salt);
                var hash = sha.ComputeHash(input);
                var sb = new StringBuilder(hash.Length * 2);
                foreach (var b in hash)
                    sb.AppendFormat("{0:x2}", b);
                return sb.ToString();
            }
        }
    }
}
