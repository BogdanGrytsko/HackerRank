using Xunit;

namespace XTest.Codility._16.GreedyAlgorithms
{
    public class TieRopes
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(3, Solution(4, new []{1, 2, 3, 4, 1, 1, 3}));
        }

        [Fact]
        public void Cant_Produce_Test()
        {
            Assert.Equal(0, Solution(100, new[] {1, 2, 3}));
        }

        public int Solution(int K, int[] A)
        {
            var cnt = 0;
            var len = 0;
            for (int i = 0; i < A.Length; i++)
            {
                len += A[i];
                if (len >= K)
                {
                    cnt++;
                    len = 0;
                }
            }
            return cnt;
        }
    }
}