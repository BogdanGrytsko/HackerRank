using System;
using System.Linq;
using Xunit;

namespace XTest.Codility._15.CaterpillarMethod
{
    public class AbsDistinct
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(5, Solution(new[] { -5, -3, -1, 0, 3, 6}));
        }

        [Fact]
        public void Int_Min_Test()
        {
            Assert.Equal(6, Solution(new[] { -5, -3, -1, 0, 3, 6, int.MinValue }));
        }

        public int Solution(int[] A)
        {
            var cnt = A.Where(a => a != int.MinValue).Select(Math.Abs).Distinct().Count();
            if (A.Contains(int.MinValue))
                cnt++;
            return cnt;
        }
    }
}