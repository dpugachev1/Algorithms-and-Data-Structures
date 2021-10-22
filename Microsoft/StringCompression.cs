namespace Algorithms_and_Data_Structures.Microsoft
{
    public class StringCompression
    {
        public int Compress(char[] chars)
        {
            char cPrev = '\0'; //initialize with default value to check whether is it the first character
            int cCount = 0;
            int iInsertIndex = 0;
            for (int i = 0; i < chars.Length; i++)
            {
                if (cPrev == '\0') //first character in the string, leave it in input string as is
                {
                    cPrev = chars[i];
                    iInsertIndex++; //insert to the next position
                    cCount++;
                    continue;
                }
                if (cPrev != chars[i]) //if character has changed
                {
                    if (cCount > 1) //put number if more than one only
                    {
                        //put number after that position
                        foreach (char cInt in cCount.ToString())
                            chars[iInsertIndex++] = cInt;
                    }
                    chars[iInsertIndex++] = chars[i]; //put that character at insert index and increment it
                    cCount = 0;
                }
                cPrev = chars[i];
                cCount++; //increase counter
            }
            //add to the end if there counter is not empty
            if (cCount > 1)
            {
                //put number after that position
                foreach (char cInt in cCount.ToString())
                    chars[iInsertIndex++] = cInt;
            }
            return iInsertIndex;
        }
    }
}
