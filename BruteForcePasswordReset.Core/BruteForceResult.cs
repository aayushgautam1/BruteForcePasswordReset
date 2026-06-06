using System;

namespace BruteForcePasswordReset.Core
{
    public class BruteForceResult
    {
        public bool Found { get; set; }
        public string? Password { get; set; } = null;
        public TimeSpan Elapsed { get; set; }
        public long Attempts { get; set; }
    }
}
