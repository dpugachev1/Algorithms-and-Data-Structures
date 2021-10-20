using System.Collections.Generic;

namespace Algorithms_and_Data_Structures.Microsoft
{
    public class MergeIntervals
    {
        public int[][] Merge(int[][] intervals)
        {

            List<int[]> lIntervals = new List<int[]>(intervals);
            //sort intervals first so we can apply the algorithm below
            lIntervals.Sort((x, y) => x[0].CompareTo(y[0]));

            List<int[]> resultIntervals = new List<int[]>(lIntervals.Count); //allocate space for no more than current intervals

            int leftBorder = 0;
            int rightBorder = 0;
            for (int i = 0; i < lIntervals.Count; i++) //iterate through every interval
            {
                leftBorder = lIntervals[i][0]; //always keep the left border
                rightBorder = lIntervals[i][1];
                while (i + 1 < lIntervals.Count) //we have three situations
                {
                    if (rightBorder < lIntervals[i + 1][0]) //1. if next interval does not overlapp
                        break; //just add current right border to the output and start from the next iteration
                    if (rightBorder > lIntervals[i + 1][1]) //2. if right border overlaps the next one completely, skip the next interval
                    {
                        i++;
                        continue;
                    }
                    //3. if current interval overlaps only the next one
                    rightBorder = lIntervals[i + 1][1];
                    i++;
                }
                resultIntervals.Add(new int[] { leftBorder, rightBorder }); //add interval eventually
            }
            return resultIntervals.ToArray();
        }
    }
}
