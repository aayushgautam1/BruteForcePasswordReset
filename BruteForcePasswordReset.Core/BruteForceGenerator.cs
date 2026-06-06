using System;
using System.Collections.Generic;
using System.Text;

namespace BruteForcePasswordReset.Core
{
    public class BruteForceGenerator
    {
        private readonly string _charset = AppConfig.Charset;

        // Generate all combinations of given length. length must be >= 1.
        public IEnumerable<string> Generate(int length)
        {
            if (length < 1) yield break;

            int k = _charset.Length;
            var indices = new int[length];

            while (true)
            {
                // Build string from indices
                var sb = new StringBuilder(length);
                for (int i = 0; i < length; i++)
                    sb.Append(_charset[indices[i]]);
                yield return sb.ToString();

                // Increment like an odometer
                int pos = length - 1;
                while (pos >= 0)
                {
                    indices[pos]++;
                    if (indices[pos] < k) break;
                    indices[pos] = 0;
                    pos--;
                }

                if (pos < 0)
                    yield break; // Finished all combinations
            }
        }
    }
}
