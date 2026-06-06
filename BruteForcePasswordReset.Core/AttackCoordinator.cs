using System;

namespace BruteForcePasswordReset.Core
{
    public class AttackCoordinator
    {
        private readonly PasswordManager _pm = new PasswordManager();
        private readonly SingleThreadBruteForcer _single = new SingleThreadBruteForcer();
        private readonly MultiThreadBruteForcer _multi = new MultiThreadBruteForcer();

        public (string Password, string Hash) GeneratePasswordAndHash()
        {
            var pwd = _pm.GenerateRandomPassword();
            var hash = _pm.ComputeHash(pwd);
            return (pwd, hash);
        }

        public BruteForceResult RunSingleThread(string targetHash)
        {
            return _single.Run(targetHash);
        }

        public BruteForceResult RunMultiThread(string targetHash, int threads = 4)
        {
            return _multi.Run(targetHash, threads);
        }
    }
}
