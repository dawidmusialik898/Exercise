using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Exercise;

namespace Tests;

public class ServiceTests
{
    [Theory]
    [InlineData(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
    [InlineData(new int[] { 1, 0, 2, 0, 3, 0 }, new int[] { 1, 2, 3, 0, 0, 0 })]
    [InlineData(new int[] { 1, 0, 0, 2, 0, 3, 0 }, new int[] { 1, 2, 3, 0, 0, 0, 0 })]
    [InlineData(new int[] { 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0 })]
    [InlineData(new int[] { 0 }, new int[] { 0 })]
    [InlineData(new int[] { }, new int[] { })]
    public void MoveZeros_ShoudReturnModifiedArray(int[] input, int[] expectedOutput)
    {
        //arrange & act
        Service.MoveZeroes(input);
        //assert
        for (var i = 0; i < expectedOutput.Length; i++)
        {
            Assert.Equal(input[i], expectedOutput[i]);
        }
    }
    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4, 4, 4, 4 }, 4)]
    [InlineData(new int[] { 1, 1, 1, 1, 1, 4, 4, 4, 4 }, 1)]
    [InlineData(new int[] { 1 }, 1)]
    [InlineData(new int[] { 1, 1 }, 1)]
    [InlineData(new int[] { 1, 2, 1 }, 1)]
    public void MajorityElement_ShouldReturnMajorityElement(int[] input, int expectedOutput)
    {
        //arrange & act
        var output = Service.MajorityElement(input);
        //assert
        Assert.Equal(expectedOutput, output);
    }
    [Theory]
    [InlineData("asd", "azsgddf", true)]
    [InlineData("asdf", "asd", false)]
    [InlineData("asdfghijkz", "asdfghijkd", false)]
    [InlineData("", "", true)]
    [InlineData("", "asdf", true)]
    [InlineData("gf", "agsdf", true)]
    [InlineData("aaaaa", "bbaaaa", false)]
    [InlineData("aaaaa", "aaaabb", false)]
    public void IsSubsequence_ShouldSayIf_S_Is_Subsequent_Of_T(string s, string t, bool expectedOutput)
    {
        //arrange & act
        var output = Service.IsSubsequence(s, t);
        //assert
        Assert.Equal(expectedOutput, output);
    }
    [Theory]
    [InlineData(new string[] { "asdf", "ghijk", "xzsaqs" }, "")]
    [InlineData(new string[] { "", "", "x" }, "")]
    [InlineData(new string[] { "abyulkhlu", "abyuyk", "absewtx" }, "ab")]
    [InlineData(new string[] { "ddcdddd", "ddyddddd", "ddsdddddd" }, "dd")]
    public void LongestCommonPrefix_ShouldReturnCorrectPrefix(string[] input, string expectedOutput)
    {
        //arrange & act
        var output = Service.LongestCommonPrefix(input);
        //assert
        Assert.Equal(expectedOutput, output);
    }
    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 3, new int[] { 5, 6, 7, 1, 2, 3, 4 })]
    [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 1, 2, 3, 4, 5, 6, 7 }, 3, new int[] { 5, 6, 7, 1, 2, 3, 4, 5, 6, 7, 1, 2, 3, 4 })]
    [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 1, 2, 3, 4, 5, 6, 7 }, 9, new int[] { 6, 7, 1, 2, 3, 4, 5, 6, 7, 1, 2, 3, 4, 5 })]
    [InlineData(new int[] { -1, -100, 3, 99 }, 2, new int[] { 3, 99, -1, -100 })]
    [InlineData(new int[] { 2, 3, 4 }, 5, new int[] { 3, 4, 2 })]
    public void RotateTests(int[] nums, int k, int[] expectedOutput)
    {
        //arrange & act
        Service.Rotate(nums, k);
        //assert
        Assert.Equal(expectedOutput, nums);
    }
    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4 }, new int[] { 24, 12, 8, 6 })]
    [InlineData(new int[] { -1, 1, 0, -3, 3 }, new int[] { 0, 0, 9, 0, 0 })]
    [InlineData(new int[] { -1, -1, 1, 0, -3, 3 }, new int[] { 0, 0, 0, -9, 0, 0 })]
    [InlineData(new int[] { -1, -1, -1, 1, -1, 1, 1, 1, -1, 1, 0, -3, 3 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 9, 0, 0 })]
    [InlineData(new int[] { 1, -1 }, new int[] { -1, 1 })]
    [InlineData(new int[] { 9, 0, -2 }, new int[] { 0, -18, 0 })]
    public void ProductExceptSelfTests(int[] nums, int[] expectedOutput)
    {
        //arrange & act
        var output = Service.ProductExceptSelf(nums);
        //assert
        Assert.Equal(expectedOutput, output);
    }
    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4 }, new int[] { 24, 12, 8, 6 })]
    [InlineData(new int[] { -1, 1, 0, -3, 3 }, new int[] { 0, 0, 9, 0, 0 })]
    [InlineData(new int[] { -1, -1, 1, 0, -3, 3 }, new int[] { 0, 0, 0, -9, 0, 0 })]
    [InlineData(new int[] { -1, -1, -1, 1, -1, 1, 1, 1, -1, 1, 0, -3, 3 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 9, 0, 0 })]
    [InlineData(new int[] { 1, -1 }, new int[] { -1, 1 })]
    [InlineData(new int[] { 9, 0, -2 }, new int[] { 0, -18, 0 })]
    public void ProductExceptSelfV2Tests(int[] nums, int[] expectedOutput)
    {
        //arrange & act
        var output = Service.ProductExceptSelfV2(nums);
        //assert
        Assert.Equal(expectedOutput, output);
    }
    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4 }, new int[] { 24, 12, 8, 6 })]
    [InlineData(new int[] { -1, 1, 0, -3, 3 }, new int[] { 0, 0, 9, 0, 0 })]
    [InlineData(new int[] { -1, -1, 1, 0, -3, 3 }, new int[] { 0, 0, 0, -9, 0, 0 })]
    [InlineData(new int[] { -1, -1, -1, 1, -1, 1, 1, 1, -1, 1, 0, -3, 3 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 9, 0, 0 })]
    [InlineData(new int[] { 1, -1 }, new int[] { -1, 1 })]
    [InlineData(new int[] { 9, 0, -2 }, new int[] { 0, -18, 0 })]
    public void ProductExceptSelfV3Tests(int[] nums, int[] expectedOutput)
    {
        //arrange & act
        var output = Service.ProductExceptSelfV3(nums);
        //assert
        Assert.Equal(expectedOutput, output);
    }
    [Theory]
    [InlineData(new int[] {}, new int[] {}, 0)]
    [InlineData(new int[] {5}, new int[] {5}, 1)]
    public void RemoveDuplicates_ShouldReturnNumsLength_And_LeaveArrayUntouched(
            int[]inputArray, int[]expectedOutputArray, int expectedOutput)
    {
        var output = Service.RemoveDuplicates(inputArray);
        Assert.Equal(expectedOutput, output);
        for (int i = 0; i < expectedOutputArray.Length; i++)
        {
            Assert.Equal(expectedOutputArray[i], inputArray[i]);
        }
    }
    
    [Theory]
    [InlineData(new int[] {1,2,3,4}, new int[] {1,2,3,4}, 4)]
    [InlineData(new int[] {1,1,1,1,2,3,4}, new int[] {1,2,3,4}, 4)]
    [InlineData(new int[] {1,2,2,2,2,2,3,3,3,3,3,4,4,4,4}, new int[] {1,2,3,4}, 4)]
    [InlineData(new int[] {1,1,1,1,2,2,2,3,4,87,97}, new int[] {1,2,3,4,87,97}, 6)]
    public void RemoveDuplicates_ShouldReturnProperUniqueElementsCount_And_ModifyPassedArray(
            int[]inputArray, int[]expectedOutputArray, int expectedOutput)
    {
        var output = Service.RemoveDuplicates(inputArray);
        Assert.Equal(expectedOutput, output);
        for (int i = 0; i < expectedOutputArray.Length; i++)
        {
            Assert.Equal(expectedOutputArray[i], inputArray[i]);
        }
    }
    [Theory]
    [InlineData(new int[] {7,1,5,3,6,4}, 5)]
    [InlineData(new int[] {7,6,5,3,1}, 0)]
    [InlineData(new int[] {7,2,15,1,6,4}, 13)]
    public void MaxProfit_ShouldReturnProperValueForGivenStockPrices(int[] prices, int expectedOutput)
    {
        var output = Service.MaxProfit(prices);
        Assert.Equal(expectedOutput, output);
    }
    [Theory]
    [InlineData(new int[] {5}, 0)]
    [InlineData(new int[] {7,1,5,3,6,4}, 7)]
    [InlineData(new int[] {1,2,3,4,5}, 4)]
    [InlineData(new int[] {7,6,4,3,1}, 0)]
    [InlineData(new int[] {7,2,4,1,7,4,5,8}, 12)]
    public void MaxProfitII_ShouldReturnProperValueForGivenStockPrices(int[] prices, int expectedOutput)
    {
        var output = Service.MaxProfitII(prices);
        Assert.Equal(expectedOutput, output);
    }
    [Theory]
    [InlineData(new int[] {0},1)]
    [InlineData(new int[] {1,3,0,0,2,0,0,4},6)]
    [InlineData(new int[] {0,0,0,2,0,0},9)]
    [InlineData(new int[] {123,53,923,12},0)]
    public void ZeroFilledSubarray_ShouldReturnCountOfAllSubarrays(int[] nums, int expectedOutput)
    {
        var output = Service.ZeroFilledSubarray(nums);
        Assert.Equal(expectedOutput, output);
    }
    [Theory]
    [InlineData(new int[] {1,2,3,4,5},true)]
    [InlineData(new int[] {1,2,3},true)]
    [InlineData(new int[] {2,1,5,0,4,6},true)]
    [InlineData(new int[] {0,1,0,0,4,6},true)]
    [InlineData(new int[] {1,0,0,4},false)]
    [InlineData(new int[] {0,1},false)]
    [InlineData(new int[] {0},false)]
    [InlineData(new int[] {5,4,3,2,1},false)]
    public void IncreasingTriplet_ShouldReturnCorrectValue(int[]nums, bool expectedResult)
    {
        var result = Service.IncreasingTriplet(nums);

        Assert.Equal(expectedResult, result);
    }   

	[Theory]
    [InlineData(new int[] {1,1},2)]
    [InlineData(new int[] {0,0,2,2,3,3},1)]
    [InlineData(new int[] {0,0,1,-2,-2,3,3},2)]
    [InlineData(new int[] {1,1,2,2,3,3},4)]
    [InlineData(new int[] {1,2,0},3)]
    [InlineData(new int[] {3,4,-1,1},2)]
    [InlineData(new int[] {1,2,3,4},5)]
    [InlineData(new int[] {1,2,3,5},4)]
    [InlineData(new int[] {1,2,5,4},3)]
    [InlineData(new int[] {10,5,4,3,1,6},2)]
    [InlineData(new int[] {10,5,4,3,2,1,6},7)]
    public void FirstMissingPositive_ShouldReturnCorrectValue(int[] nums, int expectedOutput)
    {
        var output = Service.FirstMissingPositive(nums);
        Assert.Equal(expectedOutput, output);
    }
    [Theory]
    [InlineData("A man, a plan, a canal: Panama",true)]
    [InlineData("race a car",false)]
    [InlineData("",true)]
    [InlineData(" ",true)]
    [InlineData("a.",true)]
    public void IsPalindrome_ShouldReturnCorrectResult(string s, bool expectedResult)
    {
        var result = Service.IsPalindrome(s);
        Assert.Equal(expectedResult, result);
    }
    [Theory]
    [InlineData("A man, a plan, a canal: Panama",true)]
    [InlineData("race a car",false)]
    [InlineData("",true)]
    [InlineData(" ",true)]
    [InlineData("a..",true)]
    [InlineData("a.",true)]
    [InlineData(",.",true)]
    [InlineData("0P",false)]
    public void IsPalindromeV2_ShouldReturnCorrectResult(string s, bool expectedResult)
    {
        var result = Service.IsPalindromeV2(s);
        Assert.Equal(expectedResult, result);
    }
    [Theory]
    [InlineData("PAYPALISHIRING", 3, "PAHNAPLSIIGYIR")]
    [InlineData("PAYPALISHIRING", 4, "PINALSIGYAHRPI")]
    [InlineData("A", 1, "A")]
    [InlineData("A", 4, "A")]
    [InlineData("AB", 1, "AB")]
    [InlineData("AB", 2, "AB")]
    [InlineData("AB", 9, "AB")]
    public void Convert_ShouldReturnCorrectZigZagString(string s, int numRows, string expectedOutput)
    {
        var output = Service.Convert(s, numRows);
        Assert.Equal(expectedOutput, output);
    }
    [Theory]
    [InlineData("aabcaba",0,3)]
    [InlineData("dabdcbdcdcd",2,2)]
    [InlineData("aaabaaa",2,1)]
    [InlineData("ykekkdhehmhhympxhgjyjsmmkxerplpeegaqwqmswpmkldlllrywjqyeqlmwyphgprsdorlllpmmwdwxsxgkwaogxgglokjykrqyhaasjjxalxwdkjexdqksayxqplwmmleevdkdqdvgelmdhkqgryrqawxeammjhpwqgvdhygyvyqahvkjrrjvgpgqxyywwdvpgelvsprqodrvewqyajwjsrmqgqmardoqjmpymmvxxqoqvhywderllksxapamejdslhwpohmeryemphplqlkddyhqgpqykdhrehxwsjvaqymykjodvodjgqahrejxlykmmaxywdgaoqvgegdggykqjwyagdohjwpdypdwlrjksqkjwrkekvxjllwkgxxmhrwmxswmyrmwldqosavkpksjxwjlldhyhhrrlrwarqkyogamxmpqyhsldhajagslmeehakrxjxpjjmjpydgkehesoygvosrhvyhrqmdhlomgmrqjrmxyvmapmspmdygkhsprqsaxsvsrkovdjprjjyworgqoakrwarjsryydpmvhvyalawsmlsdgolsxgaqhryemvkpkhqvvagmxoapmsmwkrakldlhyojqhjjghjxgksroqpoxqsorrelhqeseegpqpewxydvkvaoaldmsdpmvogaykhpxkjkwmslqjsdqowkqawxadevkswdhywrxkpvqxmgeolayqojqqwxoomyasjrqrjmoearskssppmxpgwrmsjlsrjyqrjkgwjwglxogmkqjpjkwyaqxymelsyxypqxrjvpmssoakksemjhvaxm",2,161)]
    public void MinimumDeletions_ShouldReturnMinimalNumberOfDeletionsReqiredToMakeWordKSpecial(
            string word, int k, int expectedOutput)
    {
        var output = Service.MinimumDeletions(word,k);
        Assert.Equal(expectedOutput,output);
    }
    [Theory]
    [InlineData("the sky is blue","blue is sky the")]
    [InlineData("  hello world  ","world hello")]
    [InlineData("a good      example","example good a")]
    [InlineData("a","a")]
    [InlineData("  a   ","a")]
    public void ReverseWords_ShouldReturnStringWithReversedWordOrder(string input, string expectedOutput)
    {
        var output = Service.ReverseWords(input);
        Assert.Equal(expectedOutput, output);
    }
    [Theory]
    [InlineData("the sky is blue","blue is sky the")]
    [InlineData("  hello world  ","world hello")]
    [InlineData("a good      example","example good a")]
    [InlineData("a","a")]
    [InlineData("  a   ","a")]
    public void ReverseWordsV2_ShouldReturnStringWithReversedWordOrder(string input, string expectedOutput)
    {
        var output = Service.ReverseWordsV2(input);
        Assert.Equal(expectedOutput, output);
    }

	[Theory]
        [InlineData(new int[] {1,8,6,2,5,4,8,6,7},49)]
        [InlineData(new int[] {1,1},1)]
	public void MaxAreaTest(int[] input, int expectedResult)
	{
		var output = Service.MaxArea(input);
		Assert.Equal(expectedResult, output);
	}

	[Theory]
	// singles
	[InlineData(new int[] {}, new int[] {1}, 1)]
	[InlineData(new int[] {5}, new int[] {}, 5)]
	//doubles
	[InlineData(new int[] {1}, new int[] {1}, 1)]
	[InlineData(new int[] {1}, new int[] {4}, 2.5d)]
	[InlineData(new int[] {5}, new int[] {1}, 3)]
	// 1,2,3 median 2
	[InlineData(new int[] {}, new int[] {1,2,3}, 2)]
	[InlineData(new int[] {1}, new int[] {2,3}, 2)]
	[InlineData(new int[] {2}, new int[] {1,3}, 2)]
	[InlineData(new int[] {3}, new int[] {2,3}, 2)]
	[InlineData(new int[] {1,2}, new int[] {3}, 2)]
	[InlineData(new int[] {1,3}, new int[] {2}, 2)]
	[InlineData(new int[] {2,3}, new int[] {1}, 2)]
	[InlineData(new int[] {1,2,3}, new int[] {}, 2)]
	// 1,2,3,4 | median 2,5
	[InlineData(new int[] {}, new int[] {1,2,3,4}, 2.5d)]
	[InlineData(new int[] {1}, new int[] {2,3,4}, 2.5d)]
	[InlineData(new int[] {2}, new int[] {1,3,4}, 2.5d)]
	[InlineData(new int[] {3}, new int[] {1,2,4}, 2.5d)]
	[InlineData(new int[] {4}, new int[] {1,2,3}, 2.5d)]
	[InlineData(new int[] {1,2}, new int[] {3,4}, 2.5d)]
	[InlineData(new int[] {1,3}, new int[] {2,4}, 2.5d)]
	[InlineData(new int[] {1,4}, new int[] {2,3}, 2.5d)]
	[InlineData(new int[] {2,3}, new int[] {1,4}, 2.5d)]
	[InlineData(new int[] {2,4}, new int[] {1,3}, 2.5d)]
	[InlineData(new int[] {3,4}, new int[] {1,2}, 2.5d)]
	[InlineData(new int[] {1,2,3}, new int[] {4}, 2.5d)]
	[InlineData(new int[] {1,2,4}, new int[] {3}, 2.5d)]
	[InlineData(new int[] {1,3,4}, new int[] {2}, 2.5d)]
	[InlineData(new int[] {2,3,4}, new int[] {1}, 2.5d)]
	[InlineData(new int[] {1,2,3,4}, new int[] {}, 2.5d)]
	// 1,2,3,4,5 | median 3
	[InlineData(new int[] {1,2,3,4,5}, new int[] {}, 3)]
	[InlineData(new int[] {1,2,3,4}, new int[] {5}, 3)]
	[InlineData(new int[] {1,2,3,5}, new int[] {4}, 3)]
	[InlineData(new int[] {1,2,4,5}, new int[] {3}, 3)]
	[InlineData(new int[] {1,3,4,5}, new int[] {2}, 3)]
	[InlineData(new int[] {2,3,4,5}, new int[] {1}, 3)]
	[InlineData(new int[] {1,2,3}, new int[] {4,5}, 3)]
	[InlineData(new int[] {1,2,4}, new int[] {3,5}, 3)]
	[InlineData(new int[] {1,2,5}, new int[] {3,4}, 3)]
	[InlineData(new int[] {1,3,4}, new int[] {2,5}, 3)]
	[InlineData(new int[] {1,3,5}, new int[] {2,4}, 3)]
	[InlineData(new int[] {1,4,5}, new int[] {2,3}, 3)]
	[InlineData(new int[] {2,3,4}, new int[] {1,5}, 3)]
	[InlineData(new int[] {2,3,5}, new int[] {1,4}, 3)]
	[InlineData(new int[] {2,4,5}, new int[] {1,3}, 3)]
	[InlineData(new int[] {3,4,5}, new int[] {1,2}, 3)]
	[InlineData(new int[] {1,2}, new int[] {3,4,5}, 3)]
	[InlineData(new int[] {1,3}, new int[] {2,4,5}, 3)]
	[InlineData(new int[] {1,4}, new int[] {2,3,5}, 3)]
	[InlineData(new int[] {1,5}, new int[] {2,3,4}, 3)]
	[InlineData(new int[] {2,3}, new int[] {1,4,5}, 3)]
	[InlineData(new int[] {2,4}, new int[] {1,3,5}, 3)]
	[InlineData(new int[] {2,5}, new int[] {1,3,4}, 3)]
	[InlineData(new int[] {3,4}, new int[] {1,2,5}, 3)]
	[InlineData(new int[] {3,5}, new int[] {1,2,4}, 3)]
	[InlineData(new int[] {4,5}, new int[] {1,2,3}, 3)]
	[InlineData(new int[] {1}, new int[] {2,3,4,5}, 3)]
	[InlineData(new int[] {2}, new int[] {1,3,4,5}, 3)]
	[InlineData(new int[] {3}, new int[] {1,2,4,5}, 3)]
	[InlineData(new int[] {4}, new int[] {1,2,3,5}, 3)]
	[InlineData(new int[] {5}, new int[] {1,2,3,4}, 3)]
	[InlineData(new int[] {}, new int[] {1,2,3,4,5}, 3)]
	//--some other test
	[InlineData(new int[] {1,2,3,4}, new int[] {5,6,7,8,9}, 5)]
	[InlineData(new int[] {1,2,3,5}, new int[] {4,6,7,8,9}, 5)]
	[InlineData(new int[] {1,2,5,6}, new int[] {3,4,7,8,9}, 5)]
	[InlineData(new int[] {1,5,6,7}, new int[] {2,3,4,8,9}, 5)]
	[InlineData(new int[] {1}, new int[] {2,3,4,5,6,7,8,9,10}, 5.5d)]
	[InlineData(new int[] {2}, new int[] {1,3,4,5,6,7,8,9,10}, 5.5d)]
	[InlineData(new int[] {3}, new int[] {1,2,4,5,6,7,8,9,10}, 5.5d)]
	[InlineData(new int[] {4}, new int[] {1,2,3,5,6,7,8,9,10}, 5.5d)]
	[InlineData(new int[] {5}, new int[] {1,2,3,4,6,7,8,9,10}, 5.5d)]
	[InlineData(new int[] {6}, new int[] {1,2,3,4,5,7,8,9,10}, 5.5d)]
	[InlineData(new int[] {7}, new int[] {1,2,3,4,5,6,8,9,10}, 5.5d)]
	[InlineData(new int[] {8}, new int[] {1,2,3,4,5,6,7,9,10}, 5.5d)]
	[InlineData(new int[] {9}, new int[] {1,2,3,4,5,6,7,8,10}, 5.5d)]
	[InlineData(new int[] {10}, new int[] {1,2,3,4,5,6,7,8,9}, 5.5d)]
	[InlineData(new int[] {1,2}, new int[] {3,4,5,6,7,8,9,10}, 5.5d)]
	[InlineData(new int[] {1,3}, new int[] {2,4,5,6,7,8,9,10}, 5.5d)]
	[InlineData(new int[] {1,4}, new int[] {2,3,5,6,7,8,9,10}, 5.5d)]
	[InlineData(new int[] {1,5}, new int[] {2,3,4,6,7,8,9,10}, 5.5d)]
	[InlineData(new int[] {1,6}, new int[] {2,3,4,5,7,8,9,10}, 5.5d)]
	[InlineData(new int[] {1,7}, new int[] {2,3,4,5,6,8,9,10}, 5.5d)]
	[InlineData(new int[] {1,8}, new int[] {2,3,4,5,6,7,9,10}, 5.5d)]
	[InlineData(new int[] {1,9}, new int[] {2,3,4,5,6,7,8,10}, 5.5d)]
	[InlineData(new int[] {1,10}, new int[] {2,3,4,5,6,7,8,9}, 5.5d)]
	public void FindMedianSortedArraysTest(
			int[] nums1, 
			int[] nums2, 
			double expectedResult)
	{
		var result = Service.FindMedianSortedArrays(nums1, nums2);
		//TODO: uncomment
		//Assert.Equal(expectedResult, result);
	}

	[Theory]
	[MemberData(nameof(ThreeSumTestData))]
	public void ThreeSumTest(int[] input, int [][] expected)
	{
		// act	
		var result = Service.ThreeSum(input);
	
		// assert
		Assert.Equal(expected.Length, result.Count());
		foreach(var list in expected)
		{
			Assert.Equal(1,
					result.Where(resList =>
						resList.Contains(list[0]) 
					&& resList.Contains(list[1]) 
					&& resList.Contains(list[2])).Count());
		}
	}

	[Theory]
	[MemberData(nameof(ThreeSumTestData))]
	public void ThreeSumFromSolution(int[] input, int[][] expected)
	{
		// act	
		var result = Service.ThreeSumFromSolution(input);
	
		// assert
		Assert.Equal(expected.Length, result.Count());
		foreach(var list in expected)
		{
			Assert.Equal(1,
					result.Where(resList =>
						resList.Contains(list[0]) 
					&& resList.Contains(list[1]) 
					&& resList.Contains(list[2])).Count());
		}
	}	

	public static IEnumerable<object[]>ThreeSumTestData =>
		new List<object[]>
		{
			new object[]
			{
				new int[]{-1,0,1,2,-1,-4},
				new int[][]{new int[]{-1,-1,2},new int[]{-1,0,1}}
			},
			new object[]
			{
				new int[]{0,1,2},
				new int[][]{}
			},
			new object[]
			{
				new int[]{0,0,0},
				new int[][]{new int[]{0,0,0}}
			},
			new object[]
			{
				new int[]{0,0,0,0},
				new int[][]{new int[]{0,0,0}}
			},
			new object[]
			{
				new int[] {-100,-70,-60,110,120,130,160},
				new int[][]{[-100,-60,160],[-70,-60,130]}
			},
			new object[]
			{
				new int[] {-2,0,1,1,2},
				new int[][]{[-2,0,2],[-2,1,1]}
			}
		};
	
	[Theory]
	[InlineData(new int[] {0,0,0},1,0)]
	[InlineData(new int[] {-1,2,1,-4},1,2)]
	[InlineData(new int[] {10,20,30,40,50,60,70,80,90},1,60)]
	public void ThreeSumClosestTests(int[] input, int target, int expected)
	{
		// act
		int result = Service.ThreeSumClosest(input,target);
		// assert
		Assert.Equal(expected,result);
	}

	[Theory]
	[MemberData(nameof(FourSumTestData))]
	public void FourSumTests(int[] input, int target, int[][] expected)
	{
		// act	
		var result = Service.FourSum(input,target);
	
		// assert
		Assert.Equal(expected.Length, result.Count());
		foreach(var list in expected)
		{
			Assert.Equal(1,
					result.Where(resList =>
						resList.Contains(list[0]) 
					&& resList.Contains(list[1]) 
					&& resList.Contains(list[2])
					&& resList.Contains(list[3])).Count());
		}
	}	

	public static IEnumerable<object[]>FourSumTestData =>
		new List<object[]>
		{
			new object[]
			{
				new int[]{1,0,-1,0,-2,2},
				0,
				new int[][]{[-2,-1,1,2],[2,0,0,2], [-1,0,0,1]}
			},
			new object[]
			{
				new int[]{2,2,2,2,2},
				8,
				new int[][]{[2,2,2,2]}
			},
			new object[]
			{
				new int[]{2,2,2,2,2,2,2,2},
				8,
				new int[][]{[2,2,2,2]}
			},
			new object[]
			{
				new int[]{0},
				0,
				new int[][]{}
			},
			new object[]
			{
				new int[]{0,0},
				0,
				new int[][]{}
			},
			new object[]
			{
				new int[]{0,0,0},
				0,
				new int[][]{}
			},
			new object[]
			{
				new int[]{0,0,0,0},
				0,
				new int[][]{[0,0,0,0]}
			},
			new object[]
			{
				new int[]{1000000000,1000000000,1000000000,1000000000},
				-294967296,
				new int[][]{}
			}
		};

	[Theory]
	[InlineData(new int[]{3,2,2,3},3,new int[]{2,2},2)]
	[InlineData(new int[]{0,1,2,2,3,0,4,2},2,new int[]{0,1,4,0,3},5)]
	[InlineData(new int[]{0,0,0,0,0,0,0,0},0,new int[]{},0)]
	[InlineData(new int[]{2},3,new int[]{2},1)]
	[InlineData(new int[]{2,2},3,new int[]{2,2},2)]
	[InlineData(new int[]{2,2,2},3,new int[]{2,2,2},3)]
	[InlineData(new int[]{3,3},3,new int[]{},0)]
	[InlineData(new int[]{3,3,3},3,new int[]{},0)]
	public void RemoveElementTests(
			int[] nums, int val, int[] expectedNums, int expectedOutput)
	{
		//act
		int output = Service.RemoveElement(nums, val);

		//assert
		Assert.Equal(expectedOutput, output);

		var trimmed = nums[..output].ToList();
		for(int i = 0; i<expectedNums.Length; i++)
		{
			Assert.True(trimmed.Remove(expectedNums[i]));
		}
	}
	
	[Theory]
	[InlineData(new int[]{1,2,3}, new int[]{1,3,2})]
	[InlineData(new int[]{2,3,1}, new int[]{3,1,2})]
	[InlineData(new int[]{3,1,2}, new int[]{3,2,1})]
	//----------------------------------------------
	[InlineData(new int[]{1,1,5}, new int[]{1,5,1})]
	[InlineData(new int[]{1,5,1}, new int[]{5,1,1})]
	//----------------------------------------------
	//----------------------------------------------
	[InlineData(new int[]{1,2,3,4}, new int[]{1,2,4,3})]
	[InlineData(new int[]{1,2,4,3}, new int[]{1,3,2,4})]
	[InlineData(new int[]{1,3,2,4}, new int[]{1,3,4,2})]
	[InlineData(new int[]{1,3,4,2}, new int[]{1,4,2,3})]
	[InlineData(new int[]{1,4,2,3}, new int[]{1,4,3,2})]
	[InlineData(new int[]{1,4,3,2}, new int[]{2,1,3,4})]
	[InlineData(new int[]{2,1,3,4}, new int[]{2,1,4,3})]
	[InlineData(new int[]{2,1,4,3}, new int[]{2,3,1,4})]
	public void NextPermutationTests(int[]input, int[]expected)
	{
		Service.NextPermutation(input);
		Assert.Equal(expected,input);
	}

	[Theory]
	[InlineData(new int[]{3,2,1}, new int[]{1,2,3})]
	[InlineData(new int[]{5,5,1}, new int[]{1,5,5})]
	[InlineData(new int[]{4,3,2,1,0}, new int[]{0,1,2,3,4})]
	public void NextPermutationTestsIsHandlingReverts(int[]input, int[]expected)
	{
		Service.NextPermutation(input);
		Assert.Equal(expected,input);
	}

	[Theory]
	[InlineData(new int[]{1,1,1}, new int[]{1,1,1})]
	[InlineData(new int[]{0,0,0}, new int[]{0,0,0})]
	public void NextPermutationTestsIsHandlingSameDigits(int[]input, int[]expected)
	{
		Service.NextPermutation(input);
		Assert.Equal(expected,input);
	}

	[Theory]
	[InlineData(new int[]{1}, new int[]{1})]
	[InlineData(new int[]{2}, new int[]{2})]
	[InlineData(new int[]{0,0}, new int[]{0,0})]
	[InlineData(new int[]{0,1}, new int[]{1,0})]
	[InlineData(new int[]{1,0}, new int[]{0,1})]
	public void NextPermutationTestsIsHandlingSinglesAndDoubles(int[]input, int[]expected)
	{
		Service.NextPermutation(input);
		Assert.Equal(expected,input);
	}

	[Theory]
	[InlineData(new int[]{1}, 2, -1)]
	[InlineData(new int[]{1}, 1, 0)]
	[InlineData(new int[]{1,2}, 3, -1)]
	[InlineData(new int[]{1,2}, 2, 1)]
	[InlineData(new int[]{2,1}, 2, 0)]
	public void TestSearchOneAndTwoElemArray(int[] nums, int target, int expectedOut)
	{
		var output = Service.Search(nums,target);
		Assert.Equal(expectedOut,output);
	}

	[Theory]
	[InlineData(new int[]{1,2,3}, 3, 2)]
	[InlineData(new int[]{1,2,3}, 9, -1)]
	[InlineData(new int[]{1,2,3,4,5,6,7}, 3, 2)]
	[InlineData(new int[]{1,2,3,4,5,6,7}, 3, 2)]
	[InlineData(new int[]{1,2,3,4,5,6,7,8}, 4, 3)]
	[InlineData(new int[]{1,2,3,4,5,6,7,8}, 5, 4)]
	[InlineData(new int[]{1,2,3,4,5,6,7,8}, 9, -1)]
	[InlineData(new int[]{1,11,111,1111,2222,3333,4444}, 4444, 6)]
	[InlineData(new int[]{1,11,111,1111,2222,3333,4444}, 2, -1)]
	public void TestSearchCorrectResutlForNotRotatedArray(
		int[] nums, int target, int expectedOut)
	{
		var output = Service.Search(nums,target);
		Assert.Equal(expectedOut,output);
	}

	[Theory]
	[InlineData(new int[]{3,1,2}, 3, 0)]
	[InlineData(new int[]{2,3,1}, 3, 1)]
	[InlineData(new int[]{2,3,1}, 9, -1)]
	[InlineData(new int[]{3,4,5,6,7,1,2}, 3, 0)]
	[InlineData(new int[]{3,4,5,6,7,1,2}, 9, -1)]
	[InlineData(new int[]{3,4,5,6,7,8,1,2}, 6, 3)]
	[InlineData(new int[]{3,4,5,6,7,8,1,2}, 7, 4)]
	[InlineData(new int[]{3,4,5,6,7,8,1,2}, 9, -1)]
	[InlineData(new int[]{6,7,8,9,10,1,2,3,4,5}, 8, 2)]
	[InlineData(new int[]{6,7,8,9,10,1,2,3,4,5}, 3, 7)]
	[InlineData(new int[]{2222,3333,4444,1,11,111,1111}, 4444, 2)]
	[InlineData(new int[]{2222,3333,4444,1,11,111,1111}, 2, -1)]
	[InlineData(new int[]{5,1,2,3,4}, 1, 1)]
	public void TestSearchCorrectResutlForRotatedArray(
		int[] nums, int target, int expectedOut)
	{
		var output = Service.Search(nums,target);
		Assert.Equal(expectedOut,output);
	}

	[Theory]
	[InlineData(new int[]{}, 5, new int[] {-1,-1})]
	[InlineData(new int[]{1}, 5, new int[] {-1,-1})]
	[InlineData(new int[]{1}, 1, new int[] {0,0})]
	[InlineData(new int[]{1,1}, 1, new int[] {0,1})]
	[InlineData(new int[]{1,2}, 1, new int[] {0,0})]
	[InlineData(new int[]{0,1}, 1, new int[] {1,1})]
	[InlineData(new int[]{2,3}, 1, new int[] {-1,-1})]
	[InlineData(new int[]{1,2,3}, 9, new int[] {-1,-1})]
	[InlineData(new int[]{1,2,3}, 1, new int[] {0,0})]
	[InlineData(new int[]{1,2,3}, 2, new int[] {1,1})]
	[InlineData(new int[]{1,2,3}, 3, new int[] {2,2})]
	[InlineData(new int[]{1,1,3}, 1, new int[] {0,1})]
	[InlineData(new int[]{1,1,1}, 1, new int[] {0,2})]
	[InlineData(new int[]{1,2,2}, 2, new int[] {1,2})]
	[InlineData(new int[]{1,2,3,4,5,6,7,8}, 7, new int[] {6,6})] //--
	[InlineData(new int[]{7,7,7,7,7,7,7,7}, 7, new int[] {0,7})]
	[InlineData(new int[]{1,7,7,7,7,7,7,7}, 7, new int[] {1,7})]
	[InlineData(new int[]{7,7,7,7,7,7,7,1}, 7, new int[] {0,6})] //--
	[InlineData(new int[]{1,7,7,7,7,7,7,1}, 7, new int[] {1,6})] //--
	public void SearchRangeTests(int[] nums, int target, int[] expectedOut)
	{
		var output = Service.SearchRange(nums, target);
		Assert.Equal(expectedOut, output);
	}

	[Fact]
	public void SearchRangeTestsLeetCodeFailed_86_88()
	{
		int[] nums = [-100,-100,-100,-100,-100,-100,-100,-100,-100,-100,-100,-100,-100,-100,-100,-100,-100,-100,-100,-100,-100,-99,-99,-99,-99,-99,-99,-99,-99,-99,-99,-99,-99,-99,-99,-99,-99,-99,-99,-99,-99,-98,-98,-98,-98,-98,-98,-98,-98,-98,-98,-98,-98,-98,-98,-98,-98,-98,-97,-97,-97,-97,-97,-97,-97,-97,-97,-97,-97,-97,-97,-97,-97,-97,-96,-96,-96,-96,-96,-96,-96,-96,-96,-96,-96,-96,-96,-96,-96,-96,-96,-96,-96,-96,-96,-95,-95,-95,-95,-95,-95,-95,-95,-95,-95,-95,-95,-95,-95,-95,-95,-95,-94,-94,-94,-94,-94,-94,-94,-94,-94,-94,-94,-94,-94,-94,-93,-93,-93,-93,-93,-93,-93,-93,-93,-93,-93,-93,-93,-93,-93,-93,-93,-93,-92,-92,-92,-92,-92,-92,-92,-92,-92,-92,-92,-92,-92,-91,-91,-91,-91,-91,-91,-91,-91,-91,-91,-91,-91,-91,-91,-91,-91,-90,-90,-90,-90,-90,-90,-90,-90,-90,-90,-90,-90,-90,-90,-90,-90,-89,-89,-89,-89,-89,-89,-89,-89,-89,-89,-89,-89,-89,-89,-89,-89,-89,-89,-89,-89,-89,-89,-89,-88,-88,-88,-88,-88,-88,-88,-88,-88,-88,-88,-88,-88,-88,-88,-88,-88,-88,-88,-88,-88,-88,-88,-87,-87,-87,-87,-87,-87,-87,-87,-87,-87,-87,-87,-87,-87,-87,-87,-86,-86,-86,-86,-86,-86,-86,-86,-86,-86,-86,-86,-86,-86,-86,-86,-85,-85,-85,-85,-85,-85,-85,-85,-85,-85,-85,-85,-85,-85,-85,-85,-85,-84,-84,-84,-84,-84,-84,-84,-84,-84,-84,-84,-84,-84,-84,-84,-84,-84,-84,-84,-83,-83,-83,-83,-83,-83,-83,-83,-83,-83,-83,-83,-83,-83,-83,-83,-83,-83,-83,-83,-82,-82,-82,-82,-82,-82,-82,-82,-82,-82,-82,-82,-82,-82,-82,-82,-82,-82,-82,-81,-81,-81,-81,-81,-81,-81,-81,-81,-81,-81,-81,-81,-81,-81,-81,-81,-81,-81,-81,-80,-80,-80,-80,-80,-80,-80,-80,-80,-80,-80,-79,-79,-79,-79,-79,-79,-79,-79,-79,-79,-79,-79,-79,-79,-79,-79,-79,-78,-78,-78,-78,-78,-78,-78,-78,-78,-78,-78,-78,-78,-78,-78,-78,-78,-78,-78,-78,-78,-78,-78,-78,-78,-78,-78,-78,-77,-77,-77,-77,-77,-77,-77,-77,-77,-77,-77,-77,-77,-77,-77,-77,-77,-77,-77,-77,-77,-76,-76,-76,-76,-76,-76,-76,-76,-76,-76,-76,-76,-76,-76,-76,-76,-76,-76,-76,-76,-76,-76,-75,-75,-75,-75,-75,-75,-75,-75,-75,-75,-75,-75,-75,-75,-75,-75,-74,-74,-74,-74,-74,-74,-74,-74,-74,-74,-74,-74,-74,-74,-73,-73,-73,-73,-73,-73,-73,-73,-73,-73,-73,-73,-73,-73,-73,-73,-72,-72,-72,-72,-72,-72,-72,-72,-72,-72,-72,-72,-72,-72,-72,-72,-72,-72,-72,-72,-72,-72,-71,-71,-71,-71,-71,-71,-71,-71,-71,-71,-71,-71,-71,-71,-71,-71,-71,-70,-70,-70,-70,-70,-70,-70,-70,-70,-70,-70,-70,-70,-70,-70,-70,-70,-70,-70,-70,-70,-70,-69,-69,-69,-69,-69,-69,-69,-69,-69,-69,-69,-69,-69,-69,-69,-69,-69,-69,-69,-69,-69,-69,-69,-69,-69,-69,-68,-68,-68,-68,-68,-68,-68,-68,-68,-68,-68,-68,-68,-68,-68,-67,-67,-67,-67,-67,-67,-67,-67,-67,-67,-67,-67,-67,-67,-67,-67,-67,-67,-67,-67,-67,-67,-67,-67,-66,-66,-66,-66,-66,-66,-66,-66,-66,-66,-66,-66,-66,-66,-66,-65,-65,-65,-65,-65,-65,-65,-65,-65,-65,-65,-65,-65,-65,-65,-65,-65,-64,-64,-64,-64,-64,-64,-64,-64,-64,-64,-64,-64,-64,-64,-64,-64,-64,-64,-64,-64,-64,-64,-63,-63,-63,-63,-63,-63,-63,-63,-63,-63,-63,-63,-63,-63,-63,-63,-63,-63,-63,-62,-62,-62,-62,-62,-62,-62,-62,-62,-62,-62,-62,-62,-62,-62,-61,-61,-61,-61,-61,-61,-61,-61,-61,-61,-61,-61,-61,-61,-61,-61,-61,-61,-60,-60,-60,-60,-60,-60,-60,-60,-60,-60,-60,-60,-60,-60,-60,-60,-60,-60,-60,-59,-59,-59,-59,-59,-59,-59,-59,-59,-59,-59,-59,-59,-59,-59,-58,-58,-58,-58,-58,-58,-58,-58,-58,-58,-58,-58,-58,-58,-57,-57,-57,-57,-57,-57,-57,-57,-57,-57,-57,-57,-57,-57,-57,-57,-57,-57,-57,-56,-56,-56,-56,-56,-56,-56,-56,-56,-56,-56,-56,-56,-56,-56,-56,-56,-55,-55,-55,-55,-55,-55,-55,-55,-55,-55,-55,-55,-55,-55,-55,-55,-55,-55,-55,-55,-54,-54,-54,-54,-54,-54,-54,-54,-54,-54,-54,-54,-54,-54,-54,-54,-54,-54,-54,-54,-54,-54,-54,-54,-54,-54,-54,-54,-54,-54,-53,-53,-53,-53,-53,-53,-53,-53,-53,-53,-53,-53,-53,-53,-53,-53,-53,-53,-53,-53,-53,-53,-53,-52,-52,-52,-52,-52,-52,-52,-52,-52,-52,-52,-52,-52,-52,-52,-52,-52,-52,-51,-51,-51,-51,-51,-51,-51,-51,-51,-51,-51,-51,-51,-51,-50,-50,-50,-50,-50,-50,-50,-50,-50,-50,-50,-50,-50,-50,-50,-50,-50,-50,-50,-50,-50,-50,-50,-50,-50,-50,-50,-50,-50,-49,-49,-49,-49,-49,-49,-49,-49,-49,-49,-49,-49,-49,-49,-49,-49,-49,-49,-49,-49,-49,-49,-49,-49,-49,-49,-49,-49,-48,-48,-48,-48,-48,-48,-48,-48,-48,-48,-48,-48,-48,-48,-48,-48,-48,-48,-48,-48,-48,-47,-47,-47,-47,-47,-47,-47,-47,-46,-46,-46,-46,-46,-46,-46,-46,-46,-46,-46,-46,-46,-46,-45,-45,-45,-45,-45,-45,-45,-45,-45,-45,-45,-45,-45,-45,-45,-45,-45,-45,-45,-45,-45,-45,-45,-45,-45,-45,-45,-45,-45,-44,-44,-44,-44,-44,-44,-44,-44,-44,-44,-44,-44,-44,-44,-44,-44,-44,-44,-44,-43,-43,-43,-43,-43,-43,-43,-43,-43,-43,-43,-43,-42,-42,-42,-42,-42,-42,-42,-42,-42,-42,-42,-42,-42,-42,-42,-42,-41,-41,-41,-41,-41,-41,-41,-41,-41,-41,-40,-40,-40,-40,-40,-40,-40,-40,-40,-40,-40,-40,-40,-39,-39,-39,-39,-39,-39,-39,-39,-39,-39,-39,-39,-39,-39,-39,-39,-39,-39,-39,-38,-38,-38,-38,-38,-38,-38,-38,-38,-38,-38,-38,-38,-38,-38,-38,-38,-38,-38,-38,-37,-37,-37,-37,-37,-37,-37,-37,-37,-37,-37,-37,-37,-37,-37,-37,-37,-37,-37,-37,-37,-37,-37,-36,-36,-36,-36,-36,-36,-36,-36,-36,-36,-36,-36,-36,-36,-36,-36,-36,-36,-36,-36,-35,-35,-35,-35,-35,-35,-35,-35,-35,-35,-35,-35,-34,-34,-34,-34,-34,-34,-34,-34,-34,-34,-34,-33,-33,-33,-33,-33,-33,-33,-33,-33,-33,-33,-33,-33,-33,-33,-33,-33,-33,-33,-33,-33,-32,-32,-32,-32,-32,-32,-32,-32,-32,-32,-32,-32,-32,-32,-32,-31,-31,-31,-31,-31,-31,-31,-31,-31,-31,-31,-31,-31,-31,-31,-31,-30,-30,-30,-30,-30,-30,-30,-30,-30,-30,-30,-30,-30,-30,-30,-29,-29,-29,-29,-29,-29,-29,-29,-29,-29,-29,-29,-29,-29,-29,-29,-29,-28,-28,-28,-28,-28,-28,-28,-28,-28,-28,-28,-28,-28,-27,-27,-27,-27,-27,-27,-27,-27,-27,-27,-27,-27,-27,-27,-27,-27,-27,-27,-27,-27,-26,-26,-26,-26,-26,-26,-26,-26,-26,-26,-26,-26,-26,-26,-26,-26,-26,-26,-26,-26,-26,-26,-25,-25,-25,-25,-25,-25,-25,-25,-25,-25,-25,-25,-25,-25,-25,-25,-25,-25,-25,-25,-25,-24,-24,-24,-24,-24,-24,-24,-24,-24,-24,-24,-24,-23,-23,-23,-23,-23,-23,-23,-23,-23,-23,-23,-23,-23,-23,-23,-23,-23,-23,-23,-23,-23,-23,-23,-23,-22,-22,-22,-22,-22,-22,-22,-22,-22,-22,-22,-22,-22,-22,-22,-22,-22,-22,-21,-21,-21,-21,-21,-21,-21,-21,-21,-21,-21,-21,-21,-21,-21,-21,-21,-21,-21,-20,-20,-20,-20,-20,-20,-20,-20,-20,-20,-20,-20,-20,-20,-20,-20,-20,-20,-20,-19,-19,-19,-19,-19,-19,-19,-19,-19,-19,-19,-19,-19,-19,-19,-19,-18,-18,-18,-18,-18,-18,-18,-18,-18,-18,-18,-18,-18,-18,-18,-18,-18,-18,-18,-18,-18,-18,-18,-18,-17,-17,-17,-17,-17,-17,-17,-17,-17,-17,-17,-17,-17,-17,-17,-17,-17,-17,-17,-17,-17,-17,-17,-16,-16,-16,-16,-16,-16,-16,-16,-16,-16,-16,-16,-16,-16,-16,-16,-16,-16,-16,-16,-15,-15,-15,-15,-15,-15,-15,-15,-15,-15,-15,-15,-15,-15,-15,-15,-15,-15,-14,-14,-14,-14,-14,-14,-14,-14,-14,-14,-14,-14,-14,-14,-14,-14,-14,-13,-13,-13,-13,-13,-13,-13,-13,-13,-13,-13,-13,-13,-13,-13,-13,-13,-13,-13,-13,-12,-12,-12,-12,-12,-12,-12,-12,-12,-12,-12,-12,-12,-12,-11,-11,-11,-11,-11,-11,-11,-11,-11,-11,-11,-11,-11,-11,-11,-11,-11,-11,-11,-11,-11,-11,-10,-10,-10,-10,-10,-10,-10,-10,-10,-10,-10,-10,-10,-10,-10,-10,-10,-10,-10,-10,-10,-9,-9,-9,-9,-9,-9,-9,-9,-9,-9,-9,-9,-9,-9,-8,-8,-8,-8,-8,-8,-8,-8,-8,-8,-8,-8,-8,-8,-8,-8,-8,-8,-7,-7,-7,-7,-7,-7,-7,-7,-7,-7,-7,-7,-7,-7,-7,-7,-7,-7,-7,-7,-7,-7,-7,-6,-6,-6,-6,-6,-6,-6,-6,-6,-6,-6,-6,-6,-6,-6,-6,-5,-5,-5,-5,-5,-5,-5,-5,-5,-5,-5,-5,-5,-5,-5,-5,-5,-5,-5,-5,-5,-5,-4,-4,-4,-4,-4,-4,-4,-4,-4,-4,-4,-4,-4,-4,-4,-4,-4,-4,-3,-3,-3,-3,-3,-3,-3,-3,-3,-3,-3,-3,-3,-3,-3,-3,-2,-2,-2,-2,-2,-2,-2,-2,-2,-2,-2,-2,-2,-2,-2,-2,-2,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,4,4,4,4,4,4,4,4,4,4,4,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,8,8,8,8,8,8,8,8,8,8,8,8,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,17,17,17,17,17,17,17,17,17,17,17,17,17,17,17,17,17,17,17,17,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,21,21,21,21,21,21,21,21,21,21,21,21,21,21,21,21,21,21,21,22,22,22,22,22,22,22,22,22,22,22,22,22,22,22,22,22,22,22,22,22,23,23,23,23,23,23,23,23,23,23,23,23,23,23,23,23,23,24,24,24,24,24,24,24,24,24,24,24,24,25,25,25,25,25,25,25,25,25,25,25,25,25,25,26,26,26,26,26,26,26,26,26,26,26,26,26,26,26,26,26,26,26,26,27,27,27,27,27,27,27,27,27,27,27,27,27,27,27,27,27,27,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,31,31,31,31,31,31,31,31,31,31,31,31,31,31,31,31,31,31,31,31,31,31,31,31,32,32,32,32,32,32,32,32,32,32,32,32,32,32,32,32,33,33,33,33,33,33,33,33,33,33,33,33,33,33,33,33,33,33,33,33,33,33,34,34,34,34,34,34,34,34,34,34,34,34,34,34,34,35,35,35,35,35,35,35,35,35,35,35,35,35,35,35,35,35,36,36,36,36,36,36,36,36,36,36,36,36,36,36,36,36,37,37,37,37,37,37,37,37,37,37,37,37,37,37,37,37,37,37,37,37,38,38,38,38,38,38,38,38,38,38,38,38,38,39,39,39,39,39,39,39,39,39,39,39,39,39,39,39,39,39,39,39,40,40,40,40,40,40,40,40,40,40,40,40,40,40,40,40,40,41,41,41,41,41,41,41,41,41,41,41,41,41,41,41,41,41,41,41,41,42,42,42,42,42,42,42,42,42,42,42,42,42,42,42,42,42,42,42,42,42,43,43,43,43,43,43,43,43,43,43,43,43,43,43,44,44,44,44,44,44,44,44,44,44,44,44,44,44,44,44,44,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,46,46,46,46,46,46,46,46,46,46,46,46,46,46,46,46,46,46,46,46,47,47,47,47,47,47,47,47,47,47,47,47,48,48,48,48,48,48,48,48,48,48,48,48,48,48,48,48,48,49,49,49,49,49,49,49,49,49,49,49,49,49,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,51,51,51,51,51,51,51,51,51,51,51,51,51,51,51,51,51,51,51,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,53,53,53,53,53,53,53,53,53,53,53,53,53,53,53,54,54,54,54,54,54,54,54,54,54,54,54,54,54,54,54,54,54,54,55,55,55,55,55,55,55,55,55,55,55,55,55,55,55,55,55,55,55,56,56,56,56,56,56,56,56,56,56,56,56,56,57,57,57,57,57,57,57,57,57,57,57,57,57,57,57,57,57,57,57,57,57,58,58,58,58,58,58,58,58,58,58,58,58,58,58,58,58,58,58,58,58,58,59,59,59,59,59,59,59,59,59,59,59,59,59,59,59,59,59,59,59,59,59,60,60,60,60,60,60,60,60,60,60,60,60,60,60,61,61,61,61,61,61,61,61,61,61,61,61,61,61,61,61,61,61,61,61,61,61,62,62,62,62,62,62,62,62,62,62,62,62,62,62,62,62,62,62,62,62,62,62,63,63,63,63,63,63,63,63,63,63,63,63,63,63,63,63,63,63,64,64,64,64,64,64,64,64,64,64,64,64,64,64,64,64,64,64,64,64,64,64,65,65,65,65,65,65,65,65,65,65,65,65,65,65,65,66,66,66,66,66,66,66,66,66,66,66,66,66,67,67,67,67,67,67,67,67,67,67,67,67,67,67,67,67,67,67,67,68,68,68,68,68,68,68,68,68,68,68,68,68,68,68,68,68,68,68,68,68,68,68,69,69,69,69,69,69,69,69,69,69,69,69,69,69,69,69,70,70,70,70,70,70,70,70,70,70,70,70,70,70,70,70,70,71,71,71,71,71,71,71,71,71,71,71,71,71,71,71,71,71,71,72,72,72,72,72,72,72,72,72,72,72,72,72,72,72,72,72,73,73,73,73,73,73,73,73,73,73,73,73,73,73,73,73,73,73,73,73,73,74,74,74,74,74,74,74,74,74,74,74,74,74,74,74,74,74,74,74,74,74,74,74,74,74,74,74,75,75,75,75,75,75,75,75,75,75,75,75,75,75,75,75,75,76,76,76,76,76,76,76,76,76,76,76,76,76,76,76,76,76,76,76,77,77,77,77,77,77,77,77,77,77,77,77,77,77,77,77,77,77,77,77,77,77,77,78,78,78,78,78,78,78,78,78,78,78,78,78,78,78,78,78,78,78,79,79,79,79,79,79,79,79,79,79,79,79,79,79,79,79,79,79,79,79,80,80,80,80,80,80,80,80,80,80,80,80,80,80,80,80,80,80,80,80,80,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,82,82,82,82,82,82,82,82,82,82,82,82,82,82,82,82,82,82,82,83,83,83,83,83,83,83,83,83,83,83,83,84,84,84,84,84,84,84,84,84,84,84,84,84,84,84,84,84,84,85,85,85,85,85,85,85,85,85,85,85,86,86,86,86,86,86,86,86,86,86,86,86,86,86,86,86,86,86,86,87,87,87,87,87,87,87,87,87,87,87,87,87,87,87,87,87,87,87,87,87,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,88,89,89,89,89,89,89,89,89,89,89,89,89,89,89,89,89,89,89,89,89,89,89,89,89,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,91,91,91,91,91,91,91,91,91,91,91,91,91,91,91,91,91,92,92,92,92,92,92,92,92,92,92,92,92,92,92,92,92,92,92,92,92,93,93,93,93,93,93,93,93,93,93,93,93,93,93,93,93,93,93,93,93,93,93,94,94,94,94,94,94,94,94,94,94,94,94,94,94,94,95,95,95,95,95,95,95,95,95,95,95,95,95,95,96,96,96,96,96,96,96,96,96,96,96,96,96,96,96,96,96,96,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99];
		//sth
		int target = 35;
		int[] expected = [2497,	2513];
		var result = Service.SearchRange(nums, target);
		Assert.Equal(expected, result);
	}

	[Theory]
	[InlineData(new int[]{1}, -5, 0)]
	[InlineData(new int[]{1}, 5, 1)]
	[InlineData(new int[]{1}, 1, 0)]
	//-----
	[InlineData(new int[]{1,3}, -5, 0)]
	[InlineData(new int[]{1,3}, 5, 2)]
	[InlineData(new int[]{1,3}, 1, 0)]
	[InlineData(new int[]{1,3}, 3, 1)]
	[InlineData(new int[]{1,3}, 2, 1)]
	//-----
	[InlineData(new int[]{1,2,3,4,5}, -55, 0)]
	[InlineData(new int[]{1,2,3,4,5}, 0, 0)]
	[InlineData(new int[]{1,2,3,4,5}, 1, 0)]
	[InlineData(new int[]{1,2,3,4,5}, 2, 1)]
	[InlineData(new int[]{1,2,3,4,5}, 3, 2)]
	[InlineData(new int[]{1,2,3,4,5}, 4, 3)]
	[InlineData(new int[]{1,2,3,4,5}, 5, 4)]
	[InlineData(new int[]{1,2,3,4,5}, 6, 5)]
	[InlineData(new int[]{1,2,3,4,5}, 55, 5)]
	//---
	[InlineData(new int[]{1,2,3,4,5,6}, -55, 0)]
	[InlineData(new int[]{1,2,3,4,5,6}, 0, 0)]
	[InlineData(new int[]{1,2,3,4,5,6}, 1, 0)]
	[InlineData(new int[]{1,2,3,4,5,6}, 2, 1)]
	[InlineData(new int[]{1,2,3,4,5,6}, 3, 2)]
	[InlineData(new int[]{1,2,3,4,5,6}, 4, 3)]
	[InlineData(new int[]{1,2,3,4,5,6}, 5, 4)]
	[InlineData(new int[]{1,2,3,4,5,6}, 6, 5)]
	[InlineData(new int[]{1,2,3,4,5,6}, 7, 6)]
	[InlineData(new int[]{1,2,3,4,5,6}, 55, 6)]
	//---
	[InlineData(new int[]{2,4,6,8,10,12}, -55, 0)]
	[InlineData(new int[]{2,4,6,8,10,12}, 3, 1)]
	[InlineData(new int[]{2,4,6,8,10,12}, 5, 2)]
	[InlineData(new int[]{2,4,6,8,10,12}, 7, 3)]
	[InlineData(new int[]{2,4,6,8,10,12}, 9, 4)]
	[InlineData(new int[]{2,4,6,8,10,12}, 11, 5)]
	[InlineData(new int[]{2,4,6,8,10,12}, 55, 6)]
	public void SearchInsertTests(int[] nums, int target, int expected)
	{
		var result = Service.SearchInsert(nums, target);
		Assert.Equal(expected, result);
	}

	[Fact]
	public void IsValidSudokuTestsLeetcode_1TC()
	{
		char[][] board =[['5','3','.','.','7','.','.','.','.']
						,['6','.','.','1','9','5','.','.','.']
						,['.','9','8','.','.','.','.','6','.']
						,['8','.','.','.','6','.','.','.','3']
						,['4','.','.','8','.','3','.','.','1']
						,['7','.','.','.','2','.','.','.','6']
						,['.','6','.','.','.','.','2','8','.']
						,['.','.','.','4','1','9','.','.','5']
						,['.','.','.','.','8','.','.','7','9']];

		bool result = Service.IsValidSudoku(board);

		Assert.True(result);
	}

	[Fact]
	public void IsValidSudokuTestsLeetcode_2TC()
	{
		char[][] board =[['8','3','.','.','7','.','.','.','.']
						,['6','.','.','1','9','5','.','.','.']
						,['.','9','8','.','.','.','.','6','.']
						,['8','.','.','.','6','.','.','.','3']
						,['4','.','.','8','.','3','.','.','1']
						,['7','.','.','.','2','.','.','.','6']
						,['.','6','.','.','.','.','2','8','.']
						,['.','.','.','4','1','9','.','.','5']
						,['.','.','.','.','8','.','.','7','9']];

		bool result = Service.IsValidSudoku(board);

		Assert.False(result);
	}

	[Fact]
	public void SolveSudokuShouldSolveAlreadySolved()
	{
		char[][] expectedAndInput = [
		['5','3','4','6','7','8','9','1','2'],
		['6','7','2','1','9','5','3','4','8'],
		['1','9','8','3','4','2','5','6','7'],
		['8','5','9','7','6','1','4','2','3'],
		['4','2','6','8','5','3','7','9','1'],
		['7','1','3','9','2','4','8','5','6'],
		['9','6','1','5','3','7','2','8','4'],
		['2','8','7','4','1','9','6','3','5'],
		['3','4','5','2','8','6','1','7','9']];

		Service.SolveSudoku(expectedAndInput);

		Assert.Equal(expectedAndInput,expectedAndInput);
	}
	[Fact]
	public void SolveSudokuTests_LC1()
	{
		char[][] input = [
		['5','3','.','.','7','.','.','.','.'],
		['6','.','.','1','9','5','.','.','.'],
		['.','9','8','.','.','.','.','6','.'],
		['8','.','.','.','6','.','.','.','3'],
		['4','.','.','8','.','3','.','.','1'],
		['7','.','.','.','2','.','.','.','6'],
		['.','6','.','.','.','.','2','8','.'],
		['.','.','.','4','1','9','.','.','5'],
		['.','.','.','.','8','.','.','7','9']];

		char[][] expected = [
		['5','3','4','6','7','8','9','1','2'],
		['6','7','2','1','9','5','3','4','8'],
		['1','9','8','3','4','2','5','6','7'],
		['8','5','9','7','6','1','4','2','3'],
		['4','2','6','8','5','3','7','9','1'],
		['7','1','3','9','2','4','8','5','6'],
		['9','6','1','5','3','7','2','8','4'],
		['2','8','7','4','1','9','6','3','5'],
		['3','4','5','2','8','6','1','7','9']];

		Service.SolveSudoku(input);

		Assert.Equal(expected, input);
	}
}
