using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_and_Data_Structures.Microsoft
{
    public class GroupAnagrams
    {
        public IList<IList<string>> GroupAnagramsFunction(string[] strs)
        {
            IList<IList<string>> outputList = new List<IList<string>>();
            Dictionary<string, List<string>> dictionaryResults = new Dictionary<string, List<string>>();
            string sortedString = "";
            foreach (string str in strs)
            {
                char[] charArr = str.ToCharArray();
                Array.Sort(charArr); //sort char array to check if string is an anagram
                sortedString = new string(charArr); //need new string to convert it to string
                                                    //key is always a sorted string
                if (!dictionaryResults.ContainsKey(sortedString))
                    dictionaryResults.Add(sortedString, new List<string>());
                dictionaryResults[sortedString].Add(str);
            }
            //convert to List<List<string>>
            foreach (var kvp in dictionaryResults)
            {
                List<string> sublist = new List<string>();
                foreach (string str in kvp.Value)
                    sublist.Add(str);
                outputList.Add(sublist);
            }
            return outputList;
        }
    }
}
