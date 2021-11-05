using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms_and_Data_Structures.Microsoft
{
    public class MinDeletionsToMakeCharacterFrequenciesUnique
    {
        public int MinDeletions(string s)
        {
            Dictionary<char, int> sorted = new Dictionary<char, int>();
            foreach (char c in s) //add characters with frequencies to dictionary
            {
                if (!sorted.ContainsKey(c))
                    sorted.Add(c, 0);
                sorted[c]++;
            }
            int deletions = 0;
            int prevFreq = -1;
            int valueToDelete = 1;
            //sort dictionary descending
            foreach (var kvp in sorted.OrderByDescending(key => key.Value))
            {
                if (prevFreq == 0) //if previous frequency is 0 we will zero everything below
                {
                    deletions += kvp.Value;
                    continue;
                }
                //if previous frequency is below current we need to decrease by difference + 1
                if (prevFreq < kvp.Value && prevFreq != -1)
                {
                    valueToDelete = kvp.Value - prevFreq + 1;
                    deletions += valueToDelete;
                    prevFreq = kvp.Value - valueToDelete;
                }
                //if same frequency just decrement current one
                else if (prevFreq == kvp.Value)
                {
                    deletions++;
                    prevFreq = kvp.Value - 1;
                }
                else
                    prevFreq = kvp.Value;
            }
            return deletions;
        }
    }
}
