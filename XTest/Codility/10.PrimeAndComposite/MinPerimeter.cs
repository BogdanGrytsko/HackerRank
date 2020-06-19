using System;
using Xunit;

namespace XTest.Codility._10.PrimeAndComposite
{
    public class MinPerimeter
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(22, Solution(30));
        }

        [Fact]
        public void Max_Test()
        {
            Assert.Equal(126500, Solution(1000000000));
        }

        [Fact]
        public void Square_Test()
        {
            Assert.Equal(20, Solution(25));
        }

        [Fact]
        public void One_Test()
        {
            Assert.Equal(4, Solution(1));
        }

        public int Solution(int N)
        {
            var sq = (int) Math.Sqrt(N);
            for (int i = sq; i >= 1; i--)
            {
                if (N % i == 0)
                {
                    var side = N / i;
                    return (i + side) * 2;
                }
            }
            //never happens
            return -1;
        }
    }
}