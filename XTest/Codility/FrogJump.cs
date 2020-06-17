using Xunit;

// ReSharper disable InconsistentNaming

namespace XTest.Codility
{
    public class FrogJump
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(3, solution(10, 85, 30));
        }

        [Fact]
        public void Same_Position()
        {
            Assert.Equal(0, solution(10, 10, 30));
        }

        [Fact]
        public void Exact_Jump()
        {
            Assert.Equal(2, solution(10, 80, 35));
        }

        [Fact]
        public void BIG_D()
        {
            Assert.Equal(1, solution(10, 80, 1000000000));
        }

        private static int solution(int X, int Y, int D)
        {
            var dist = Y - X;
            var steps = dist / D;
            if (dist % D != 0)
                steps++;
            return steps;
        }
    }
}
