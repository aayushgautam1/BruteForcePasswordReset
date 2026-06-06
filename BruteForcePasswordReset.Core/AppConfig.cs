using System;

namespace BruteForcePasswordReset.Core
{
    public static class AppConfig
    {
        public const string Salt = "S@ltForAssignment2026";

        public const string Charset =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public const int MaxBruteForceLength = 6;
    }
}
