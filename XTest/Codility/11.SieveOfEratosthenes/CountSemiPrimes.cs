using System.Collections.Generic;
using Xunit;

namespace XTest.Codility._11.SieveOfEratosthenes
{
    public class CountSemiPrimes
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(new[] {10, 4, 0}, Solution(26, new[] {1, 4, 16}, new[] {26, 10, 20}));
        }

        [Fact]
        public void Max_Test()
        {
            Assert.Equal(new[] { 10, 4, 0 }, Solution(50000, new[] { 1, 4, 16 }, new[] { 26, 10, 20 }));
        }

        [Fact]
        public void Four_Test()
        {
            Assert.Equal(new[] { 1 }, Solution(10, new[] { 4 }, new[] { 4 }));
        }

        public int[] Solution(int N, int[] P, int[] Q)
        {
            var primes = new HashSet<int>();
            primes.Add(2);
            for (int i = 3; i <= N; i += 2)
            {
                var primeFound = true;
                foreach (var prime in primes)
                {
                    if (i % prime == 0)
                    {
                        primeFound = false;
                        break;
                    }
                }
                if (primeFound)
                    primes.Add(i);
            }

            var semiPrimesCnt = new int[N + 1];
            for (int i = 1; i <= N; i++)
            {
                var semiPrimeFound = false;
                foreach (var prime in primes)
                {
                    if (i % prime == 0)
                    {
                        if (primes.Contains(i / prime))
                        {
                            semiPrimeFound = true;
                        }
                        break;
                    }
                }
                semiPrimesCnt[i] = semiPrimesCnt[i - 1];
                if (semiPrimeFound)
                    semiPrimesCnt[i]++;
            }
            var res = new int[P.Length];
            for (int i = 0; i < P.Length; i++)
            {
                res[i] = semiPrimesCnt[Q[i]] - semiPrimesCnt[P[i] - 1];
            }

            return res;
        }
    }
}