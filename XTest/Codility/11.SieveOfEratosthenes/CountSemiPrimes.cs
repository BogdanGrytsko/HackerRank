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

            var semiPrimes = new SortedSet<int>();
            for (int i = 4; i <= N; i++)
            {
                foreach (var prime in primes)
                {
                    if (i % prime == 0 && (primes.Contains(i / prime)))
                    {
                        semiPrimes.Add(i);
                        break;
                    }
                }
            }
            var res = new int[P.Length];
            for (int i = 0; i < P.Length; i++)
            {
                var cnt = semiPrimes.GetViewBetween(P[i], Q[i]).Count;
                res[i] = cnt;
            }

            return res;
        }
    }
}