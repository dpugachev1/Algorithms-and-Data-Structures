using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_and_Data_Structures.Google
{
    public class RateLimiter_SlidingWindow
    {

        private HashSet<string> messages;
        private Queue<Tuple<string, int>> messagesQueue;
        private const int TIMEOUT = 10;

        public RateLimiter_SlidingWindow()
        {
            messages = new HashSet<string>();
            messagesQueue = new Queue<Tuple<string, int>>();
        }

        public bool ShouldPrintMessage(int timestamp, string message)
        {

            while (messagesQueue.Count > 0)
            {
                if (timestamp - messagesQueue.Peek().Item2 >= TIMEOUT)
                {
                    var msg = messagesQueue.Dequeue();
                    messages.Remove(msg.Item1);
                }
                else
                    break;
            }
            if (!messages.Contains(message))
            {
                messages.Add(message);
                messagesQueue.Enqueue(new Tuple<string, int>(message, timestamp));
                return true;
            }
            return false;
        }
    }
}
