using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace BruteForcePasswordReset.Core
{
    public class MultiThreadBruteForcer
    {
        private readonly BruteForceGenerator _generator = new BruteForceGenerator();
        private readonly HashValidator _validator = new HashValidator();

        public BruteForceResult Run(string targetHash, int threadCount, CancellationToken token, Action<long> progress)
        {
            var sw = Stopwatch.StartNew();
            long attempts = 0;
            string foundPassword = null;

            var tasks = new List<Task>();

            for (int t = 0; t < threadCount; t++)
            {
                tasks.Add(Task.Run(() =>
                {
                    for (int length = 1; length <= AppConfig.MaxBruteForceLength; length++)
                    {
                        foreach (var candidate in _generator.Generate(length))
                        {
                            if (token.IsCancellationRequested)
                                return;

                            long a = Interlocked.Increment(ref attempts);
                            if (a % 100 == 0)
                                progress(a);

                            if (_validator.IsMatch(candidate, targetHash))
                            {
                                foundPassword = candidate;
                                return;
                            }
                        }
                    }
                }, token));
            }

            Task.WaitAll(tasks.ToArray());
            sw.Stop();

            return new BruteForceResult
            {
                Found = foundPassword != null,
                Password = foundPassword,
                Attempts = attempts,
                Elapsed = sw.Elapsed
            };
        }

    }
}
