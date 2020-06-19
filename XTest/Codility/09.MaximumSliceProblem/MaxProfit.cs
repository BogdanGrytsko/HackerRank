using System;
using Xunit;

namespace XTest.Codility._09.MaximumSliceProblem
{
    public class MaxProfit
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(356, Solution(new int[] { 23171, 21011, 21123, 21366, 21013 , 21367 }));
        }

        [Fact]
        public void Declining_Stocks_Test()
        {
            Assert.Equal(0, Solution(new int[] {10, 9, 8, 7, 1, 1}));
        }

        public int Solution(int[] A)
        {
            if (A.Length == 0 || A.Length == 1)
                return 0;
            int min = int.MaxValue, bestSofar = 0, globalBest = 0;
            for (int i = 0; i < A.Length; i++)
            {
                min = Math.Min(min, A[i]);
                bestSofar = Math.Max(bestSofar, A[i] - min);
                globalBest = Math.Max(globalBest, bestSofar);
            }

            return globalBest;
        }
    }
}