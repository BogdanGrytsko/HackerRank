using System;
using Xunit;

namespace XTest.Codility._06.Sorting
{
    public class MaxTriplets
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(60, Solution(new []{-3, 1, 2, -2, 5, 6}));
            Assert.Equal(0, Solution(new[] { -3, -10, 0, -2, 5, 6 }));
        }

        public int Solution(int[] A)
        {
            Array.Sort(A);
            var n = A.Length - 1;
            return A[n] * A[n - 1] * A[n - 2];
        }
    }
}