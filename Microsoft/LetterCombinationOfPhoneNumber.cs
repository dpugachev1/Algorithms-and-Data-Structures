using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_and_Data_Structures.Microsoft
{
    public class LetterCombinationOfPhoneNumber
    {
        private Dictionary<char, string> dictPhone;
        private List<string> results;

        public LetterCombinationOfPhoneNumber()
        {
            dictPhone = new Dictionary<char, string>();
            dictPhone.Add('2', "abc");
            dictPhone.Add('3', "def");
            dictPhone.Add('4', "ghi");
            dictPhone.Add('5', "jkl");
            dictPhone.Add('6', "mno");
            dictPhone.Add('7', "pqrs");
            dictPhone.Add('8', "tuv");
            dictPhone.Add('9', "wxyz");

            results = new List<string>();
        }

        public IList<string> LetterCombinations(string digits)
        {
            if (digits.Length == 0) return results; //check for an empty string
                                                    //there is up to 4 digits in digits string 
            List<string> numStrings = new List<string>(digits.Length);
            foreach (var c in digits)
                numStrings.Add(dictPhone[c]);

            StringBuilder builder = new StringBuilder(); //we need a stringbuilder to append characters
            PrintNumber(numStrings, builder, 0, 0);
            return results;
        }

        public void PrintNumber(List<string> digits, StringBuilder builder, int level, int character)
        {
            if (builder.Length == digits.Count) //if number of characters in builder equals number of initial string
            {
                results.Add(builder.ToString()); //add it to results
                return;
            }
            //loop thru every character on current level
            for (int i = 0; i < digits[level].Length; i++)
            {
                //add the character to our builder (path)
                builder.Append(digits[level][i]);
                //go into next level
                PrintNumber(digits, builder, level + 1, i);
                //remove last character for backtracking purposes
                builder.Remove(builder.Length - 1, 1);
            }
        }
    }
}
}
