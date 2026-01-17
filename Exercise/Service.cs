using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise;

public static class Service
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

    /// <summary>
    /// Leetcode 2348. Find all numbers disappeared in array.
    /// Given an integer array nums, return the number of subarrays filled with 0.
    /// A subarray is a contiguous non-empty sequence of elements within an array.
    /// </summary>
    public static long ZeroFilledSubarray(int[] nums)
    {
        long output = 0;
        long currentSum = 0;
        int currentStrike =0;
        for(int i = 0; i < nums.Length; i++)
        {
            if(nums[i] == 0)
            {
                currentStrike++;
                currentSum +=currentStrike;
            }
            else
            {
                output +=currentSum;
                currentSum =0;
                currentStrike = 0;
            }
        }
        output += currentSum;
        return output;
    }

    /// <summary>
    /// Leetcode 334. Increasing triplet subsequence.
    /// Given an inteter array 'nums',
    /// return true if there exists a sequence of i,j,k 
    /// where i<j<k and nums[i]<nums[j]<nums[k].
    /// In the other case return false
    public static bool IncreasingTriplet(int[] nums)
    {
        if(nums.Length < 3)
            return false;

        int minSingle = nums[0];
        int minDouble = Int32.MaxValue;

        for(int i = 1; i < nums.Length; i++)
        {
            if(nums[i] > minDouble)
                return true;

            if(nums[i] > minSingle)
                minDouble = nums[i];

            if(nums[i] < minSingle)
                minSingle = nums[i];
        }
        return false;
    }

    /// <summary>
    /// Leetcode 41. First missing positive
    /// Given an unsorted integer array nums.
    /// Return the smallest positive integer
    /// that is not present in nums
    /// Implementation must be O(n) time and O(1)space.
    public static int FirstMissingPositive(int[] nums)
    {
        for(int i = 0; i < nums.Length; i++)
        {
            if(nums[i] < 0)
                nums[i] = 0;
        }

        for(int i = 0; i < nums.Length; i++)
        {
            int index = Math.Abs(nums[i])-1;
            if(index >= 0 && index < nums.Length)
            {
               if(nums[index] > 0)
                   nums[index] *= -1;
               if(nums[index] == 0)
                   nums[index] = -(nums.Length + 2);
            }
        }
        
        int zeroCount = 0;
        for(int i = 1; i <= nums.Length; i++)
        {
            if(nums[i-1] >= 0)
                return i;

            if(nums[i-1] == 0)
                zeroCount++;
        }
        return nums.Length + 1 - zeroCount;
    }

    /// <summary> 
    /// Leetcode 125. Valid palindrome.
    /// A phrase is palindrome if, 
    /// after converting all to lowercase 
    /// and removing all non-alphanumeric characters,
    /// it reads the same forward and backward.
    /// Alphanumeric characters includes letters and numbers
    /// Assumpion- we;re getting only ascii chars
    public static bool IsPalindrome(string s)
    {
        s = s.ToLower();
        var filteredInput = s.Where(character => isDigit(character) || isLetter(character)).ToArray();
        
        for (int i=0, j = filteredInput.Length - 1; i < filteredInput.Length; i++, j--)
        {
            if(filteredInput[i] != filteredInput[j])
                return false;
        }
        return true;
    }

    //implementation without allocating memory and without extra iterations
    public static bool IsPalindromeV2(string s)
    {
        for(int i = 0, j = s.Length -1; i < s.Length && j >=0; i++, j--)
        {
            //skip non alphanumeric
            while(isAlphanumeric(s[i]) is false && i<s.Length-1)
                i++;

            while(isAlphanumeric(s[j]) is false && j>0)
                j--;
            
            //case if only nonalphanumeric
            if(isAlphanumeric(s[i]) is false && isAlphanumeric(s[j]) is false)
                return true;

            //handle lowercase/uppercase
            if(isLetter(s[i]) && isLetter(s[j]))
            {
                if(s[i] != s[j] && s[i]-32 != s[j] && s[i]+32 !=s[j])
                    return false;
            }
            else if(isDigit(s[i]) && isDigit(s[j]))
            {
                if(s[i] != s[j])
                    return false;
            }
            else
            {
                return false;
            }
        }
        return true;
    }

    private static bool isAlphanumeric(char c)
    => isLetter(c) || isDigit(c);
    
    private static bool isLetter(char c)
    {
        const char uppercaseA = 'A';
        const char lowercaseA = 'a';

        const int letters = 26;

        return (c>=uppercaseA && c<uppercaseA+letters
                || c>=lowercaseA && c<lowercaseA+letters);
    }
    
    private static bool isDigit(char c)
    {
        const int digits = 10;
        const char zero = '0';
        return (c>=zero && c<zero+digits);
    }

    /// <summary>
    /// Leetcode 6. Zigzag conversion.
    /// Convert given string to zigzag format
    /// and returns it as it was read line by line.
    /// To see more details - check leetcode explanation.
    public static string Convert(string s, int numRows)
    {
        if(numRows == 1 || numRows >= s.Length)
            return s;

        int verticalOffset = 2 * (numRows - 1);
        StringBuilder sb = new();
        for(int i = 0; i < numRows && i < s.Length; i++)
        {
            sb.Append(s[i]);
            
            if(i == 0 || i == numRows - 1)
            {
                int nextIndex = i + verticalOffset; 
                while(nextIndex < s.Length)
                {
                    sb.Append(s[nextIndex]);
                    nextIndex += verticalOffset;
                }
            }
            else
            {
                int diagonalOffset = 2 * (numRows - i - 1);
                int nextIndexVertical = i + verticalOffset; 
                int nextIndexDiagonal = i + diagonalOffset;

                while(nextIndexVertical < s.Length && nextIndexDiagonal < s.Length)
                {
                    sb.Append(s[nextIndexDiagonal]);
                    sb.Append(s[nextIndexVertical]);
                    nextIndexDiagonal = nextIndexVertical + diagonalOffset;
                    nextIndexVertical += verticalOffset; 
               }

                if(nextIndexDiagonal < s.Length)
                    sb.Append(s[nextIndexDiagonal]);
            }
        }

        return sb.ToString();
    }

    /// <summary>
    /// Leetcode 3085. Minimum deletions to make string k-special.
    /// We consider word to be k-special if
    /// |freq(word[i]) - freq(word[j])| <= k
    /// for all indices i and j in the string.
    /// Return the minimum number of characters
    /// you need to delete to make word k-special.
    /// word consist of only english lowercase letters
    public static int MinimumDeletions(string word, int k)
    {
        const int count = 26;
        int[] occur = new int[count];
        for(int i = 0; i < word.Length; i++)
        {
            occur[word[i]-'a'] ++;
        }
        Array.Sort(occur);
        // use sliding window technique -- looked up on internet
        var bottomDeletions = 0;
        var minimumDeletions = word.Length;

        for(int i = 0; i < count; i++)
        {
            //skip lines at the start
            if(occur[i] == 0)
                continue; 

            if(i - 1 >= 0)
                bottomDeletions+=occur[i-1];

            var topDeletions = 0;
            for(int j = i+1; j < count; j++)
            {
               var diff =  occur[j]-occur[i];
               if(diff > k)
               {
                   topDeletions+=diff-k;
               }
            }

            var sum = bottomDeletions + topDeletions;
            if(sum<minimumDeletions)
                minimumDeletions = sum;
        }
        return minimumDeletions;
    }

    /// <summary> Leetcode 151. Reverse words in the array.
    /// Given an input string s reverse the order of the words.
    /// A word is defined by a sequence of non-space characters.
    /// The words in s are separated in at lead one space.
    /// Return a string of the words in reverse concatenated
    /// by a single space.
    public static string ReverseWords(string s)
    {
        List<string> splitted = new();
        int startIndex = -1;
        for(int i = 0; i < s.Length; i++)
        {
            if(s[i] != ' ' && startIndex == -1)
            {
                startIndex = i;
            }

            if(s[i] == ' ' && startIndex != - 1)
            {
                var word = s.Substring(startIndex,i-startIndex);
                splitted.Add(word);
                startIndex = -1;
            }
        }
        if(startIndex != -1)
        {
            var word = s.Substring(startIndex,s.Length-startIndex);
            splitted.Add(word);
        }
        StringBuilder sb = new();
        for(int i = splitted.Count - 1; i >= 0; i--)
        {
            sb.Append(splitted[i]);
            if(i != 0)
                sb.Append(" ");
        }
        return sb.ToString();
    }
    
    //version with using c# tooling more :)
    public static string ReverseWordsV2(string s)
    {
        var splitted = s.Split(' ',StringSplitOptions.RemoveEmptyEntries);
        Array.Reverse(splitted);
        return string.Join(' ',splitted);
    }

    /// <summary>
    /// Leetcode 11. Container with most water.
    public static int MaxArea(int[] height)
    {
        int i = 0;
        int j = height.Length - 1;
        int maxWater = 0;
        while(i!=j)
        {
            int water = 0;
            if(height[i]<height[j])
            {
                water = (j-i)*height[i];
                i++;
            }
            else
            {
                water = (j-i)*height[j];
                j--;
            }
            if(water > maxWater)
            {
                maxWater = water;
            }
        }
        return maxWater;
    }

    /// <summary>
    /// Leetcode 4, Median of two sorted arrays.
    public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
		//requirement is to do int in O(log(m+n)) where m and n are array size.
		return 0d;
    }

	/// Leetcode 15. 3Sum.
	/// Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]]
	/// such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.
	/// Apparently it's still to slow O(N^2) but idk how to speed it up.
	public static IList<IList<int>> ThreeSum(int[] nums)
	{
		IList<IList<int>> result = new List<IList<int>>();
		Dictionary<int,int> numCount = [];
		HashSet<(int, int, int)> resSet = []; 

		for(int i = 0; i < nums.Length; i++)
		{
			int a = nums[i];
			if(!numCount.TryAdd(a, 1))
			{
				numCount[a] = numCount[a] + 1;
			}
		}

		for(int i = 0; i < nums.Length - 1; i++)
		{
			int a = nums[i];
			for(int j = i + 1; j < nums.Length; j++)
			{
				int b = nums[j];
				int c = 0 - a - b;

				// guard if the same sequence was already added
				if(!resSet.Add((a,b,c)))
					continue;
				// if not first add all possible combinations to the helper set
				resSet.Add((a,c,b));
				resSet.Add((b,c,a));
				resSet.Add((b,a,c));
				resSet.Add((c,a,b));
				resSet.Add((c,b,a));	

				//if all numbers are the same only 0,0,0 is
				//possible so we need 3 zeros in nums
				if(a==b && b==c) 
				{
					if(a==0 && numCount[0] >= 3)
						result.Add([a,b,c]);
					continue;
				}
				//if c is same as b or a
				//we need to have two occurences of c in nums
				if(c==b || c==a)
				{
					if(numCount.TryGetValue(c,out int count) && count >=2)
						result.Add([a,b,c]);
					continue;
				}
				//if c is different from both k
				//then we need just one occurence of c in nums
				if(numCount.ContainsKey(c))
					result.Add([a,b,c]);
			}
		}
		return result;
	}
	public static IList<IList<int>> ThreeSumFromSolution(int[] nums)
	{
		Array.Sort(nums);
		IList<IList<int>> result = new List<IList<int>>();

		for(int i = 0; i < nums.Length - 2; i++)
		{
			int a = nums[i];
			if(i > 0 && a == nums[i-1])
				continue;

			int j = i+1;
			int k = nums.Length-1;

			while(j < k)
			{
				int b = nums[j];
				int c = nums[k];
				int sum = a + b + c;
				if(sum == 0)
				{
					result.Add([a,b,c]);
					do
						j++;
					while(j<k && nums[j] == b);
				}
				else if(sum > 0)
				{
					k--;
				}
				else
				{
					j++;
				}
			}
		}
		return result;
	}
	
	public static int ThreeSumClosest(int[] nums, int target)
	{
		Array.Sort(nums);
		int minDiff = 99999;
		int output = 9999;
		for(int i = 0; i < nums.Length - 2; i++)
		{
			int j = i+1;
			int k = nums.Length -1;
			while(j<k)
			{
				int sum = nums[i] + nums[j] + nums[k];
				int diff = Math.Abs(target - sum);
				if(diff == 0)
				{
					return sum;
				}
				if(diff < minDiff)
				{
					minDiff = diff;
					output = sum;
				}
				if(sum<target)
				{
					j++;
				}
				else
				{
					k--;
				}
			}
		}
		return output;
	}
}
