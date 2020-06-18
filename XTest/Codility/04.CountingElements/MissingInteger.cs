using System.Linq;
using Xunit;

namespace XTest.Codility._04.CountingElements
{
    public class MissingInteger
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(5, Solution(new []{ 1, 3, 6, 4, 1, 2 }));
            Assert.Equal(4, Solution(new[] {1, 2, 3}));
            Assert.Equal(1, Solution(new[] { -3, -1 }));
        }

        public int Solution(int[] A)
        {
            var x = A.Where(a => a > 0).Distinct().OrderBy(a => a).ToArray();
            if (!x.Any())
                return 1;
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] != i + 1)
                    return i + 1;
            }

            return x.Length + 1;
        }
    }
}