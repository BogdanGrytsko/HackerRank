using HackerRank.DataStructure;
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

        [Fact]
        public void Treap_Test()
        {
            var treap = new Treap(5) { 1, 2, 3, 4, 5};
            treap.Reverse(2, 4);
            treap.Reverse(1, 3);
            Assert.Equal(1, treap[0]);
            Assert.Equal(4, treap[1]);
            Assert.Equal(5, treap[2]);
            Assert.Equal(2, treap[3]);
            Assert.Equal(3, treap[4]);

            Assert.Equal(0, treap.GetIdx(1));
            Assert.Equal(1, treap.GetIdx(4));
            Assert.Equal(2, treap.GetIdx(5));
            Assert.Equal(3, treap.GetIdx(2));
            Assert.Equal(4, treap.GetIdx(3));
        }
    }
}
