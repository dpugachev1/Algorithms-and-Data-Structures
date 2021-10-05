using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_and_Data_Structures.Amazon
{
    public static class SpiralMatrix
    {
        public static IList<int> SpiralOrder(int[][] matrix)
        {
            List<int> lElements = new List<int>();
            int i = 0; //current i
            int j = 0; //current j
            int iDir = 0;
            int jDir = 1;
            //int step = 0; //current step
            int height = matrix.Length;
            int width = matrix[0].Length;
            //the order will be i++, j++, i--, j--, i++
            for (int step = 0; step < width * height; step++) //for each element
            {
                lElements.Add(matrix[i][j]);
                matrix[i][j] = -999; //mark visited
                if (jDir != 0 && j + jDir > 0 && (j + jDir == width || matrix[i][j + jDir] == -999) && jDir > 0) //right border - go down
                {
                    jDir = 0;
                    iDir = 1;

                }
                else if (iDir != 0 && i + iDir > 0 && (i + iDir == height || matrix[i + iDir][j] == -999) && iDir > 0) //bottom border - go left
                {
                    jDir = -1;
                    iDir = 0;
                }
                else if (jDir != 0 && (j + jDir < 0 || matrix[i][j + jDir] == -999)) //left border go up
                {
                    jDir = 0;
                    iDir = -1;
                }
                else if (iDir != 0 && (i + iDir < 0 || matrix[i + iDir][j] == -999)) //up border go right
                {
                    iDir = 0;
                    jDir = 1;
                }

                i += iDir;
                j += jDir;
            }
            return lElements;
        }
    }
}
