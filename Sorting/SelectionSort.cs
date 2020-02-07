namespace Algorithms_and_Data_Structures.Sorting
{
	/// <summary>
	/// 
	/// </summary>
	public static class SelectionSort
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="arr"></param>
		/// <returns></returns>
		public static int[] sort(int [] arr)
		{
			for (int i = 0; i < arr.Length; i++) //go thru all elements
			{ 
				int iMin = i; //keep index of minimum element
				for (int j = i; j < arr.Length - 1; j++) //go thru unsorted part
				{
					if (arr[j + 1] < arr[iMin]) //if element in unsorted part less than an element in sorted
						iMin = j + 1;
				}
				int iTemp = arr[iMin]; //swap elements
				arr[iMin] = arr[i];
				arr[i] = iTemp;
			}
			return arr;
		}
	}
}
