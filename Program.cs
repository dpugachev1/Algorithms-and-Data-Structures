using Algorithms_and_Data_Structures;
using Algorithms_and_Data_Structures.Amazon;
using Algorithms_and_Data_Structures.Google;
using Algorithms_and_Data_Structures.Graphs_paths_;
using Algorithms_and_Data_Structures.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
		Google_JustifyText = 401,
		Google_TimeBasedKeyValueStorage = 402,
		Google_MinimumNumberOfRefuelingStops = 403,
		Google_OptimalAccountBalancing = 404
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
		programLookup.Add(ProgramCommands.Google_TimeBasedKeyValueStorage, Google_TimeBasedKeyValueStorage);
		programLookup.Add(ProgramCommands.Google_MinimumNumberOfRefuelingStops, Google_MinimumNumberOfRefuelingStops);
		programLookup.Add(ProgramCommands.Google_OptimalAccountBalancing, Google_OptimalAccountBalancing);
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

	private static int Google_OptimalAccountBalancing()
    {
		int[][] matrix = new int[][]
		{
				new int[] { 0, 1, 10},
				new int[] { 2, 0, 5 }
		};

		OptimalAccountBalancing balancing = new OptimalAccountBalancing();
		return balancing.MinTransfers(matrix);
    }

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

	public double getHitProbability(int R, int C, int[,] G)
	{
		// Write your code here
		int ones = 0;
		for (int i = 0; i < R; i++)
		{
			for (int j = 0; j < C; j++)
				if (G[i, j] == 1)
					ones++;
		}
		
		return Math.Round((double)ones / (R * C), 6);
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

	public string getWrongAnswers(int N, string C)
	{ StringBuilder builder = new StringBuilder(C);
    // Write your code here
    for (int i = 0; i<C.Length; i++)
    {
        if (C[i] == 'A')
          builder[i] = 'B';
        else
          builder[i] = 'A';
    }
	return builder.ToString();
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

	private static int Google_TimeBasedKeyValueStorage()
    {
		TimeBasedKeyValueStorage timeMap = new TimeBasedKeyValueStorage();
		timeMap.Set("foo", "bar", 1);  // store the key "foo" and value "bar" along with timestamp = 1.
		timeMap.Get("foo", 1);         // return "bar"
		timeMap.Get("foo", 3);         // return "bar", since there is no value corresponding to foo at timestamp 3 and timestamp 2, then the only value is at timestamp 1 is "bar".
		timeMap.Set("foo", "bar2", 4); // store the key "foo" and value "ba2r" along with timestamp = 4.
		timeMap.Get("foo", 4);         // return "bar2"
		timeMap.Get("foo", 5);         // return "bar2"
		//timeMap.Set("love", "high", 10);
		//timeMap.Set("love", "love", 20);
		//timeMap.Get("love", 15);
		//timeMap.Get("love", 25);
		return 0;
	}
	//["TimeMap","set","set","get","get","get","get","get"]
	//[[],["love","high",10],["love","low",20],["love",5],["love",10],["love",15],["love",20],["love",25]]

	private static int Google_MinimumNumberOfRefuelingStops()
    {
		MinimumNumberOfRefuelingStops stops = new MinimumNumberOfRefuelingStops();
		int[][] stations = new int[4][];
		stations[0] = new int[2];
		stations[1] = new int[2];
		stations[2] = new int[2];
		stations[3] = new int[2];

		stations[0][0] = 10;
		stations[0][1] = 60;

		stations[1][0] = 20;
		stations[1][1] = 30;

		stations[2][0] = 30;
		stations[2][1] = 30;

		stations[3][0] = 60;
		stations[3][1] = 40;

		stops.MinRefuelStops_DynamicProgramming(100, 10, stations);
		return 0;
    }

	#endregion
}