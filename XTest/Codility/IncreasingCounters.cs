using System;
using Xunit;
// ReSharper disable InconsistentNaming

namespace XTest.Codility
{
    public class IncreasingCounters
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(new[] {3, 2, 2, 4, 2}, solution(5, new[] {3, 4, 4, 6, 1, 4, 4}));
        }

        public int[] solution(int N, int[] A)
        {
            var x = new int[N];
            int max = 0, min = -1;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] <= N)
                {
                    var idx = A[i] - 1;
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