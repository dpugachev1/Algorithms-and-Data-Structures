using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_and_Data_Structures.Graphs_paths_
{
    public static class ShortestPathInBinaryMatrixSolution
    {

        private static int[,] movements = new int[,] { 
            { 1, 1 }, //down right
            { 1, 0 }, //down
            { 0, 1 }, //right
            { -1, 1 }, //up right
            { -1, 0 }, //up
            { -1, -1 }, //left up
            { 0, -1 }, //left
            { 1, -1 } //left down
        };

        public static int ShortestPathBinaryMatrix(int[][] grid)
        {
            Queue<int[]> bfsQueue = new Queue<int[]>();
            int level = 1;
            int m = grid.GetLength(0);
            //int n = grid.GetLength(1);
            bool[,] visited = new bool[m, m];
            int[] dequeuedPos;
            int nextI = 0;
            int nextJ = 0;
            
            bfsQueue.Enqueue(new int[] { 0, 0, level }); //enque first element and its level
            visited[0, 0] = true;

            if (grid[0][0] == 1) return -1;

            while (bfsQueue.Count > 0) //while there is elements in the queue
            {
                dequeuedPos = bfsQueue.Dequeue();

                //we are that position
                if (dequeuedPos[0] == m-1 && dequeuedPos[1] == m-1) //if end return steps
                {
                    return dequeuedPos[2];
                }
                
                //go thru all possible movements
                for (int i = 0; i < movements.GetLength(0); i++)
                {
                    nextI = dequeuedPos[0] + movements[i, 0];
                    nextJ = dequeuedPos[1] + movements[i, 1];

                    if (nextI < 0 || nextJ < 0 || nextI >= m || nextJ >= m //if out of grid
                        || grid[nextI][nextJ] == 1 //or path is blocked
                        || visited[nextI, nextJ]) //or it is already visited
                    {
                        continue;
                    }
                    bfsQueue.Enqueue(new int[] { nextI, nextJ, dequeuedPos[2] + 1 });
                    visited[nextI, nextJ] = true; //mark it visited
                }
            }
            return -1;
        }
    }
}
