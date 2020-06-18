using Xunit;

namespace XTest.Codility._05.PrefixSum
{
    public class PassingCars
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(5, Solution(new []{0, 1, 0, 1, 1}));
        }

        public int Solution(int[] A)
        {
            var prefix = new int[A.Length];
            int sum = 0;
            for (int i = prefix.Length - 1; i >= 0; i--)
            {
                if (i != prefix.Length - 1)
                    prefix[i] = prefix[i + 1];
                if (A[i] == 1)
                {
                    prefix[i]++;
                }
                else
                {
                    sum += prefix[i];
                    if (sum > 1000000000)
                        return -1;
                }
            }

            return sum;
        }
    }
}