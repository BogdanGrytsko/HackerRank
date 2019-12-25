using HackerRank.Problem;
using System.Collections.Generic;
using Xunit;

namespace XTest
{
    public class ArrayAndSimpleQueriesTest
    {
        [Fact]
        public void Array_Rotations()
        {
            var queries = new[]
            {
                new [] {1, 2, 4},
                new [] {2, 3, 5},
                new [] {1, 4, 7},
                new [] {2, 1, 4},
            };
            var sol = new ArrayAndSimpleQueries();
            var res = sol.Solve(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 }, queries);
            Assert.Equal(new List<int> { 2, 3, 6, 5, 7, 8, 4, 1 }, res);
        }
    }
}
