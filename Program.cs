using Algorithms_and_Data_Structures;
using Algorithms_and_Data_Structures.Amazon;
using Algorithms_and_Data_Structures.Google;
using Algorithms_and_Data_Structures.Graphs_paths_;
using Algorithms_and_Data_Structures.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;

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
        LeetCode_CriticalConnections = 106,
		LeetCode_IslandPerimeter = 107,
		LeetCode_LongestUniqueSubstring = 108,
		LeetCode_CountPrimes = 109,
		Amazon_RobotBoundedInCircle = 201,
		Amazon_SpiralMatrix = 202,
		Graphs_ShortestPathInBinaryMatrix = 301,
		Google_JustifyText = 401
	}

    private static void InitializeProgramLookup()
	{
        programLookup.Add(ProgramCommands.BinarySearch, BinarySearch);
        programLookup.Add(ProgramCommands.LeetCode_TwoSum, LeetCode_TwoSum);
        programLookup.Add(ProgramCommands.LeetCode_TwoNumbers, LeetCode_TwoNumbers);
        programLookup.Add(ProgramCommands.LeetCode_NumberOfIslands, LeetCode_NumberOfIslands);
        programLookup.Add(ProgramCommands.LeetCode_LRU_Cache, LeetCode_LRU_Cache);
        programLookup.Add(ProgramCommands.LeetCode_CriticalConnections, LeetCode_CriticalConnections);
		programLookup.Add(ProgramCommands.LeetCode_IslandPerimeter, LeetCode_IslandPerimeter);
		programLookup.Add(ProgramCommands.Amazon_RobotBoundedInCircle, Amazon_RobotBoundedInCircle);
		programLookup.Add(ProgramCommands.Graphs_ShortestPathInBinaryMatrix, ShortestPathInBinaryMatrix);
		programLookup.Add(ProgramCommands.LeetCode_LongestUniqueSubstring, LongestUniqueSubstringMethod);
		programLookup.Add(ProgramCommands.LeetCode_CountPrimes, LeetCode_CountPrimes);
		programLookup.Add(ProgramCommands.Amazon_SpiralMatrix, Amazon_SpiralMatrix);
		programLookup.Add(ProgramCommands.Google_JustifyText, Google_Justify);
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
		Console.ReadLine();
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

	private static int LeetCode_IslandPerimeter()
	{
		int[][] grid = new int[][]
		{ 
			new int[] { 1, 1 }
			//, 1, 0, 0 },
			//new int[] { 1, 1, 1, 0 },
			//new int[] { 0, 1, 0, 0 },
			//new int[] { 1, 1, 0, 0 } 
		};
		IslandPerimeterCalculator calculator = new IslandPerimeterCalculator();
		int iResult = calculator.IslandPerimeter(grid);

		return 0;
	}

	private static int Amazon_RobotBoundedInCircle()
	{
		string instructions = "GGRRGG";
		RobotRoundedInCircle calc = new RobotRoundedInCircle();
		bool b = calc.IsRobotBounded(instructions);
		Console.WriteLine(b.ToString());
		return 0;
	}

	private static int ShortestPathInBinaryMatrix()
    {
		int[][] grid =
		{
			 new int[] {0,1,1,1,1,1,1,1},
			 new int[] {0,1,1,0,0,0,0,0},
			 new int[] {0,1,0,1,1,1,1,0},
			 new int[] {0,1,0,1,1,1,1,0},
			 new int[] {0,1,1,0,0,1,1,0},
			 new int[] {0,1,1,1,1,0,1,0},
			 new int[] {0,0,0,0,0,1,1,0},
			 new int[] {1,1,1,1,1,1,1,0}
		};
		
		return ShortestPathInBinaryMatrixSolution.ShortestPathBinaryMatrix(grid);
    }

	private static int LongestUniqueSubstringMethod()
    {
		//string s = " ";
		string s = "dvdf";
		//string s = "aabaab!bb";
		return LongestUniqueSubstring.LengthOfLongestSubstring(s);

	}

	private static int LeetCode_CountPrimes()
    {
		int n = 1000;
		return CountPrimes.Primes(n);
    }

	private static int Amazon_SpiralMatrix()
    {
        int[][] matrix = new int[][]
            {
			new int[] { 1,2,3,4},
			new int[] { 5,6,7,8},
			new int[] { 9,10,11,12 }
			};

        SpiralMatrix.SpiralOrder(matrix);
		return 0;
    }

	private static int Google_Justify()
	{
		string[] arr = new string[] { "This", "is", "an", "example", "of", "text", "justification." };
		List<string> output = JustifyText.FullJustify(arr, 16).ToList<string>();
		return 0;
	}

	#endregion
}