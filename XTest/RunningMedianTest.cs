using HackerRank.Problem;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XTest
{
    public class RunningMedianTest
    {
        [Fact]
        public void Median_Test0()
        {
            var sol = new RunningMedian();
            var res = sol.Solve(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }).ToList();
            Assert.Equal(new List<double> { 1, 1.5, 2, 2.5, 3, 3.5, 4, 4.5, 5, 5.5 }, res);
        }

        [Fact]
        public void Median_Test1()
        {
            var sol = new RunningMedian();
            var res = sol.Solve(new List<int> { 94455, 20555, 20535, 53125 }).ToList();
            Assert.Equal(new List<double> { 94455, 57505, 20555, 36840 }, res);
        }
    }
}
