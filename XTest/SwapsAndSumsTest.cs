using HackerRank.Problem;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XTest
{
    public class SwapsAndSumsTest
    {
        [Fact]
        public void Swaps_Ans_Sums_Correct()
        {
            var arr = new[] { 1, 2, 3, 4, 5, 6 };
            var queries = new List<int[]>()
            {
                new int[] { 1, 2, 5},
                new int[] { 2, 2, 3},
                new int[] { 2, 3, 4},
                new int[] { 2, 4, 5},
            };
            var res = SwapsAndSums.Solve(arr, queries).ToList();
            Assert.Equal(5, res[0]);
            Assert.Equal(7, res[1]);
            Assert.Equal(9, res[2]);
        }
    }
}
