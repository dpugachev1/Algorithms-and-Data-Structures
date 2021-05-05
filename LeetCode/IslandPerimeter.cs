using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_and_Data_Structures.LeetCode
{
	/*
	 * You are given row x col grid representing a map where grid[i][j] = 1 represents land and grid[i][j] = 0 represents water.

	Grid cells are connected horizontally/vertically (not diagonally). The grid is completely surrounded by water, and there is exactly one island (i.e., one or more connected land cells).

	The island doesn't have "lakes", meaning the water inside isn't connected to the water around the island. One cell is a square with side length 1. The grid is rectangular, width and height don't exceed 100. Determine the perimeter of the island.
	 */
	public class IslandPerimeterCalculator
	{
		private int ccter = 0;

		public int IslandPerimeter(int[][] grid)
		{
			ccter = 0;
			for (int i = 0; i < grid.Length; i++)
			{
				for (int j = 0; j < grid[i].Length; j++)
				{
					if (grid[i][j] == 1)
					{
						DFS(grid, i, j);
						return ccter;
					}
				}
			}
			return ccter;
		}

		private void DFS(int[][] grid, int iRow, int jColumn)
		{

			if (iRow >= grid.Length || iRow < 0 || jColumn >= grid[0].Length || jColumn < 0
				||
				grid[iRow][jColumn] <= 0 //sea or visited
				) return;

			if (grid[iRow][jColumn] == 1)
			{
				ccter += isEdge(grid, iRow, jColumn);
			}

			grid[iRow][jColumn] = -1;

			//top
			DFS(grid, iRow - 1, jColumn);
			//left
			DFS(grid, iRow, jColumn - 1);
			//right
			DFS(grid, iRow, jColumn + 1);
			//bottom
			DFS(grid, iRow + 1, jColumn);

		}

		private int isEdge(int[][] grid, int i, int j)
		{
			int perimeter = 0;

			if (j <= 0 || grid[i][j - 1] == 0) perimeter++; //LEFT border
			if (j >= grid[i].Length - 1 || grid[i][j + 1] == 0) perimeter++; //RIGHT border 

			if (i <= 0 || grid[i - 1][j] == 0) perimeter++; //TOP border
			if (i >= grid.Length - 1 || grid[i + 1][j] == 0) perimeter++; //BOTTOM border

			return perimeter;
		}
	}
}