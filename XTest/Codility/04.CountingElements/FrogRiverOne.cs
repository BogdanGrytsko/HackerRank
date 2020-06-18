using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XTest.Codility._04.CountingElements
{
    public class FrogRiverOne
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(6, Solution(5, new[] {1, 3, 1, 4, 2, 3, 5, 4}));
        }

        [Fact]
        public void One_Element_Test()
        {
            Assert.Equal(0, Solution(1, new[] { 1 }));
        }

        [Fact]
        public void One_Element_No_Solution_Test()
        {
            Assert.Equal(-1, Solution(4, new[] { 1 }));
        }

        public int Solution(int x, int[] a)
        {
            var dic = new Dictionary<int, int>();
            for (int i = 0; i < a.Length; i++)
            {
                if (!dic.ContainsKey(a[i]))
                    dic.Add(a[i], i);
            }

            var range = Enumerable.Range(1, x);
            var except = range.Except(dic.Keys);
            if (except.Any())
                return -1;

            return dic.Values.Max();
        }
    }
}