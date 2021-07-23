using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_and_Data_Structures.Graphs_paths_
{
    public class RatInTheMaze
    {

        public int pathFinderCounter = 1;

        public int ShortestPathBinaryMatrix(int[][] grid)
        {
            int n = grid.Length;
            bool[,] visited = new bool[n, n];
            if (NextStep(grid, visited, 0, 0, n))
                return pathFinderCounter;
            else
                return -1;
        }

        public bool NextStep(int[][] grid, bool[,] visited, int i, int j, int n)
        {
            //out of grid scenarios
            if (i < 0 || j < 0 || i >= n || j >= n)
                return false;
            //movement is blocked
            if (grid[i][j] == 1)
                return false;
            //already visited cell
            if (visited[i, j])
                return false;
            //we are at the destination cell
            if (i == n - 1 && j == n - 1)
                return true;

            //increment our path
            pathFinderCounter++;
            visited[i, j] = true;

            //try 8-directonal movement BFS
            return
                NextStep(grid, visited, i + 1, j + 1, n) || // bottom right
                NextStep(grid, visited, i + 1, j, n) || //bottom            
                NextStep(grid, visited, i, j + 1, n) || //right
                NextStep(grid, visited, i - 1, j + 1, n) || //up right

                NextStep(grid, visited, i + 1, j - 1, n) || //bottom left
                NextStep(grid, visited, i - 1, j, n) || //up
                NextStep(grid, visited, i, j - 1, n) || //left
                NextStep(grid, visited, i - 1, j - 1, n) //up left
                ;
        }

    }
}
