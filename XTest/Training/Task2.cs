using System;
using Xunit;

namespace XTest.Training
{
    //22/0
    public class Task2
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(5, Solution("ABBBCCDDCCC", 3));
        }

        [Fact]
        public void Test2()
        {
            Assert.Equal(3, Solution("AAAAAAAAAAABXXAAAAAAAAAA", 3));
        }

        [Fact]
        public void Test3()
        {
            Assert.Equal(6, Solution("ABCDDDEFG", 2));
        }

        [Fact]
        public void TestLn()
        {
            Assert.Equal(9, EncodedLn("ABBBCCDDCCC", 0, 11));
        }

        public int Solution(string S, int K)
        {
            if (K >= S.Length - 2)
                return S.Length - K;
            int min = int.MaxValue;
            for (int i = 0; i < S.Length - K; i++)
            {
                var s = S.Remove(i, K);
                var enc = EncodedLn(s, 0, s.Length);
                min = Math.Min(min, enc);
            }
            return min;
        }

        private static int EncodedLn(string s, int start, int len)
        {
            char sC = 'c';
            int enc = 0, grp = 0;
            for (int i = start; i < len; i++)
            {
                if (s[i] == sC && grp == 1)
                {
                    grp = 2;
                    enc++;
                }
                else if (s[i] != sC)
                {
                    sC = s[i];
                    grp = 1;
                    enc++;
                }
            }

            return enc;
        }
    }
}