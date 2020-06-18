using Xunit;

namespace XTest.Codility
{
    public class FrogJump
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(3, Solution(10, 85, 30));
        }

        [Fact]
        public void Same_Position()
        {
            Assert.Equal(0, Solution(10, 10, 30));
        }

        [Fact]
        public void Exact_Jump()
        {
            Assert.Equal(2, Solution(10, 80, 35));
        }

        [Fact]
        public void BIG_D()
        {
            Assert.Equal(1, Solution(10, 80, 1000000000));
        }

        private static int Solution(int x, int y, int d)
        {
            var dist = y - x;
            var steps = dist / d;
            if (dist % d != 0)
                steps++;
            return steps;
        }
    }
}
