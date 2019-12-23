using HackerRank.Problem;
using Xunit;

namespace XTest
{
    public class JennysSubtreesTest
    {
        [Fact]
        public void JennySubtrees_Test0()
        {
            var edges = new[]
            {
                new [] {1, 2},
                new [] {1, 3},
                new [] {1, 4},
                new [] {1, 5},
                new [] {2, 6},
                new [] {2, 7},
            };
            var sol = JennysSubtrees.Solve(7, 1, edges);
            Assert.Equal(3, sol);
        }

        [Fact]
        public void JennySubtrees_Test1()
        {
            var edges = new[]
            {
                new [] {1, 2},
                new [] {2, 3},
                new [] {3, 4},
                new [] {4, 5},
                new [] {5, 6},
                new [] {6, 7},
            };
            var sol = JennysSubtrees.Solve(7, 3, edges);
            Assert.Equal(4, sol);
        }

        [Fact]
        public void JennySubtrees_Test3()
        {
            var edges = new[]
            {
                new [] {1, 19},
                new [] {12, 8},
                new [] {3, 9},
                new [] {10, 2},
                new [] {13, 7},
                new [] {17, 4},
                new [] {14, 18},
                new [] {14, 16},
                new [] {20, 6},
                new [] {2, 3},
                new [] {6, 15},
                new [] {16, 1},
                new [] {5, 9},
                new [] {4, 16},
                new [] {3, 18},
                new [] {12, 4},
                new [] {11, 20},
                new [] {2, 7},
                new [] {11, 16},
            };
            var sol = JennysSubtrees.Solve(20, 9, edges);
            Assert.Equal(3, sol);
        }
    }
}
