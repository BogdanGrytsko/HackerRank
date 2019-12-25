using HackerRank.DataStructure;
using HackerRank.Problem;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XTest
{
    public class ImplicitTreapTest
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
        public void CrazyHelix_GetIdx_Test()
        {
            int n = 500;
            var treap = new ImplicitTreap(n);
            for (int i = 1; i <= n; i++)
            {
                treap.Add(i);
            }
            var dic = treap.Nodes.ToDictionary(n => n.Value);
            for (int i = 1; i <= n; i++)
            {
                Assert.Equal(i - 1, treap.GetIdx(dic[i]));
            }
        }

        [Fact]
        public void CrazyHelix_Test()
        {
            var treap = new ImplicitTreap(5) { 1, 2, 3, 4, 5 };
            treap.Reverse(2, 4);
            var dic = treap.Nodes.ToDictionary(n => n.Value);
            Assert.Equal(0, treap.GetIdx(dic[1]));
            Assert.Equal(3, treap.GetIdx(dic[4]));
            Assert.Equal(2, treap.GetIdx(dic[5]));
            Assert.Equal(1, treap.GetIdx(dic[2]));
            Assert.Equal(4, treap.GetIdx(dic[3]));

            treap.Reverse(1, 3);
            Assert.Equal(0, treap.GetIdx(dic[1]));
            Assert.Equal(1, treap.GetIdx(dic[4]));
            Assert.Equal(2, treap.GetIdx(dic[5]));
            Assert.Equal(3, treap.GetIdx(dic[2]));
            Assert.Equal(4, treap.GetIdx(dic[3]));
        }

        [Fact]
        public void CrazyHelix_Test0()
        {
            for (int i = 0; i < 1000; i++)
            {
                var treap = new ImplicitTreap(5) { 1, 2, 3, 4, 5 };
                var dic = treap.Nodes.ToDictionary(n => n.Value);
                treap.Reverse(0, 2);
                //var x = treap[0];
                if (treap.GetIdx(dic[3]) != 0)
                {

                }
                Assert.Equal(0, treap.GetIdx(dic[3]));
            }
        }

        [Fact]
        public void Revert_and_Idx_Test()
        {
            for (int i = 0; i < 1000; i++)
            {
                var treap = new ImplicitTreap(4) { 0, 1, 2 };
                treap.Reverse(0, 2);
                Assert.Equal(2, treap.GetIdx(treap.Nodes.First()));
            }
        }
    }
}
