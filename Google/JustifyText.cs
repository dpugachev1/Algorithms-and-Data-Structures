using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_and_Data_Structures.Google
{
    public static class JustifyText
    {
        public static IList<string> FullJustify(string[] words, int maxWidth)
        {
            List<string> lOutputList = new List<string>();
            List<string> lWords = new List<string>();
            int iCurWordsLength = 0;
            bool bBuildLine = false;
            int iWhiteSpacesAvailable = 0;
            int iMinSpaceSize = 0;
            int iRemainderSpace = 0;
            int offset = 0;

            for (int i = 0; i < words.Length; i++)
            {
                iCurWordsLength += words[i].Length;
                lWords.Add(words[i]);

                if (iCurWordsLength + (lWords.Count - 1) > maxWidth)
                {
                    lWords.RemoveAt(lWords.Count - 1);
                    iCurWordsLength -= words[i].Length;
                    i--; //back to previous step
                    bBuildLine = true;
                }

                if (i == words.Length - 1 || bBuildLine)
                {
                    iWhiteSpacesAvailable = maxWidth - iCurWordsLength;
                    if (lWords.Count > 1)
                    {
                        iMinSpaceSize = (int)(iWhiteSpacesAvailable / (lWords.Count - 1));
                        iRemainderSpace = iWhiteSpacesAvailable % (lWords.Count - 1);
                        if (i == words.Length - 1) //last line
                        {
                            iMinSpaceSize = 1;
                            iRemainderSpace = 0;
                        }
                    }
                    else
                    {
                        iMinSpaceSize = iWhiteSpacesAvailable;
                        iRemainderSpace = 0;
                    }
                    StringBuilder sbNewLine = new StringBuilder();
                    int j = 0;
                    //start building a line   
                    foreach (string word in lWords)
                    {
                        sbNewLine.Append(word);
                        if (j == lWords.Count - 1 && i == words.Length - 1) //last word
                        {
                            sbNewLine.Append(new string(' ', iWhiteSpacesAvailable));
                            break;
                        }

                        if (iWhiteSpacesAvailable > 0)
                        {
                            iRemainderSpace = iRemainderSpace >= 0 ? iRemainderSpace : 0;
                            offset = iRemainderSpace > 0 ? 1 : 0;
                            sbNewLine.Append(new string(' ', iMinSpaceSize + offset));

                            iWhiteSpacesAvailable -= (iMinSpaceSize + offset);
                            iRemainderSpace--;
                        }
                        j++;
                    }
                    lOutputList.Add(sbNewLine.ToString());
                    //clear all data
                    bBuildLine = false;
                    sbNewLine.Clear();
                    lWords.Clear();
                    iCurWordsLength = 0;
                    iWhiteSpacesAvailable = 0;
                    iMinSpaceSize = 0;
                    iRemainderSpace = 0;
                }
            }

            return lOutputList;
        }
    }
}
