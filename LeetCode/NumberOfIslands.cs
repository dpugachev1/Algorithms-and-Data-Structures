namespace Algorithms_and_Data_Structures.LeetCode
{
	public class NumberOfIslands
	{
		private int cc = 0;
		private char[][] _grid = null;

		public int NumIslands(char[][] grid)
		{
			cc = 0;
			_grid = grid;
			for (int i = 0; i < _grid.Length; i++)
			{
				for (int j = 0; j < _grid[i].Length; j++) 
				{
					if (_grid[i][j] == 'x')
						continue;
					if (CheckPoint(i, j)) //if land was detected once
						cc++;
				}
			}
			return cc;
		}

		private bool CheckPoint(int i, int j)
		{
			if (_grid[i][j] == 'x') //if visited return
				return false;
			char point = _grid[i][j];
			_grid[i][j] = 'x'; //mark visited

			if (point == '0')
				return false;

			//if point is 1 continue looking for the nearest land
			if (i - 1 >= 0) //i-1
				CheckPoint(i - 1, j);

			if (i + 1 < _grid.Length) //i+1
				CheckPoint(i + 1, j);

			if (j - 1 >= 0)	//j-1
				CheckPoint(i, j - 1);

			if (j + 1 < _grid[i].Length) //j+1
				CheckPoint(i, j + 1);

			return true;
		}

	}
}
