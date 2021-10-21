using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_and_Data_Structures.Microsoft
{
    public class SearchInRotatedSortedArray
    {
        public int Search(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;
            return BinarySearch(nums, left, right, target); //use modified binary search
        }

        public int BinarySearch(int[] nums, int left, int right, int target)
        {
            if (left > right) return -1;

            int mid = (int)((right + left) / 2);

            if (nums[mid] == target)
                return mid;
            if (nums[left] == target)
                return left;
            if (nums[right] == target)
                return right;
            //the only difference here is IF statement
            if (
                //if array lets say 4 5 6 7 0 1 2, then from 4 to 7 is left part and we are looking for a value in between
                //basically left subarray is not rotated
                (nums[mid] > nums[left] && target > nums[left] && target < nums[mid])
                ||
                //or if array 5 6 1 2 3 4 then from 5 to 2 is rotated array and we are looking if value 
                //is either GREATER than LEFT or LESS than MID
                (nums[mid] < nums[left] && (target > nums[left] || target < nums[mid]))
               )
                return BinarySearch(nums, left, mid - 1, target);
            else
                return BinarySearch(nums, mid + 1, right, target);
            return -1; //not found
        }
    }
}
