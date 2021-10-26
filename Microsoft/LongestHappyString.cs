using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms_and_Data_Structures.Microsoft
{
    public class LongestHappyString
    {

        public string LongestDiverseString(int a, int b, int c)
        {
            int counta = 0, countb = 0, countc = 0; // to reset them after completing count of 2
            int totlen = a + b + c; // max len of string possible
            StringBuilder ans = new StringBuilder(totlen); // final result

            for (int i = 0; i < totlen; i++)
            {

                if (a > 0 || b > 0 || c > 0)
                { // atleast if 1 a or b or c is present

                    if ((a >= b && a >= c && counta <= 1) || (a > 0 && (countb == 2 || countc == 2)))
                    { // taking 'a' when we have it more than other chars and count of a is less than 2 (or) we are checking for 'a' if 2 b's or c's are used consecutively.
                        ans.Append('a'); // adding a to ans string
                        counta++; // incrementing count of adj a's
                        countb = 0; // resetting adj b's
                        countc = 0; // resetting adj c's
                        a--; // dec count of a
                    }
                    else if ((b >= a && b >= c && countb <= 1) || (b > 0 && (counta == 2 || countc == 2)))
                    { // taking 'b' when we have it more than other chars and count of b is less than 2 (or) we are checking for 'b' if 2 a's or c's are used consecutively
                        ans.Append('b'); // adding b to ans string
                        countb++;  // incrementing count of adj b's
                        counta = 0; // resetting adj a's
                        countc = 0; // resetting adj c's
                        b--; // dec count of b
                    }
                    else if ((c >= b && c >= a && countc <= 1) || (c > 0 && (counta == 2 || countb == 2)))
                    { // taking 'c' when we have it more than other chars and count of c is less than 2 (or) we are checking for 'c' if 2 a's or b's are used consecutively
                        ans.Append('c'); // adding c to ans string
                        countc++;  // incrementing count of adj c's
                        counta = 0; // resetting adj a's
                        countb = 0; // resetting adj b's
                        c--; // dec count of c
                    }
                }
            }
            return ans.ToString();
        }
    }
}
