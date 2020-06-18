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
            Assert.Equal(180, Solution(new[] { -3, -10, 0, -2, 5, 6 }));
        }

        [Fact]
        public void Negative_Test()
        {
            Assert.Equal(20, Solution(new []{-5, -2, 1, 1, 2}));
        }

        public int Solution(int[] A)
        {
            Array.Sort(A);
            var n = A.Length - 1;
            var f = A[n] * A[n - 1] * A[n - 2];
            var s = A[0] * A[1] * A[n];
            return Math.Max(f, s);
        }
    }
}