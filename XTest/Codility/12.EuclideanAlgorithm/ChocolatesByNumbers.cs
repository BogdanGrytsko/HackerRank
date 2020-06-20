using Xunit;

namespace XTest.Codility._12.EuclideanAlgorithm
{
    public class ChocolatesByNumbers
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(5, Solution(10, 4));
        }

        [Fact]
        public void Primes_Test()
        {
            Assert.Equal(31, Solution(31, 7));
        }

        [Fact]
        public void Extreme_Step_One_Test()
        {
            Assert.Equal(1000000000, Solution(1000000000, 1));
        }

        [Fact]
        public void Extreme_Count_One_Test()
        {
            Assert.Equal(1, Solution(1, 1000000000));
        }

        [Fact]
        public void Extreme_Match_Test()
        {
            Assert.Equal(1, Solution(2, 2));
        }

        [Fact]
        public void Step_Bigger_Test()
        {
            Assert.Equal(7, Solution(7, 31));
        }

        public int Solution(int N, int M)
        {
            int origN = N, origM = M;
            M = M % N;
            if (M == 0)
                return 1;
            int remainder = N;
            while (remainder != 0)
            {
                remainder = N % M;
                N = M;
                M = remainder;
            }

            var steps = (origN / N);
            return steps;
        }
    }
}