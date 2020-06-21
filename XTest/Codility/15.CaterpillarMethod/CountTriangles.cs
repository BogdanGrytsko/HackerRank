using System;
using Xunit;

namespace XTest.Codility._15.CaterpillarMethod
{
    public class CountTriangles
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(4, Solution(new[] { 10, 2, 5, 1, 8, 12}));
        }

        [Fact]
        public void Same_Value()
        {
            Assert.Equal(20, Solution(new[] { 10, 10, 10, 10, 10, 10}));
        }

        public int Solution(int[] A)
        {
            if (A.Length < 3)
                return 0;
            Array.Sort(A);
            int j, k, cnt = 0;
            for (int i = 0; i < A.Length - 2; i++)
            {
                j = i + 1;
                k = i + 2;
                while (k < A.Length)
                {
                    if (A[i] + A[j] > A[k])
                    {
                        cnt += k - j;
                        k++;
                    }
                    else if (j < k + 1)
                    {
                        j++;
                    }
                    else
                    {
                        j++;
                        k++;
                    }
                }
            }

            return cnt;
        }
    }
}