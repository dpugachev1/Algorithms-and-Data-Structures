using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_and_Data_Structures.Microsoft
{
    public class NumberOfIslands
    {
        public int NumIslands(char[][] grid)
        {
            int islandsCount = 0;
            for (int i = 0; i < grid.Length; i++) //check every cell
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    islandsCount += dfs(grid, i, j); //increment by 1 if island is located
                }
            }
            return islandsCount;
        }

        private int dfs(char[][] grid, int i, int j)
        {
            //check borders first
            if (i < 0 || i >= grid.Length) return 0;
            if (j < 0 || j >= grid[i].Length) return 0;
            //check if point is either water or visited
            if (grid[i][j] == '0') return 0;
            //mark it visited
            if (grid[i][j] == '1')
                grid[i][j] = '0';
            //check borders
            dfs(grid, i + 1, j); //check every possibiity of island around current cell
            dfs(grid, i - 1, j);
            dfs(grid, i, j + 1);
            dfs(grid, i, j - 1);
            return 1;
        }
    }
}
