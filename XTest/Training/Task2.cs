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
            //Assert.True(false);
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

        [Fact]
        public void Test4()
        {
            Assert.Equal(2, Solution("AABBAA", 2));
        }

        private class Str
        {
            public char Char { get; set; }
            public int Cnt { get; set; }

            public Str()
            {
                Char = '0';
                Cnt = 0;
            }

            public Str(char c)
            {
                Char = c;
                Cnt = 1;
            }
        }

        public int Solution(string S, int K)
        {
            if (K >= S.Length - 2)
                return S.Length - K;
            int min = int.MaxValue;
            Str start = new Str(), end = new Str(S[K]);
            int startLen = 0, endLen = 0;
            for (int i = K + 1; i < S.Length; i++)
            {
                if (S[i] == end.Char)
                    end.Cnt++;
                else
                {
                    endLen = EncodedLn(S.Substring(i, S.Length - i));
                    min = endLen + GetEncCnt(end.Cnt);
                    break;
                }
            }

            for (int i = 0; i < S.Length - K; i++)
            {
                var sc = S[i];
                var ec = S[i + K];
                if (start.Char == sc)
                    start.Cnt++;
                else
                {
                    startLen += GetEncCnt(start.Cnt);
                    start = new Str(sc);
                }

                if (end.Char == ec)
                    end.Cnt--;

                var enc = startLen;
                if (end.Cnt == 0)
                {
                    Str newEnd = new Str();
                    if (i + K + 1 < S.Length)
                    {
                        newEnd = new Str(S[i + K + 1]);
                    }
                    for (int j = i + K + 2; j < S.Length; j++)
                    {
                        if (S[j] == newEnd.Char)
                            newEnd.Cnt++;
                        else
                            break;
                    }

                    var newEndLen = GetEncCnt(newEnd.Cnt);
                    if (newEndLen != endLen)
                    {
                        enc += endLen;
                        if (newEnd.Cnt > 0 && start.Char == newEnd.Char)
                            enc += GetEncCnt(start.Cnt + end.Cnt);
                        else
                            enc += GetEncCnt(start.Cnt) + GetEncCnt(end.Cnt);
                    }
                    else
                    {
                        if (newEnd.Cnt > 0 && start.Char == newEnd.Char)
                            enc += GetEncCnt(start.Cnt + newEnd.Cnt);
                        else
                            enc += GetEncCnt(start.Cnt) + GetEncCnt(newEnd.Cnt);
                    }

                    end = newEnd;
                    endLen -= newEndLen;
                }
                else
                {
                    enc += endLen;
                    if (start.Char == end.Char)
                        enc += GetEncCnt(start.Cnt + end.Cnt);
                    else
                        enc += GetEncCnt(start.Cnt) + GetEncCnt(end.Cnt);
                }

                min = Math.Min(min, enc);
            }
            return min;
        }

        private static int EncodedLn(string s)
        {
            if (s == "")
                return 0;
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
            switch (grp)
            {
                case 0:
                    return 0;
                case 1:
                    return 1;
                default:
                    return grp.ToString().Length + 1;
            }
        }
    }
}