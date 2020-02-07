using Algorithms_and_Data_Structures.Sorting;
using System;

namespace Algorithms_and_Data_Structures
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] arr = new int[] { 8, 5, 7, 1, 9, 3, 2, 3, 4,6,7,8,8,1,-1,9381,1,2,2,3,4,451,41};
			//int[] sortedAdd = SelectionSort.sort(arr);
			//int[] sortedAdd = InsertionSort.sort(arr);
			//int[] sortedAdd = BubbleSort.sort(arr);
			int[] sortedAdd = MergeSort.sort(ref arr);
			foreach (int i in arr)
				Console.Write(i + " ");
			Console.ReadLine();
		}
	}
}
