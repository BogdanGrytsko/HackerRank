using System.Collections.Generic;
using System.Linq;
using Xunit;
// ReSharper disable InconsistentNaming

namespace XTest.Codility
{
    public class FrogRiverOne
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(6, solution(5, new[] {1, 3, 1, 4, 2, 3, 5, 4}));
        }

        [Fact]
        public void One_Element_Test()
        {
            Assert.Equal(0, solution(1, new[] { 1 }));
        }

        [Fact]
        public void One_Element_No_Solution_Test()
        {
            Assert.Equal(-1, solution(4, new[] { 1 }));
        }

        public int solution(int X, int[] A)
        {
            var dic = new Dictionary<int, int>();
            for (int i = 0; i < A.Length; i++)
            {
                if (!dic.ContainsKey(A[i]))
                    dic.Add(A[i], i);
            }

            var range = Enumerable.Range(1, X);
            var except = range.Except(dic.Keys);
            if (except.Any())
                return -1;

            return dic.Values.Max();
        }
    }
}