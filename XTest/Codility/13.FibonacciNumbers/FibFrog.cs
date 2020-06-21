using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XTest.Codility._13.FibonacciNumbers
{
    public class FibFrog
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(3, Solution(new[] { 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 0 }));
        }

        [Fact]
        public void Perf_Test_All_Set()
        {
            var arr = new int[100000];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = 1;
            }

            Assert.Equal(6,Solution(arr));
        }

        [Fact]
        public void All_ones_Test()
        {
            Assert.Equal(1, Solution(new[] { 1 }));
        }

        [Fact]
        public void All_zeros_Test()
        {
            Assert.Equal(1, Solution(new[] {0, 0, 0, 0}));
        }

        [Fact]
        public void Test2()
        {
            Assert.Equal(2, Solution(new[] { 1, 1, 0, 0, 0 }));
        }

        [Fact]
        public void Cyclic_Test()
        {
            Assert.Equal(2, Solution(new[] {0, 0, 1, 0, 1, 1, 0, 0, 0, 0}));
        }

        public int Solution(int[] A)
        {
            if (A.Length == 0)
                return 1;
            var fibonacci = new List<int> {0, 1};
            int elem = -1, i = 2;
            while (elem <= A.Length)
            {
                elem = fibonacci[i - 2] + fibonacci[i - 1];
                fibonacci.Add(elem);
                i++;
            }

            fibonacci = fibonacci.Skip(1).ToList();
            fibonacci.Reverse();
            var minJmp = int.MaxValue;
            return TryJump(A, fibonacci, -1, 0, ref minJmp);
        }

        private int TryJump(int[] A, List<int> fibo, int pos, int jmp, ref int minJmp)
        {
            for (int j = 0; j < fibo.Count; j++)
            {
                var newPos = fibo[j] + pos;
                if (newPos == A.Length)
                    return jmp + 1;
                if (newPos > A.Length)
                    continue;
                if (A[newPos] == 1)
                {
                    if (minJmp <= jmp)
                        return -1;
                    var other = TryJump(A, fibo, newPos, jmp + 1, ref minJmp);
                    if (other != -1)
                    {
                        minJmp = Math.Min(minJmp, other);
                    }
                }
            }

            return minJmp;
        }
    }
}