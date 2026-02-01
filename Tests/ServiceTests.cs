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
	[InlineData(new int[]{1,2,3,4,5,6,7,8}, 7, new int[] {6,6})]
	[InlineData(new int[]{7,7,7,7,7,7,7,7}, 7, new int[] {0,7})]
	public void SearchRangeTests(int[] nums, int target, int[] expectedOut)
	{
		var output = Service.SearchRange(nums, target);
		Assert.Equal(expectedOutput, output);
	}
}
