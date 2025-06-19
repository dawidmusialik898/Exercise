using Exercise;

namespace ExerciseTests
{
    public class ArrayStringsServiceTests
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
            ArrayStringsService.MoveZeroes(input);

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
            var output = ArrayStringsService.MajorityElement(input);
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
            var output = ArrayStringsService.IsSubsequence(s, t);
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
            var output = ArrayStringsService.LongestCommonPrefix(input);
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
            ArrayStringsService.Rotate(nums, k);
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
            var output = ArrayStringsService.ProductExceptSelf(nums);
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
            var output = ArrayStringsService.ProductExceptSelfV2(nums);
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
            var output = ArrayStringsService.ProductExceptSelfV3(nums);
            //assert
            Assert.Equal(expectedOutput, output);
        }

        [Theory]
        [InlineData(new int[] {}, new int[] {}, 0)]
        [InlineData(new int[] {5}, new int[] {5}, 1)]
        public void RemoveDuplicates_ShouldReturnNumsLength_And_LeaveArrayUntouched(
                int[]inputArray, int[]expectedOutputArray, int expectedOutput)
        {
            var output = ArrayStringsService.RemoveDuplicates(inputArray);

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
            var output = ArrayStringsService.RemoveDuplicates(inputArray);

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
            var output = ArrayStringsService.MaxProfit(prices);

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
            var output = ArrayStringsService.MaxProfitII(prices);

            Assert.Equal(expectedOutput, output);
        }

        [Theory]
        [InlineData(new int[] {0},1)]
        [InlineData(new int[] {1,3,0,0,2,0,0,4},6)]
        [InlineData(new int[] {0,0,0,2,0,0},9)]
        [InlineData(new int[] {123,53,923,12},0)]
        public void ZeroFilledSubarray_ShouldReturnCountOfAllSubarrays(int[] nums, int expectedOutput)
        {
            var output = ArrayStringsService.ZeroFilledSubarray(nums);

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
            var result = ArrayStringsService.IncreasingTriplet(nums);

            Assert.Equal(expectedResult, result);
        }
    }
}
