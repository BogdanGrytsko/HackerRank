using System.Linq;
using Xunit;
// ReSharper disable InconsistentNaming

namespace XTest.Codility
{
    public class MissingElement
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(4, solution(new []{ 2, 3, 1, 5}));
        }

        [Fact]
        public void Test_Last()
        {
            Assert.Equal(5, solution(new[] { 2, 3, 1, 4 }));
        }

        [Fact]
        public void Empty_Array()
        {
            Assert.Equal(1, solution(new int[0]));
        }

        public int solution(int[] A)
        {
            var arr = Enumerable.Range(1, A.Length + 1);
            return arr.Except(A).Single();
        }
    }
}