using System;
using System.Text;
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

        public int Solution(string S, int K)
        {
            if (K >= S.Length - 2)
                return S.Length - K;
            int min = int.MaxValue;
            int startLen = 0, endLen = 0;
            var sb = new StringBuilder();
            sb.Append(S[K]);
            char startStrC = '0';
            int startStrCnt = 0;
            string endStr = "";
            for (int i = K + 1; i < S.Length; i++)
            {
                if (S[i] == S[K])
                    sb.Append(S[K]);
                else
                {
                    endLen = EncodedLn(S.Substring(i, S.Length - i));
                    endStr = sb.ToString();
                    min = endLen + GetEncCnt(endStr.Length);
                    break;
                }
            }

            if (endStr == "")
                endStr = sb.ToString();
            sb.Clear();

            for (int i = 0; i < S.Length - K; i++)
            {
                var sc = S[i];
                var ec = S[i + K];
                if (startStrC == sc)
                {
                    startStrCnt++;
                }
                else
                {
                    startLen += GetEncCnt(startStrCnt);
                    startStrCnt = 1;
                    startStrC = sc;
                }

                if (endStr.StartsWith(ec))
                {
                    endStr = endStr.Substring(1, endStr.Length - 1);
                }

                var enc = startLen;
                if (endStr.Length == 0)
                {
                    var newEnd = "";
                    if (i + K + 1 < S.Length)
                    {
                        newEnd += S[i + K + 1];
                    }
                    for (int j = i + K + 2; j < S.Length; j++)
                    {
                        if (S[j] == newEnd[0])
                            newEnd += S[j];
                        else
                        {
                            break;
                        }
                    }

                    var newEndLen = GetEncCnt(newEnd.Length);
                    if (newEndLen != endLen)
                    {
                        enc += endLen;
                        if (newEnd.Length > 0 && startStrC == newEnd[0])
                            enc += GetEncCnt(startStrCnt + endStr.Length);
                        else
                            enc += GetEncCnt(startStrCnt) + GetEncCnt(endStr.Length);
                    }
                        
                    else
                    {
                        if (newEnd.Length > 0 && startStrC == newEnd[0])
                            enc += GetEncCnt(startStrCnt + newEnd.Length);
                        else
                            enc += GetEncCnt(startStrCnt) + GetEncCnt(newEnd.Length);
                    }

                    endStr = newEnd;
                    endLen -= newEndLen;
                }
                else
                {
                    enc += endLen;
                    if (startStrC == endStr[0])
                        enc += GetEncCnt(startStrCnt + endStr.Length);
                    else
                        enc += GetEncCnt(startStrCnt) + GetEncCnt(endStr.Length);
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