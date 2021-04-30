using Algorithms_and_Data_Structures;
using Algorithms_and_Data_Structures.LeetCode;
using System;
using System.Collections.Generic;

public  class TrainComposition
{
    private static Dictionary<ProgramCommands, Func<int>> programLookup = new Dictionary<ProgramCommands, Func<int>>();
	private enum ProgramCommands
	{ 
        Not_Recognized = 0,
        BinarySearch = 1,
        LeetCode_TwoSum = 102,
        LeetCode_TwoNumbers = 103,
        LeetCode_NumberOfIslands = 104,
        LeetCode_LRU_Cache = 105,
        LeetCode_CriticalConnections = 106
    }

    private static void InitializeProgramLookup()
	{
        programLookup.Add(ProgramCommands.BinarySearch, BinarySearch);
        programLookup.Add(ProgramCommands.LeetCode_TwoSum, LeetCode_TwoSum);
        programLookup.Add(ProgramCommands.LeetCode_TwoNumbers, LeetCode_TwoNumbers);
        programLookup.Add(ProgramCommands.LeetCode_NumberOfIslands, LeetCode_NumberOfIslands);
        programLookup.Add(ProgramCommands.LeetCode_LRU_Cache, LeetCode_LRU_Cache);
        programLookup.Add(ProgramCommands.LeetCode_CriticalConnections, LeetCode_CriticalConnections);
    }


	public static void Main(string[] args)
	{
		InitializeProgramLookup();

		if (args == null || args.Length == 0)
		{
			Console.WriteLine("No arguments specified.");
			return;
		}
		ProgramCommands command = ProgramCommands.Not_Recognized;
		if (!Enum.TryParse(args[0], out command))
		{
			Console.WriteLine("Not recognized command.");
			return;
		}
		programLookup[command].Invoke();
	}

	#region COMMANDS
	private static int BinarySearch()
	{
        Console.WriteLine(BinarySearcher.Search(new int[] { 1, 2, 4, 5, 6, 7, 8, 11, 15, 20, 25 }, 25).ToString());
        return 0;
    }

    private static int LeetCode_TwoSum()
	{
		int[] arr = new int[] { 230, 863, 916, 585, 981, 404, 316, 785, 88, 12, 70, 435, 384, 778, 887, 755, 740, 337, 86, 92, 325, 422, 815, 650, 920, 125, 277, 336, 221, 847, 168, 23, 677, 61, 400, 136, 874, 363, 394, 199, 863, 997, 794, 587, 124, 321, 212, 957, 764, 173, 314, 422, 927, 783, 930, 282, 306, 506, 44, 926, 691, 568, 68, 730, 933, 737, 531, 180, 414, 751, 28, 546, 60, 371, 493, 370, 527, 387, 43, 541, 13, 457, 328, 227, 652, 365, 430, 803, 59, 858, 538, 427, 583, 368, 375, 173, 809, 896, 370, 789 };
		int target = 542;
		int[] arr2 = TwoSumClass.TwoSum(arr, target);
		Console.WriteLine(arr2[0]);
		Console.WriteLine(arr2[1]);
		return 0;
    }

    private static int LeetCode_TwoNumbers()
    {
		AddTwoNumbersClass.ListNode list1 = new AddTwoNumbersClass.ListNode(1);
		//list1.next = new AddTwoNumbersClass.ListNode(1);
		//list1.next.next = new AddTwoNumbersClass.ListNode(3);

		AddTwoNumbersClass.ListNode list2 = new AddTwoNumbersClass.ListNode(9);
		list2.next = new AddTwoNumbersClass.ListNode(9);
		//list2.next.next = new AddTwoNumbersClass.ListNode(4);

		AddTwoNumbersClass.ListNode listResult = AddTwoNumbersClass.AddTwoNumbers(list1, list2);

		while (listResult != null)
		{
			Console.Write(listResult.val);
			listResult = listResult.next;
		}

		Console.ReadLine();
		return 0;
    }

    private static int LeetCode_NumberOfIslands()
    {
		char[][] grid = new char[][]
		{
			new char[] {'1','1','0','0','0'},
			new char[] {'1','1','0','0','0'},
			new char[] {'0','0','1','0','0'},
			new char[] {'0','0','0','1','1'}
		};
		NumberOfIslands num = new NumberOfIslands();
		int iCount = num.NumIslands(grid);
		Console.Write(iCount);
		Console.ReadLine();
		return 0;
    }

    private static int LeetCode_LRU_Cache()
    {
		LRUCache cache = new LRUCache(2);
		int iReturn = 0;
		cache.Put(1, 1);
		cache.Put(2, 2);
		iReturn = cache.Get(1);       // returns 1
		cache.Put(3, 3);    // evicts key 2
		iReturn = cache.Get(2);       // returns -1 (not found)
		cache.Put(4, 4);    // evicts key 1
		iReturn = cache.Get(1);       // returns -1 (not found)
		iReturn = cache.Get(3);       // returns 3
		iReturn = cache.Get(4);       // returns 4
		return 0;
    }

    private static int LeetCode_CriticalConnections()
    {
		CriticalConnectionsInNetwork network = new CriticalConnectionsInNetwork();
		IList<IList<int>> lConnections = new List<IList<int>>();
		lConnections.Add(new List<int>(new int[] { 0, 1 }));
		lConnections.Add(new List<int>(new int[] { 1, 2 }));
		lConnections.Add(new List<int>(new int[] { 2, 0 }));
		lConnections.Add(new List<int>(new int[] { 1, 3 }));

		lConnections.Add(new List<int>(new int[] { 3, 4 }));
		lConnections.Add(new List<int>(new int[] { 4, 5 }));
		lConnections.Add(new List<int>(new int[] { 4, 6 }));
		lConnections.Add(new List<int>(new int[] { 5, 6 }));

		lConnections.Add(new List<int>(new int[] { 0, 1 }));
		lConnections.Add(new List<int>(new int[] { 1, 2 }));

		network.CriticalConnections(3, lConnections);
		return 0;
    }
	#endregion
}