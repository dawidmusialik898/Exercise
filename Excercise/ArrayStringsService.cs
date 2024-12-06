using System.Net.Http.Headers;

namespace Excercise;

public static class ArrayStringsService
{
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

    public static int MajorityElement(int[] nums)
    {
        var distict = nums.Distinct();
        return distict.First(x => nums.Count(y => y == x) > nums.Length / 2);
    }

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

}
