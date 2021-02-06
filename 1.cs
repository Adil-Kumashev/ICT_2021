using System;
using System.Collections.Generic;
using System.Text;

namespace ICT
{
    class _1
    {
           public int[] RunningSum(int[] nums)
        {

            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                nums[i] = sum;
            }

            return nums;
        }
    }
}
