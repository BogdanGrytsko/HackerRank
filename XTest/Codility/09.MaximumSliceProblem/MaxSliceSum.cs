using System;
using System.Linq;
using Xunit;

namespace XTest.Codility._09.MaximumSliceProblem
{
    public class MaxSliceSum
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(5, Solution(new int[] {3, 2, -6, 4, 0}));
        }

        [Fact]
        public void Test2()
        {
            Assert.Equal(7, Solution(new int[] {1, -2, -3, 4, -1, -2, 1, 5, -3}));
        }

        [Fact]
        public void Only_negatives()
        {
            Assert.Equal(-1, Solution(new int[] { -1, -2, -4 }));
        }

        public int Solution(int[] A)
        {
            if (A.All(a => a < 0))
                return A.Max();

            int maxSoFar = int.MinValue, maxEndingHere = 0;
            for (int i = 0; i < A.Length; i++)
            {
                maxEndingHere += A[i];
                maxEndingHere = Math.Max(maxEndingHere, 0);
                maxSoFar = Math.Max(maxSoFar, maxEndingHere);
            }
            return maxSoFar;
        }
    }
}