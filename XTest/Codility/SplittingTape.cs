using System;
using System.Linq;
using Xunit;
// ReSharper disable InconsistentNaming

namespace XTest.Codility
{
    public class SplittingTape
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(1, solution(new[] {3, 1, 2, 4, 3}));
        }

        public int solution(int[] A)
        {
            var globalMin = int.MaxValue;
            int left = A[0];
            int right = A.Skip(1).Sum();
            int dif = Math.Abs(left - right);
            globalMin = Math.Min(globalMin, dif);
            for (int i = 1; i < A.Length - 1; i++)
            {
                left += A[i];
                right -= A[i];
                dif = Math.Abs(left - right);
                globalMin = Math.Min(globalMin, dif);
            }

            return globalMin;
        }
    }
}