using System;
using Xunit;

namespace XTest.Codility._04.CountingElements
{
    public class IncreasingCounters
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(new[] {3, 2, 2, 4, 2}, Solution(5, new[] {3, 4, 4, 6, 1, 4, 4}));
        }

        public int[] Solution(int n, int[] a)
        {
            var x = new int[n];
            int max = 0, min = -1;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] <= n)
                {
                    var idx = a[i] - 1;
                    if (x[idx] < min)
                        x[idx] = min + 1;
                    else
                        x[idx]++;
                    max = Math.Max(max, x[idx]);
                }
                else
                {
                    min = max;
                }
            }

            for (int i = 0; i < x.Length; i++)
            {
                x[i] = Math.Max(min, x[i]);
            }

            return x;
        }
    }
}