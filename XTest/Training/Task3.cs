using System.Linq;
using Xunit;

namespace XTest.Training
{
    //57/14
    public class Task3
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(2, Solution("babaa"));
        }

        [Fact]
        public void Test2()
        {
            Assert.Equal(4, Solution("ababa"));
        }

        [Fact]
        public void Test3()
        {
            Assert.Equal(0, Solution("aba"));
        }

        [Fact]
        public void Test4()
        {
            Assert.Equal(6, Solution("bbbbb"));
        }

        [Fact]
        public void Test5()
        {
            Assert.Equal(6, Solution("abbbbbaa"));
        }

        [Fact]
        public void Test6()
        {
            Assert.Equal(1, Solution("aaaaaa"));
        }

        [Fact]
        public void Test7()
        {
            Assert.Equal(1, Solution("aaabaaa"));
        }

        [Fact]
        public void Test8()
        {
            Assert.Equal(2, Solution("aaaabaa"));
        }

        public int Solution(string S)
        {
            var acnt = S.Count(c => c == 'a');
            if (acnt % 3 != 0)
                return 0;
            if (acnt == 0)
                return (S.Length - 1) * (S.Length - 2) / 2;
            acnt = acnt / 3;
            int currCnt = 0, b1Cnt = 0, b2Cnt = 0;
            bool firstEncountered = false;
            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] == 'a')
                {
                    currCnt++;
                }

                if (currCnt == acnt)
                {
                    currCnt = 0;
                    if (i == S.Length - 1) continue;
                    while (S[i + 1] == 'b')
                    {
                        i++;
                        if (!firstEncountered)
                            b1Cnt++;
                        else
                            b2Cnt++;
                    }

                    firstEncountered = true;
                }
            }

            if (b1Cnt == 0 && b2Cnt == 0)
                return 1;
            return (b1Cnt == 0 ? 0 : b1Cnt + 1) + (b2Cnt == 0 ? b2Cnt : b2Cnt + 1);
        }
    }
}