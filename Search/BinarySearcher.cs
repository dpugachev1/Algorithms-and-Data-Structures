namespace Algorithms_and_Data_Structures
{
	public static class BinarySearcher
	{
		public static int Search(int[] SortedArray, int SearchedValue)
		{
			return binarysrch(SortedArray, 0, SortedArray.Length - 1, SearchedValue);
		}

		static int binarysrch(int[] arr, int left, int right, int x)
		{
			if (left > right) return -1;
			int mid = (left + right) / 2;
			if (arr[mid] == x) return mid;

			if (x > arr[mid])
				return binarysrch(arr, mid + 1, right, x);
			else
				return binarysrch(arr, left, right - 1, x);
		}
	}
}
