using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_and_Data_Structures.Microsoft
{
    public class DecodeStringSolution
    {
        public string DecodeString(string s)
        {

            //use global builder to build the result
            StringBuilder globalBuilder = new StringBuilder();
            //use local builder for intermediate results
            StringBuilder localBuilder = new StringBuilder();
            //builder used to convert multiple character to integer
            StringBuilder intBuilder = new StringBuilder();
            //stack that stores number of repeats
            Stack<int> stkRepeats = new Stack<int>();
            //stack that stores substrings that needs to be repeated
            Stack<string> stkSubstring = new Stack<string>();
            bool numberPushedBefore = false;

            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsLetter(s[i]))
                {
                    //always append letter to a local builder
                    localBuilder.Append(s[i]);
                    continue;
                }
                if (char.IsDigit(s[i]))
                {
                    //flush localbuilder to a stkSubstrings before opening the next bracket
                    if (localBuilder.Length > 0)
                    {
                        if (!numberPushedBefore) stkRepeats.Push(1); //if stack is empty then this is prefix
                                                                     //stkSubstring.Push(localBuilder.ToString());
                                                                     //localBuilder.Clear();
                                                                     //PushStringToStack(localBuilder, stkSubstring);
                        stkSubstring.Push(localBuilder.ToString());
                        localBuilder.Clear();
                    }
                    /*start reading multi-digit integer */
                    intBuilder.Clear();
                    while (s[i] != '[')
                    {
                        intBuilder.Append(s[i]);
                        i++; //will be skipped until after [
                    }
                    int number = int.Parse(intBuilder.ToString()); //get that number result
                    stkRepeats.Push(number); //and push it to the stack of numbers
                    stkSubstring.Push("");
                    /*end reading multi-digit integer */
                    numberPushedBefore = true;
                }
                if (s[i] == ']')
                {
                    //add localBuilder data to stack
                    if (localBuilder.Length > 0)
                    {
                        //stkSubstring.Push(localBuilder.ToString());
                        PushStringToStack(localBuilder, stkSubstring);
                        localBuilder.Clear();
                    }
                    else //if there is no strings, then push data to the next level
                    {
                        int repeats = stkRepeats.Pop();
                        string substr = stkSubstring.Pop();

                        localBuilder.Insert(0, substr, repeats); //build substring of current level and append it to the next one

                        substr = stkSubstring.Pop();
                        localBuilder.Insert(0, substr, 1);
                        stkSubstring.Push(localBuilder.ToString());
                        localBuilder.Clear();
                    }
                    numberPushedBefore = false;
                }
            }
            //flush the rest from the local builder
            if (localBuilder.Length > 0)
            {
                stkRepeats.Push(1);
                stkSubstring.Push(localBuilder.ToString());
            }

            //building final string
            while (stkRepeats.Count > 0)
            {
                int repeats = stkRepeats.Pop();
                string substr = stkSubstring.Pop();

                globalBuilder.Insert(0, substr, repeats);
            }

            return globalBuilder.ToString();
        }

        private void PushStringToStack(StringBuilder builder, Stack<string> stack)
        {
            string substr = stack.Pop();
            stack.Push(builder.ToString());
            builder.Clear();
        }
    }
}
