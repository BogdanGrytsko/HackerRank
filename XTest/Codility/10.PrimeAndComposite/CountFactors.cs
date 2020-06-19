using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XTest.Codility._10.PrimeAndComposite
{
    public class CountFactors
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(8, Solution(24));
        }

        [Fact]
        public void Test2()
        {
            Assert.Equal(16, Solution(120));
        }

        [Fact]
        public void Prime_Test()
        {
            Assert.Equal(2, Solution(31));
        }

        [Fact]
        public void Factor_One_Test()
        {
            Assert.Equal(1, Solution(1));
        }

        [Fact]
        public void Factor_Max_Test()
        {
            Assert.Equal(2, Solution(int.MaxValue));
        }

        [Fact]
        public void Factor_Squared_Test()
        {
            Assert.Equal(3, Solution(9));
        }

        public int Solution(int N)
        {
            if (N == 1)
                return 1;
            var factors = new List<int>();
            for (int i = 2; i <= Math.Sqrt(N); i++)
            {
                if (N % i == 0)
                {
                    factors.Add(i);
                    N = N / i;
                    i--;
                }
            }
            factors.Add(N);
            if (factors.Count == 1)
                return 2;
            var groups = factors.GroupBy(f => f);
            var factorCnt = 1;
            foreach (var group in groups)
            {
                factorCnt *= (group.Count() + 1);
            }
            return factorCnt;
        }
    }
}