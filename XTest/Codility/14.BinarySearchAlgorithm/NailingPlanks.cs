using System.Collections.Generic;
using Xunit;

namespace XTest.Codility._14.BinarySearchAlgorithm
{
    public class NailingPlanks
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(4, solution(new[] {1, 4, 5, 8}, new[] {4, 5, 9, 10}, new[] {4, 6, 7, 10, 2}));
        }

        [Fact]
        public void Cant_Nail()
        {
            Assert.Equal(-1, solution(new[] { 2 }, new[] { 2 }, new[] { 1 }));
        }

        [Fact]
        public void Single_Nail()
        {
            Assert.Equal(1, solution(new[] { 1 }, new[] { 2 }, new[] { 2}));
        }

        public int solution(int[] A, int[] B, int[] C)
        {
            int min = 1, max = C.Length;
            int mid;
            bool nailed = false;
            while (true)
            {
                mid = (min + max) / 2;
                nailed = AllNailed(A, B, C, mid);
                if (nailed)
                    max = mid;
                else
                    min = mid + 1;
                if (min >= max)
                    break;
            }

            if (!nailed)
                return -1;
            return mid;
        }

        private bool AllNailed(int[] A, int[] B, int[] C, int cnt)
        {
            var nailed = new HashSet<int>();
            for (int i = 0; i < cnt; i++)
            {
                for (int j = 0; j < A.Length; j++)
                {
                    if (A[j] <= C[i] && B[j] >= C[i])
                        nailed.Add(j);
                }
            }

            return nailed.Count == A.Length;
        }
    }
}