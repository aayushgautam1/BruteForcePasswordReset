using System;
using System.Collections.Generic;

namespace BruteForcePasswordReset.Core
{
    public class PerformanceLogger
    {
        private readonly List<string> _entries = new List<string>();

        public void Log(string message)
        {
            string entry = $"{DateTime.Now:HH:mm:ss} - {message}";
            _entries.Add(entry);
        }

        public IEnumerable<string> GetEntries()
        {
            return _entries;
        }

        public void Clear()
        {
            _entries.Clear();
        }
    }
}
