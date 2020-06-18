using System.Linq;
using Xunit;

namespace XTest.Codility._03.TimeComplexity
{
    public class MissingElement
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(4, Solution(new []{ 2, 3, 1, 5}));
        }

        [Fact]
        public void Test_Last()
        {
            Assert.Equal(5, Solution(new[] { 2, 3, 1, 4 }));
        }

        [Fact]
        public void Empty_Array()
        {
            Assert.Equal(1, Solution(new int[0]));
        }

        public int Solution(int[] a)
        {
            var arr = Enumerable.Range(1, a.Length + 1);
            return arr.Except(a).Single();
        }
    }
}