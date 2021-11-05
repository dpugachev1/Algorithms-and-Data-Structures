using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_and_Data_Structures.Microsoft
{
    class RemoveComments
    {
        public IList<string> RemoveCommentsFunc(string[] source)
        {

            List<string> retList = new List<string>();
            StringBuilder sb = new StringBuilder();
            int IsComment = 0; //0: normal; 1://; 2: /*

            for (int i = 0; i < source.Length; i++)
            {
                for (int j = 0; j < source[i].Length; j++)
                {
                    if (IsComment == 0) //no comment
                    {
                        if (j < source[i].Length - 1 && source[i][j] == '/')
                        {
                            if (source[i][j + 1] == '/') //comment starts with //
                            {
                                IsComment = 1; //ignore string to the end
                                break;
                            }
                            else if (source[i][j + 1] == '*') // comment starts with /*
                            {
                                IsComment = 2;
                                j++;
                            }
                            else
                                sb.Append(source[i][j]); //just slash and this is not a comment
                        }
                        else
                            sb.Append(source[i][j]); //keep adding characters
                    }
                    else //if multiline comments
                    {
                        if (j < source[i].Length - 1 && source[i][j] == '*' && source[i][j + 1] == '/') //comment ends with */
                        {
                            IsComment = 0; //comment ended, check next character
                            j++;
                        }
                    }
                }

                if (IsComment != 2) //if multiline is not complete
                {
                    if (sb.Length != 0)
                    {
                        retList.Add(sb.ToString());
                    }
                    sb = new StringBuilder();
                    IsComment = 0;
                }
            }
            return retList;
        }
    }
}
