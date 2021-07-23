using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_and_Data_Structures.LeetCode
{
    /// <summary>
    /// https://leetcode.com/problems/longest-substring-without-repeating-characters/submissions/
    /// </summary>
    public static class LongestUniqueSubstring
    {
        public static int LengthOfLongestSubstring(string s)
        {
            HashSet<char> substr = new HashSet<char>();
            int maxLength = 0;
            int j = 0;
            for (int i = 0; i <= s.Length - 1; i++)
            {
                if (!substr.Contains(s[i]))
                {
                    substr.Add(s[i]);
                }
                else
                {
                    maxLength = Math.Max(maxLength, substr.Count);
                    do
                    {
                        substr.Remove(s[j]);
                        j++;
                    }
                    while (s[j - 1] != s[i]);
                    substr.Add(s[i]);
                }
            }
            return Math.Max(maxLength, substr.Count);
        }
    }
}
