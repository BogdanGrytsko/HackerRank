using System.Collections.Generic;
using Xunit;

namespace XTest.Codility._15.CaterpillarMethod
{
    public class CountDistinctSlices
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(9, Solution(6, new[] {3, 4, 5, 5, 2}));
        }

        public int Solution(int M, int[] A)
        {
            var cnt = 0;
            int start = 0, i = 0;
            var set = new HashSet<int>();
            while (start < A.Length)
            {
                while (i < A.Length && !set.Contains(A[i]))
                {
                    set.Add(A[i]);
                    i++;
                }

                cnt += set.Count;
                if (cnt > 1000000000)
                    return 1000000000;
                set.Remove(A[start]);
                start++;
            }

            return cnt;
        }
    }
}