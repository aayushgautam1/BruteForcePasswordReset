using System.Diagnostics;
using System.Threading;

namespace BruteForcePasswordReset.Core
{
    public class SingleThreadBruteForcer
    {
        private readonly BruteForceGenerator _generator = new BruteForceGenerator();
        private readonly HashValidator _validator = new HashValidator();

        public BruteForceResult Run(string targetHash, CancellationToken token, Action<long> progress)
        {
            var sw = Stopwatch.StartNew();
            long attempts = 0;

            for (int length = 1; length <= AppConfig.MaxBruteForceLength; length++)
            {
                foreach (var candidate in _generator.Generate(length))
                {
                    if (token.IsCancellationRequested)
                    {
                        sw.Stop();
                        return new BruteForceResult
                        {
                            Found = false,
                            Password = null,
                            Attempts = attempts,
                            Elapsed = sw.Elapsed
                        };
                    }

                    attempts++;
                    if (attempts % 100 == 0)
                        progress(attempts);

                    if (_validator.IsMatch(candidate, targetHash))
                    {
                        sw.Stop();
                        return new BruteForceResult
                        {
                            Found = true,
                            Password = candidate,
                            Attempts = attempts,
                            Elapsed = sw.Elapsed
                        };
                    }
                }
            }

            sw.Stop();
            return new BruteForceResult
            {
                Found = false,
                Password = null,
                Attempts = attempts,
                Elapsed = sw.Elapsed
            };
        }
    }
}
