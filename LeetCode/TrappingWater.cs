using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_and_Data_Structures.LeetCode
{
    public class TrappingWater
    {
        public int Trap(int[] height)
        {
            int left = 0;
            int right = height.Length - 1;
            int maxLeft = 0;
            int maxRight = 0;
            int counter = 0;
            //two pointers solution
            //left pointer starts from zero
            //right pointer starts from end
            while (left != right) //until pointers are different
            {
                //each time find a maximum for every step
                maxLeft = Math.Max(maxLeft, height[left]);
                maxRight = Math.Max(maxRight, height[right]);
                //increase counter by difference between next height and maximum
                //if next height is lower then difference is 
                //the number of water that can be placed on that height
                counter += (maxLeft - height[left]);
                counter += (maxRight - height[right]);
                //if left > than right. stop moving left pointer
                //and start moving right
                //if left < than right again. stop moving right 
                //and restart moving left
                if (maxLeft <= maxRight)
                    left++;
                else
                    right--;
            }
            return counter;
        }
    }
}
