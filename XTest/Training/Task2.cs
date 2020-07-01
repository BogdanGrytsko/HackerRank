using System;
using Xunit;

namespace XTest.Training
{
    //22/0
    //wrong EncodedLn func - 10A had length of 2, but should had 3
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
        public void Perf_Test()
        {
            Assert.True(false);
            Assert.Equal(6, Solution(new string('A', 100000), 50000));
        }

        [Fact]
        public void TestLn()
        {
            Assert.Equal(9, EncodedLn("ABBBCCDDCCC"));
        }

        [Fact]
        public void TestLn2()
        {
            Assert.Equal(3, EncodedLn(new string('A', 10)));
        }

        [Fact]
        public void TestLn3()
        {
            Assert.Equal(1, EncodedLn("A"));
        }

        [Fact]
        public void TestLn4()
        {
            Assert.Equal(5, EncodedLn("ABBBCCCC"));
        }

        public int Solution(string S, int K)
        {
            if (K >= S.Length - 2)
                return S.Length - K;
            int min = int.MaxValue;
            for (int i = 0; i < S.Length - K; i++)
            {
                var s = S.Remove(i, K);
                var enc = EncodedLn(s);
                min = Math.Min(min, enc);
            }
            return min;
        }

        private static int EncodedLn(string s)
        {
            char sC = 'c';
            int enc = 0, grp = 1;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == sC)
                {
                    grp++;
                }
                else if (s[i] != sC)
                {
                    sC = s[i];
                    if (i != 0)
                    {
                        enc += GetEncCnt(grp);
                    }
                    grp = 1;
                }
            }

            enc += GetEncCnt(grp);

            return enc;
        }

        private static int GetEncCnt(int grp)
        {
            if (grp == 1)
                return 1;
            return grp.ToString().Length + 1;
        }
    }
}