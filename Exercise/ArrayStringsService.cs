using System.Net.Http.Headers;

namespace Exercise;

public static class ArrayStringsService
{
    /// <summary>
    /// Leetcode 283.
    /// Given an integer array nums, move all 0's to the end of it
    /// while maintaining the relative order of the non-zero elements.
    /// </summary>
    /// <param name="nums">Given integer array</param>
    public static void MoveZeroes(int[] nums)
    {
        var moves = 0;
        do
        {
            moves = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                var nextIndex = i + 1;
                if (nums[i] == 0 && nextIndex < nums.Length && nums[nextIndex] != 0)
                {
                    moves++;
                    nums[i] = nums[nextIndex];
                    nums[nextIndex] = 0;
                }
            }
        }
        while (moves > 0);
    }

    /// <summary>
    /// Leetcode 169.
    /// The majority element is the element that appears more than ⌊n / 2⌋ times.
    /// You may assume that the majority element always exists in the array.
    /// </summary>
    /// <param name="nums">Given integer array</param>
    /// <returns> Majority element </returns>
    public static int MajorityElement(int[] nums)
    {
        var distict = nums.Distinct();
        return distict.First(x => nums.Count(y => y == x) > nums.Length / 2);
    }

    /// <summary>
    /// Leetcode 392.
    /// Given two strings s and t, return true if s is a subsequence of t, or false otherwise.
    /// </summary>
    /// <param name="s">Given string</param>
    /// <param name="t">Possible substring</param>
    /// <returns> Return strue if t is substring of s, false otherwise </returns>
    public static bool IsSubsequence(string s, string t)
    {
        var index = 0;
        foreach (var x in s)
        {
            var addIndex = t[index..].IndexOf(x, StringComparison.Ordinal);
            if (addIndex == -1)
            {
                return false;
            }

            index += addIndex + 1;
        }
        return true;
    }

    /// <summary>
    /// Leetcode 14.
    /// Function to find the longest common prefix string amongst an array of strings
    /// </summary>
    /// <param name="strs">Array of strings</param>
    /// <returns>Longest prefix common to all strings </returns>
    public static string LongestCommonPrefix(string[] strs)
    {
        var shortest = strs.Select(x => x.Length).Min();
        var prefix = "";
        for (var i = 0; i < shortest; i++)
        {
            var distinctCharsAtIndex = strs.Select(x => x[i]).Distinct().Count();
            if (distinctCharsAtIndex == 1)
            {
                prefix += strs[0][i];
            }
            else
            {
                return prefix;
            }
        }
        return prefix;
    }

    /// <summary>
    /// Leetcode 189.
    /// Rotates an array to the right by k steps, where k is non-negative.
    /// </summary>
    /// <param name="nums">given array</param>
    /// <param name="k">step count</param>
    public static void Rotate(int[] nums, int k)
    {
        var index = k > nums.Length
            ? nums.Length - (k % nums.Length)
            : nums.Length - k;
        var firstPart = nums[..index].ToList();
        var secondPart = nums[index..].ToList();

        secondPart.AddRange(firstPart);

        for (var i = 0; i < nums.Length; i++)
        {
            nums[i] = secondPart[i];
        }
    }

    /// <summary>
    /// Leetcode 238.
    /// Returns an array such that array[i] is equal to the product of all the elements of inputArray except inputArray[i].
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static int[] ProductExceptSelf(int[] nums)
    {
        var output = new int[nums.Length];
        var hadZero = false;
        var outputZero = false;
        var moreThanOneZero = nums.Count(x => x == 0) > 1;
        var sign = nums.Count(x => x < 0) % 2 == 1 ? -1 : 1;
        var currentSign = sign;

        for (var i = 0; i < nums.Length; i++)
        {
            if (moreThanOneZero || hadZero || (outputZero && nums[i] != 0))
            {
                output[i] = 0;
            }
            else
            {
                if (nums[i] < 0)
                {
                    currentSign = sign * -1;
                }
                else
                {
                    currentSign = sign;
                }

                var list = nums[..i].Where(x => x != 1 && x != -1).ToList();
                list.AddRange(nums[(i + 1)..].Where(x => x != 1 && x != -1));

                output[i] = list.Aggregate(1, (sum, x) => sum * x);
                if ((output[i] < 0 && currentSign == 1) || (output[i] > 0 && currentSign == -1))
                {
                    output[i] = output[i] * -1;
                }

                if (nums[i] == 0)
                {
                    hadZero = true;
                }
                if (output[i] == 0)
                {
                    outputZero = true;
                }
            }
        }
        return output;
    }

    /// <summary>
    /// Leetcode 238.
    /// Goal of V2 is to improve performance.
    /// Returns an array such that array[i] is equal to the product of all the elements of inputArray except inputArray[i].
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static int[] ProductExceptSelfV2(int[] nums)
    {
        var zeroCount = nums.Count(x => x == 0);
        var resultArray = new int[nums.Length];

        if (zeroCount > 1)
        {
            return resultArray;
        }
        else if (zeroCount == 1)
        {
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    nums[i] = 1;
                    resultArray[i] = nums.Aggregate(1, (prod, x) => prod * x);
                }
            }
            return resultArray;
        }
        else
        {
            var calculated = new Dictionary<int, int>();
            for (var i = 0; i < nums.Length; i++)
            {
                var wasCalculatedBefore = calculated.TryGetValue(nums[i], out var calculatedValue);
                if (wasCalculatedBefore)
                {
                    resultArray[i] = calculatedValue;
                }
                else
                {
                    var x = nums[i];
                    nums[i] = 1;

                    resultArray[i] = nums.Aggregate(1, (prod, x) => prod * x);

                    nums[i] = x;

                    calculated.Add(nums[i], resultArray[i]);
                }
            }
            return resultArray;
        }
    }

    /// <summary>
    /// Leetcode 238.
    /// V3 is the version after checking solution in internet.
    /// Returns an array such that array[i] is equal to the product of all the elements of inputArray except inputArray[i].
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static int[] ProductExceptSelfV3(int[] nums)
    {
        int prefix = 1;
        int postfix = 1;
        int[] output = new int[nums.Length];

        for (int i = 0, k = nums.Length - 1; i < nums.Length; i++, k--)
        {
            if(i<k)
            {
                output[i] = prefix;
                prefix = prefix * nums[i];

                output[k] = postfix;
                postfix = postfix * nums[k];
            }
            else if(i==k)
            {
                output[i] = prefix * postfix;

                prefix = prefix * nums[i];
                postfix = postfix * nums[i];
            }
            else
            {
                output[i] = output[i] * prefix;
                prefix = prefix * nums[i];

                output[k] = output[k] * postfix;
                postfix = postfix * nums[k];
            }
        }

        return output;
    }

    /// <summary>
    /// Leetcode 28.
    /// Remove the duplicates in-place such that each unique element appears only once.
    /// The relative order of the elements should be kept the same.
    /// Then return the number of unique elements in nums.
    /// </summary>
    /// <param name="nums">Integer array nums sorted in non-decreasing order</param>
    /// <returns>The number of unique elements in nums</returns>
    public static int RemoveDuplicates(int[] nums) 
    {
        if(nums.Length < 2)
        {
            return nums.Length;
        }
        
        int index = 0;

        for(int i = 1; i < nums.Length; i++)
        {
            if(nums[i] > nums[index])
            {
                index++;
                nums[index] = nums[i];
            }
        }

        return index+1;
    }

    /// <summary>
    /// Leetcode 121 'Best Time to Buy and Sell Stock'.
    /// Maximize your profit by choosing a single day to buy one stock
    /// and choosing a different day in the future to sell that stock.
    /// </summary>
    /// <param name="prices">Array where prices[i] is the price of a given stock on the ith day <param>
    /// <returns>The maximum profit you can achieve from this transaction.
    /// If you cannot achieve any profit, return 0 <returns>
    public static int MaxProfit(int[] prices)
    {
        int lowestPrice = prices[0];
        int maxProfit = 0;

        for(int i = 1; i < prices.Length; i++)
        {
            if(prices[i]<=lowestPrice)
            {
                lowestPrice = prices[i];
            }
            else
            {
                var diff = prices[i] - lowestPrice;
                if(diff > maxProfit)
                {
                    maxProfit = diff;
                }
            }
        }

        return maxProfit;
    }

    /// <summary>
    /// Leetcode 122. Best Time to Buy and Sell Stock II
    /// On each day, you may decide to buy and/or sell the stock.
    /// You can only hold at most one share of the stock at any time.
    /// However, you can buy it then immediately sell it on the same day.
    /// Find and return the maximum profit you can achieve.
    /// </summary>
    /// <param name="prices">Array where prices[i] is the price of a given stock on the ith day <param>
    /// <returns>The maximum profit you can achieve from this transaction.
    /// If you cannot achieve any profit, return 0 <returns>
    public static int MaxProfitII(int[] prices)
    {
        var priceIsRising = false;
        var buyRate = -1;
        var profit = 0;

        for(int i = 1; i < prices.Length; i++ )
        {
            if(priceIsRising)
            {
                if(prices[i]<prices[i-1])
                {
                    profit+=prices[i-1]-buyRate;
                    priceIsRising = false;
                }
            }
            else
            {
                if(prices[i]>prices[i-1])
                {
                    buyRate = prices[i-1];
                    priceIsRising = true;
                }
            }
        }
        
        if(priceIsRising) profit += prices[prices.Length - 1] - buyRate;

        return profit;
    }

    /// <summary>
    /// Leetcode 217. Contains Duplicate
    /// Given an interger arraym return true if any value appears at least twice in the array.
    /// Return false if every array is distinct.
    /// </summary>
    /// <param name="nums">Array of integers where: 0 < nums.length <= 10^5 and -10^9 <= nums[i] <= 10^9 <param>
    /// <returns> True if array contains duplicates, false otherwise. <returns>
    public static bool ContainsDuplicate(int[] nums)
    {
        //using linq -> return nums.ToList().Distinct().Length != nums.Length
        var dict = new Dictionary<int, int>();

        foreach(var num in nums)
        {
            if(dict.ContainsKey(num))
            {
                return true;
            }
            else
            {
                dict.Add(num, 1);
            }
        }
        return false;
    }

    /// <summary>
    /// Leetcode 268. Missing Number. 
    /// Given an array containing  disctinct numbers in the range [0,n]
    /// return the only number in the range that is missing from the array.
    /// </summary>
    public static int MissingNumber(int[] nums)
    {
        var sum = 0;

        for(int i = 0; i < nums.Length; i++)
        {
            sum+=i;
            sum-=nums[i];
        }
        return sum + nums.Length;
    }
    
    /// <summary>
    /// Leetcode 448. Find all numbers disappeared in array. 
    /// Given an array 'nums' of n integers where nums[i] is in the range [1,n],
    /// return an array of all the integers in the range [1,n] that do not appear in array.
    /// </summary>
    public static IEnumerable<int> FindDisappearedNumbers(int[] nums)
    {
        var output = new List<int>();
        var set = new HashSet<int>(nums);

        for(int i = 1; i <= nums.Length; i++)
        {
            if(!set.Contains(i))
                output.Add(i);
        }
        return output;
    }
    
    //solution from leetcode
    public static IEnumerable<int> FindDisappearedNumbersV2(int[] nums)
    {
        var output = new List<int>();

        for(int i = 0; i < nums.Length; i++)
        {
            var j = Math.Abs(nums[i])-1;
            nums[j]= -Math.Abs(nums[j]);
        }

        for(int i = 1; i <= nums.Length; i++)
        {
            if(nums[i-1] > 0) output.Add(i);
        }
        return output;
    }

    /// <summary>
    /// Leetcode 1. Two sum.
    /// Given an array of integers- nums - and integer target,
    /// return indices of the two numbers such that they add up to target.
    /// You may assume that each input would have exactly one solution.
    /// Do not use same element twice.
    public static int[] TwoSum(int[] nums, int target)
    {
        //O(n^2) complexity
        for(int i = 0; i < nums.Length; i++)
        {
            for(int j = i+1; j<nums.Length; j++)
            { 
                if(i!=j)
                {
                    if(nums[i] + nums[j] == target)
                        return [i,j];
                }
            }
        }
        return [0,0]; //never returned as we assume that we always have solution
    }

    //better runetime worse memory
    public static int[] TwoSumV2(int[] nums, int target)
    {
        var set = new Dictionary<int,int>();

        for(int i = 0; i<nums.Length; i++)
        {
            var x = target - nums[i];
            if(set.ContainsKey(x))
            {
                return [i,set[x]];
            }
            set[nums[i]] = i;
        }
        return [0,0];
    }
}
