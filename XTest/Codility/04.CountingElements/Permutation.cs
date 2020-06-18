using System;
using Xunit;

namespace XTest.Codility._04.CountingElements
{
    public class Permutation
    {
        [Fact]
        public void Is_Permutation_Test()
        {
            Assert.Equal(1, Solution(new[] {4, 1, 3, 2}));
        }

        [Fact]
        public void Is_Not_Permutation_Test()
        {
            Assert.Equal(0, Solution(new[] { 4, 1, 2 }));
        }

        public int Solution(int[] a)
        {
            Array.Sort(a);
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != i + 1)
                    return 0;
            }

            return 1;
        }
    }
}