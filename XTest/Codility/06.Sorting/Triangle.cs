using System;
using Xunit;

namespace XTest.Codility._06.Sorting
{
    public class Triangle
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(1, Solution(new[] {10, 2, 5, 1, 8, 20}));
            Assert.Equal(0, Solution(new[] {10, 50, 5, 1}));
        }

        [Fact]
        public void Test2()
        {
            Assert.Equal(1, Solution(new[] { 2, 3, 4, 100 }));
        }

        [Fact]
        public void Two_elems()
        {
            Assert.Equal(0, Solution(new[] { 2, 3 }));
        }

        [Fact]
        public void Negative_Test()
        {
            Assert.Equal(0, Solution(new[] { -2, -3, -4 }));
        }

        [Fact]
        public void Max_Boundary_Test()
        {
            Assert.Equal(1, Solution(new[] { int.MaxValue, int.MaxValue, int.MaxValue }));
        }

        public int Solution(int[] A)
        {
            if (A.Length < 3)
                return 0;
            Array.Sort(A);
            for (int i = 0; i < A.Length - 2; i++)
            {
                var i2 = i + 1;
                var i3 = i + 2;
                if (A[i] + (long)A[i2] > A[i3] && A[i] + (long)A[i3] > A[i2] && A[i2] + (long)A[i3] > A[i])
                    return 1;
            }

            return 0;
        }
    }
}