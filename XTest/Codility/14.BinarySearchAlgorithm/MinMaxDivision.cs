using System;
using System.Linq;
using Xunit;

namespace XTest.Codility._14.BinarySearchAlgorithm
{
    public class MinMaxDivision
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(6, Solution(3, 5, new[] {2, 1, 5, 1, 2, 2, 2}));
        }

        [Fact]
        public void Two_Elements_Test()
        {
            Assert.Equal(5, Solution(2, 5, new[] {5, 3}));
        }

        [Fact]
        public void Two_Elements_3Chunks_Test()
        {
            Assert.Equal(5, Solution(3, 5, new[] { 5, 3 }));
        }

        [Fact]
        public void N_Elements_NChunks_Test()
        {
            Assert.Equal(5, Solution(4, 5, new[] { 5, 3, 1, 2 }));
        }

        [Fact]
        public void Perf_Test()
        {
            var rnd = new Random();
            var arr = new int [100000];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(0, 10000);
            }

            Solution(rnd.Next(10, 1000), -1, arr);
        }

        public int Solution(int K, int M, int[] A)
        {
            var max = A.Sum();
            var min = A.Max();
            if (K > A.Length)
                return min;
            while (min != max)
            {
                var mid = (min + max) / 2;
                var cnt = GetPieceCnt(A, mid);
                if (cnt > K)
                {
                    if (min != mid)
                        min = mid;
                    else
                        min = mid + 1;
                }
                else if (cnt < K)
                    max = mid;
                else if (min != max)
                    max = mid;
                else
                    return mid;
            }

            return min;
        }

        private int GetPieceCnt(int[] A, int expectedSum)
        {
            var sum = A[0];
            var cnt = 1;
            for (int i = 1; i < A.Length; i++)
            {
                if (sum + A[i] <= expectedSum)
                    sum += A[i];
                else
                {
                    sum = A[i];
                    cnt++;
                }
            }

            return cnt;
        }
    }
}