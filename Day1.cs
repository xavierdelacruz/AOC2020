using System;
using System.Collections.Generic;

public class Day1
{
    public Day1() { }

    // PART 1. Uses dictionary method. 
    // Simple Two Sum. Find the two numbers that add up to 2020 (target), then multiple them.
    public int FindTwoProducts(int[] arr, int target)
    {

        var dict = new Dictionary<int, int>();

        for (int i = 0; i < arr.Length - 1; i++)
        {
            if (!dict.ContainsKey(arr[i]))
            {
                dict.Add(arr[i], i);
            }
        }

        for (int j = 0; j < arr.Length; j++)
        {
            var diff2 = Math.Abs(arr[j] - target);
            if (dict.ContainsKey(diff2) && j != dict[diff2])
            {
                return arr[dict[diff2]] * arr[j];
            }
        }
        return 0;
    }

    // PART 2. Uses the 3-pointer method similar to some modified Search algo with Sorting.
    // The idea is to capture the products of all three numbers.
    public int FindThreeProducts(int[] nums, int target)
    {
        if (nums.Length < 3)
        {
            return 0;
        }

        Array.Sort(nums);

        for (int i = 0; i < nums.Length - 2; i++)
        {
            var j = i + 1;
            var k = nums.Length - 1;
            if (i != 0 && nums[i - 1] == nums[i])
            {
                continue;
            }
            while (j < k)
            {
                if (nums[j - 1] == nums[j] && j > i + 1)
                {
                    j++;
                    continue;
                }

                var sum = nums[i] + nums[j] + nums[k];

                if (sum == target)
                {
                    return nums[i] * nums[j] * nums[k];
                }

                if (sum > target)
                {
                    k--;
                }

                if (sum < target)
                {
                    j++;
                }
            }
        }

        return 0;
    }
}