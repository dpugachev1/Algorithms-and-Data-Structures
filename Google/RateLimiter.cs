using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_and_Data_Structures.Google
{
    public class RateLimiter
    {

        private Dictionary<string, int> dictLogger;
        private const int TIMEOUT = 10;

        public RateLimiter()
        {
            dictLogger = new Dictionary<string, int>();
        }

        public bool ShouldPrintMessage(int timestamp, string message)
        {

            if (!dictLogger.ContainsKey(message))
            {
                dictLogger.Add(message, timestamp);
                return true;
            }

            bool result = Math.Abs(timestamp - dictLogger[message]) >= TIMEOUT;
            if (result)
                dictLogger[message] = timestamp;
            return result;
        }
    }
}
