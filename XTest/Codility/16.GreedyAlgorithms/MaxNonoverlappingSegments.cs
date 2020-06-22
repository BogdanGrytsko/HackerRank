using Xunit;

namespace XTest.Codility._16.GreedyAlgorithms
{
    public class MaxNonOverlappingSegments
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(3, Solution(new[] {1, 3, 7, 9, 9}, new[] {5, 6, 8, 9, 10}));
        }

        [Fact]
        public void Big_line_Test()
        {
            //this violates B[K] ≤ B[K + 1]
            Assert.Equal(1, Solution(new[] { 1, 2, 3  }, new[] { 10, 2, 5 }));
        }

        public int Solution(int[] A, int[] B)
        {
            if (A.Length == 0)
                return 0;
            int cnt = 1, bend = B[0];
            for (int i = 1; i < A.Length; i++)
            {
                if (A[i] > bend)
                {
                    cnt++;
                    bend = B[i];
                }
            }

            return cnt;
        }
    }
}