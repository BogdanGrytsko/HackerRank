using System;
using Xunit;

namespace XTest.Codility._01.Iterations
{
    public class BinaryGap
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(2, solution(9));
        }

        [Fact]
        public void Test2()
        {
            Assert.Equal(4, solution(529));
        }

        [Fact]
        public void Test4()
        {
            Assert.Equal(1, solution(20));
        }

        [Fact]
        public void Test3()
        {
            Assert.Equal(0, solution(32));
        }

        [Fact]
        public void Test5()
        {
            Assert.Equal(0, solution(15));
        }

        public int solution(int N)
        {
            var str = Convert.ToString(N, 2);
            int gapLen = 0, maxGap = 0;
            bool gapFound = false;
            int i = 0;
            while (i < str.Length)
            {
                if (str[i] == '1' && gapFound)
                {
                    maxGap = Math.Max(maxGap, gapLen);
                    gapLen = 0;
                }

                if (str[i] == '1')
                {
                    gapFound = true;
                }
                else if (gapFound)
                {
                    gapLen++;
                }

                i++;
            }

            return maxGap;
        }
    }
}