
using System.Collections;
using System.Collections.Generic;

namespace Algorithms_and_Data_Structures.LeetCode
{
    public static class TwoSumClass
    {
        public static int[] TwoSum(int[] nums, int target)
        {
            //using hashtable to store values because of getting an element takes O(1) time
            Dictionary<int, int> hashtable = new Dictionary<int, int>(nums.Length);
            for (int i = 0; i < nums.Length; i++) //store value = O(n)
            {
                if (!hashtable.ContainsKey(nums[i])) //do not store duplicates
                    hashtable.Add(nums[i], i);
            }
            int iResult = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                iResult = target - nums[i]; //we got result

                if (hashtable.ContainsKey(iResult) && (int)hashtable[iResult] != i) //if it didn't find a duplicate it will find it later
                {
                    return new int[] { i, (int)hashtable[iResult] };
                }
            }
            return new int[] { -1, -1 };
        }


        public static int[] TwoSumShortest(int[] nums, int target)
        {
            Dictionary<int, int> hashtable = new Dictionary<int, int>(nums.Length);

            int iResult = -1;

            for (int i = 0; i < nums.Length; i++)
            {
                iResult = target - nums[i]; //we got result

                if (hashtable.ContainsKey(iResult))// && (int)hashtable[iResult] != i)
                {
                    return new int[] { i, (int)hashtable[iResult] };
                }
                if (!hashtable.ContainsKey(nums[i]))
                    hashtable.Add(nums[i], i);
            }
            return new int[] { -1, -1 };
        }
    }

}