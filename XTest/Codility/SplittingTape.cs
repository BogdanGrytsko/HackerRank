using System;
using System.Linq;
using Xunit;

namespace XTest.Codility
{
    public class SplittingTape
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(1, Solution(new[] {3, 1, 2, 4, 3}));
        }

        public int Solution(int[] a)
        {
            var globalMin = int.MaxValue;
            int left = a[0];
            int right = a.Skip(1).Sum();
            int dif = Math.Abs(left - right);
            globalMin = Math.Min(globalMin, dif);
            for (int i = 1; i < a.Length - 1; i++)
            {
                left += a[i];
                right -= a[i];
                dif = Math.Abs(left - right);
                globalMin = Math.Min(globalMin, dif);
            }

            return globalMin;
        }
    }
}