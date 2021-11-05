using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_and_Data_Structures.Microsoft
{
    public class MaximumLengthOfConcatinatedString
    {
        public int MaxLength(IList<string> arr)
        {
            // Pre-process arr with an optimizing helper
            // which converts each word to its character bitset
            // and then uses a set to prevent duplicate results
            HashSet<int> optSet = new HashSet<int>();
            foreach (string word in arr)
                wordToBitSet(optSet, word);

            // Convert the set back to an array for iteration
            // then start up the recursive helper
            int[] optArr = new int[optSet.Count];
            int i = 0;
            foreach (int num in optSet)
                optArr[i++] = num;
            return dfs(optArr, 0, 0);
        }

        private int dfs(int[] optArr, int pos, int res)
        {
            // Separate the parts of the bitset res
            int oldChars = res & ((1 << 26) - 1);
            int oldLen = res >> 26;
            int best = oldLen;

            // Iterate through the remaining results
            for (int i = pos; i < optArr.Length; i++)
            {
                int newChars = optArr[i] & ((1 << 26) - 1);
                int newLen = optArr[i] >> 26;

                // If the two bitsets overlap, skip to the next result
                if ((newChars & oldChars) != 0)
                    continue;

                // Combine the two results and trigger the next recursion
                int newRes = newChars + oldChars + (newLen + oldLen << 26);
                best = Math.Max(best, dfs(optArr, i + 1, newRes));
            }
            return best;
        }

        private void wordToBitSet(HashSet<int> optSet, string word)
        {
            // Initialize an empty int to use as a character bitset
            int charBitSet = 0;
            foreach (char c in word)
            {
                // If the bitset contains a duplicate character
                // then discard this word with an early return
                // otherwise add the character to the bitset
                int mask = 1 << c - 'a';
                if ((charBitSet & mask) > 0)
                    return;
                charBitSet += mask;
            }

            // Store the length of the word in the unused space
            // then add the completed bitset to our optimized set
            optSet.Add(charBitSet + (word.Length << 26));
        }
    }
}
