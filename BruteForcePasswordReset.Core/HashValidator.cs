namespace BruteForcePasswordReset.Core
{
    public class HashValidator
    {
        private readonly PasswordManager _pm = new PasswordManager();

        // Returns true if candidate hashed equals targetHash
        public bool IsMatch(string candidate, string targetHash)
        {
            var h = _pm.ComputeHash(candidate);
            return string.Equals(h, targetHash, System.StringComparison.OrdinalIgnoreCase);
        }
    }
}
