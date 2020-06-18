using System;
using System.Collections.Generic;
using Xunit;

namespace XTest.Codility._08.Leader
{
    public class Dominator
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(7, Solution(new int[] {3, 4, 3, 2, 3, -1 ,3 ,3}));
        }

        [Fact]
        public void Test2()
        {
            Assert.Equal(-1, Solution(new int[] { 3, 4, 3, 2, 3, -1 }));
        }

        [Fact]
        public void Empty_Test()
        {
            Assert.Equal(-1, Solution(new int[] { }));
        }

        public int Solution(int[] A)
        {
            var max = 0;
            int maxIdx = -1;
            var dic = new Dictionary<int, int>();
            for (int i = 0; i < A.Length; i++)
            {
                var i1 = A[i];
                if (!dic.ContainsKey(i1))
                    dic.Add(i1, 0);
                dic[i1]++;
                if (dic[i1] > max)
                {
                    max = dic[i1];
                    maxIdx = i;
                }
                max = Math.Max(max, dic[i1]);
            }

            if (max > A.Length / 2)
                return maxIdx;
            return -1;
        }
    }
}