using System;
using System.Linq;
using Xunit;

namespace XTest.Codility._17.DynamicProgramming
{
    public class NumberSolitaire
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(8, solution(new[] {1, -2, 0, 9, -1, -2}));
        }

        [Fact]
        public void Visit_Each()
        {
            Assert.Equal(5, solution(new[] {1, 1, 1, 1, 1}));
        }

        [Fact]
        public void Max_Jumps()
        {
            Assert.Equal(999, solution(new[] {-1, -1, -1, -1, 1, -1, -1, /**/ -10, -10, -10, -10, -10, 1000}));
        }

        [Fact]
        public void Visit_Each_Performance()
        {
            Assert.Equal(100000, solution(Enumerable.Repeat(1, 100000).ToArray()));
        }

        [Fact]
        public void Test2()
        {
            Assert.Equal(4, solution(new[] {-2, 5, 1}));
        }

        public int solution(int[] A)
        {
            var k = 6;
            var solutions = new int[A.Length + k];
            for (int i = 0; i < solutions.Length; i++)
            {
                solutions[i] = int.MinValue;
            }

            solutions[k] = A[0];
            for (int i = 1; i < A.Length; i++)
            {
                for (int j = 1; j <= k; j++)
                {
                    solutions[k + i] = Math.Max(solutions[k + i], solutions[k + i - j]);
                }

                solutions[k + i] += A[i];
            }
            return solutions[solutions.Length - 1];
        }
    }
}