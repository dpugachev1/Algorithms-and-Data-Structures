using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_and_Data_Structures.Microsoft
{
    public class IntegerToEnglishWords
    {
        private Dictionary<int, string> dictPossibleWords;

        public IntegerToEnglishWords()
        {
            //declare a dictionary of all unique words that represent numbers
            dictPossibleWords = new Dictionary<int, string>();
            dictPossibleWords.Add(0, "Zero");
            dictPossibleWords.Add(1, "One");
            dictPossibleWords.Add(2, "Two");
            dictPossibleWords.Add(3, "Three");
            dictPossibleWords.Add(4, "Four");
            dictPossibleWords.Add(5, "Five");
            dictPossibleWords.Add(6, "Six");
            dictPossibleWords.Add(7, "Seven");
            dictPossibleWords.Add(8, "Eight");
            dictPossibleWords.Add(9, "Nine");
            dictPossibleWords.Add(10, "Ten");
            dictPossibleWords.Add(11, "Eleven");
            dictPossibleWords.Add(12, "Twelve");
            dictPossibleWords.Add(13, "Thirteen");
            dictPossibleWords.Add(15, "Fifteen");
            dictPossibleWords.Add(18, "Eighteen");
            dictPossibleWords.Add(20, "Twenty");
            dictPossibleWords.Add(30, "Thirty");
            dictPossibleWords.Add(40, "Forty");
            dictPossibleWords.Add(50, "Fifty");
            dictPossibleWords.Add(80, "Eighty");
            dictPossibleWords.Add(100, "Hundred");
            dictPossibleWords.Add(1000, "Thousand");
            dictPossibleWords.Add(1000000, "Million");
            dictPossibleWords.Add(1000000000, "Billion");
        }

        public string NumberToWords(int num)
        {

            //if word already found in the dictionary and doesn't need any additional changes -> return it
            if (dictPossibleWords.ContainsKey(num) && num < 100)
                return dictPossibleWords[num];

            List<string> st = new List<string>();
            int delim = 1000000000;
            for (int i = delim; i > 0; i /= 1000)
            {
                if (num / i == 0) continue;
                st.Add(GenerateUnderThousandString(num / i));
                if (i >= 100)
                    st.Add(dictPossibleWords[i]);
                num = num % i;
            }
            return string.Join(' ', st.ToArray());
        }

        //We need a function that translates a number less than thousand
        //so we can reuse it in generating thousands/millions/billions
        public string GenerateUnderThousandString(int num)
        {
            int delimeter = 100;
            int currentNumber = 0;
            List<string> currentWord = new List<string>();
            StringBuilder helpBuilder = new StringBuilder();
            for (int i = delimeter; i > 0; i /= 10) //would be 3 loops: 100, 10, 1
            {
                if (num < i) //we do not need to apply rules at that level
                    continue;
                currentNumber = (int)num / i;
                if (i == 100) //hundreds
                {
                    currentWord.Add(dictPossibleWords[currentNumber]); //number is always less than 9 so it is always in the dictionary
                    currentWord.Add(dictPossibleWords[i]); //100 -> always "Hundred"
                }
                if (i == 10) //teens
                {
                    if (num < 20)
                    {
                        if (dictPossibleWords.ContainsKey(num)) //if it is already in the dictionary
                            currentWord.Add(dictPossibleWords[num]);
                        else //otherwise build [number]+teen word
                        {
                            helpBuilder.Append(dictPossibleWords[num % i]);
                            helpBuilder.Append("teen");
                            currentWord.Add(helpBuilder.ToString());
                            helpBuilder.Clear();
                        }
                        break;
                    }
                    if (dictPossibleWords.ContainsKey(currentNumber * i)) //if it is already in the dicitonary
                        currentWord.Add(dictPossibleWords[currentNumber * i]);
                    else //otherwise build [number] + "ty" word
                    {
                        helpBuilder.Append(dictPossibleWords[currentNumber]);
                        helpBuilder.Append("ty");
                        currentWord.Add(helpBuilder.ToString());
                        helpBuilder.Clear();
                    }
                }
                if (i == 1) //this is always less than 9 so it is always in the dictionary
                {
                    currentWord.Add(dictPossibleWords[currentNumber]);
                }
                num = num % i;
            }
            return string.Join(' ', currentWord.ToArray());
        }
    }
}
