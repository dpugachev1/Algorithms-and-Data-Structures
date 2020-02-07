
namespace Algorithms_and_Data_Structures.Sorting
{
	public static class MergeSort
	{
		public static int[] sort(ref int[] arr)
		{
			if (arr.Length < 2) return arr; //if 1 element -> return no need to divide anymore
			int n = arr.Length / 2; //divide array by 1
			int i;
			int[] L = new int[n]; //left
			int[] R = new int[arr.Length - n]; //and right

			for (i = 0; i < n; i++) //copy elements to left
			{
				L[i] = arr[i];
			}
			for(i = 0; i < arr.Length - n; i++) //copy elements to right
			{
				R[i] = arr[i + n];
			}
			sort(ref L); //recursively sort left one
			sort(ref R); //recursively sort right one
			merge(ref L, ref R, ref arr); //merge once it is ready

			return arr;
		}

		/// <summary>
		/// merge function
		/// </summary>
		/// <param name="L">left array</param>
		/// <param name="R">right array</param>
		/// <param name="A">result array</param>
		public static void merge(ref int[] L, ref int[] R, ref int[] A)
		{
			int iLeft = 0;
			int iRight = 0;
			int iResult = 0;
			
			while(iResult < A.Length && iLeft < L.Length && iRight < R.Length) //copy elements until one of array ends
			{
				if (L[iLeft] < R[iRight]) 
				{
					A[iResult] = L[iLeft];
					iLeft++;
					iResult++;
				}
				else
				{
					A[iResult] = R[iRight];
					iRight++;
					iResult++;
				}
			}
			while(iLeft < L.Length) //if right ended before copy the rest from the left
			{
				A[iResult] = L[iLeft];
				iLeft++;
				iResult++;
			}
			while(iRight < R.Length) //if left ended before copy the rest from the right
			{
				A[iResult] = R[iRight];
				iRight++;
				iResult++;
			}
		}
	}
}
