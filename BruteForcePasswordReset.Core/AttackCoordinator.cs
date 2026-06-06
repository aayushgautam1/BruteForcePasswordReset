using System.Threading;

namespace BruteForcePasswordReset.Core
{
    public class AttackCoordinator
    {
        private readonly PasswordManager _pm = new PasswordManager();
        private readonly SingleThreadBruteForcer _single = new SingleThreadBruteForcer();
        private readonly MultiThreadBruteForcer _multi = new MultiThreadBruteForcer();
        public long GetTotalCombinations()
        {
            return new BruteForceGenerator().CountTotalCombinations();
        }

        public (string Password, string Hash) GeneratePasswordAndHash()
        {
            var pwd = _pm.GenerateRandomPassword();
            var hash = _pm.ComputeHash(pwd);
            return (pwd, hash);
        }

        public BruteForceResult RunSingleThread(string hash, CancellationToken token, Action<long> progress)
        {
            return _single.Run(hash, token, progress);
        }

        public BruteForceResult RunMultiThread(string hash, int threads, CancellationToken token, Action<long> progress)
        {
            return _multi.Run(hash, threads, token, progress);
        }
    }
}
