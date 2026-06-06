namespace BruteForcePasswordReset.Core
{
    public class BruteForceResult
    {
        // The brute forcers assign bool → so we store it as bool
        public bool Found { get; set; }

        // The brute forcers assign a string password
        public string Password { get; set; }

        // The brute forcers assign a long → so we store long
        public long Attempts { get; set; }

        // The brute forcers assign a TimeSpan → so we store TimeSpan
        public TimeSpan Elapsed { get; set; }
    }
}
