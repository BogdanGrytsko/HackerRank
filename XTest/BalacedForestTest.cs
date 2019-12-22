using HackerRank.Problem;
using Xunit;

namespace XTest
{
    public class BalacedForestTest
    {
        [Fact]
        public void BalanceForest_Test0()
        {
            var edges = new[]
            {
                new [] {1, 2},
                new [] {1, 3},
            };
            var sol = new BalancedForest();
            var res = sol.Solve(new[] { 1, 3, 5 }, edges);
            Assert.Equal(-1, res);

        }

        [Fact]
        public void BalanceForest_Test1()
        {
            var edges = new[]
           {
                new [] {1, 2},
                new [] {2, 3},
                new [] {1, 4},
                new [] {4, 5},
                new [] {5, 6}
            };
            var sol = new BalancedForest();
            var res = sol.Solve(new[] { 1, 1, 1, 1, 10, 10 }, edges);
            Assert.Equal(6, res);
        }
    }
}
