using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_and_Data_Structures.LeetCode
{
    public static class CountPrimes
    {
        /// <summary>
        /// https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int Primes(int n)
        {

            int cc = 0;

            bool[] prime = new bool[n + 1];

            for (int p = 0; p <= n; p++)
                prime[p] = true;

            for (int p = 2; p * p <= n; p++)
            {
                if (prime[p] == true)
                {
                    for (int i = p * 2; i <= n; i += p)
                        prime[i] = false;
                }
            }

            for (int i = 2; i < n; i++)
            {
                if (prime[i] == true)
                    cc++;
            }
            //prime
            return cc;

        }

    }
}
