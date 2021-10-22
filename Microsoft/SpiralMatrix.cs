using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_and_Data_Structures.Microsoft
{
    public class SpiralMatrix
    {
        public IList<int> SpiralOrder(int[][] matrix)
        {

            char c = '2';

            StringBuilder builder = new StringBuilder();
            builder.Append(c);
            Stack<char> stk = new Stack<char>();
            

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
                Console.WriteLine(matrix[i][j]);
                lElements.Add(matrix[i][j]);
                matrix[i][j] = -999; //mark visited

                //we are currently moving right and we reached the border, and the next step will be on visited cell
                if (jDir == 1 && iDir == 0 && (j + jDir >= width || matrix[i][j + jDir] == -999))
                {
                    //go down then
                    iDir = 1;
                    jDir = 0;
                }
                //we are currently moving down and we either reached the border or the next step on a visited cell
                else
                if (iDir == 1 && jDir == 0 && (i + iDir >= height || matrix[i + iDir][j] == -999))
                {
                    //go left then
                    jDir = -1;
                    iDir = 0;
                }
                //we are moving left and we either be out of border or land on a visited cell
                else
                if (jDir == -1 && iDir == 0 && (j + jDir < 0 || matrix[i][j + jDir] == -999))
                {
                    //go up then
                    jDir = 0;
                    iDir = -1;
                }
                //we are moving up and we either be out of border or land on a visited cell
                else
                if (jDir == 0 && iDir == -1 && (i + iDir < 0 || matrix[i + iDir][j] == -999))
                {
                    //go right then
                    jDir = 1;
                    iDir = 0;
                }

                i += iDir;// iDir;
                j += jDir; //jDir; 
            }
            

            return lElements;
        }
    }
}
