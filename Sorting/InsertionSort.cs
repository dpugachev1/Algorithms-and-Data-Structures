namespace Algorithms_and_Data_Structures.Sorting
{
	public static class InsertionSort
	{
		public static int[] sort(int[] arr)
		{
			int curElement = -1; //store next element in this variable, it needs for moving all elements
			for (int i = 1; i < arr.Length; i++) //from 1 element, since we are not interested at 0 element
			{
				if (arr[i] < arr[i - 1]) //if it is less than thel ast one it requires sorting
				{
					int j = i;
					curElement = arr[j];

					while (j > 0 && curElement < arr[j-1]) //move all to j position
					{
						arr[j] = arr[j - 1];
						j--;
					}
					arr[j] = curElement; //put last element at j position
				}
			}
			return arr;
		}
	}
}
