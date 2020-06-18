using System.Linq;
using Xunit;

namespace XTest.Codility._06.Sorting
{
    public class DistinctArr
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(3, Solution(new []{1, 1, 1, 2, 3, 1}));
            Assert.Equal(0, Solution(new int[0]));
        }

        public int Solution(int[] A)
        {
            return A.Distinct().Count();
        }
    }
}