namespace Algorithms_and_Data_Structures.Sorting
{
	public static class BubbleSort
	{
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static int[] sort(int[] arr)
		{
			for (int i = 0; i < arr.Length - 1; i++) //need to run J cycle n * n times
			{
				bool bFlag = false; //improved bubble -> if there is no swap array is already sorted
				for (int j = 0; j < arr.Length - 1 - i; j++) //arr.Length - 1 - i beause the last i elements are always sorted
				{
					if (arr[j] > arr[j + 1]) //swap pairs
					{
						int temp = arr[j + 1];
						arr[j + 1] = arr[j];
						arr[j] = temp;
						bFlag = true;
					}
				}
				if (!bFlag)
					break;
			}
			return arr;
		}
	}
}
