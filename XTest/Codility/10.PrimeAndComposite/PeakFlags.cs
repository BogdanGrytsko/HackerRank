using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XTest.Codility._10.PrimeAndComposite
{
    public class PeakFlags
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(3, Solution(new[] {1, 5, 3, 4, 3, 4, 1, 2, 3, 4, 6, 2}));
        }

        [Fact]
        public void Two_Flags_Three_Peaks()
        {
            Assert.Equal(2, Solution(new[] {1, 10, 1, 10, 2, 11, 3}));
        }

        [Fact]
        public void Plato()
        {
            Assert.Equal(0, Solution(new[] {1, 1, 1}));
        }

        [Fact]
        public void Triple()
        {
            Assert.Equal(1, Solution(new[] { 1, 3, 2 }));
        }

        [Fact]
        public void Simple1_Two_Flags()
        {
            Assert.Equal(2, Solution(new[] { 0, 0, 0, 0, 0, 1, 0, 1, 0, 1 }));
        }

        [Fact]
        public void Triple_Packed()
        {
            Assert.Equal(3, Solution(new[] { 0, 1, 0, 0, 1, 0, 0, 1, 0, 0 }));
        }

        public int Solution(int[] A)
        {
            if (A.Length < 3)
                return 0;
            var peakIdx = new List<int>();
            for (int i = 1; i < A.Length - 1; i++)
            {
                if (A[i] > A[i - 1] && A[i] > A[i + 1])
                    peakIdx.Add(i);
            }

            if (!peakIdx.Any())
                return 0;
            if (peakIdx.Count == 1)
                return 1;
            int maxK = 0;
            for (int k = 1; k <= Math.Sqrt(peakIdx.Last() - peakIdx.First()) + 1; k++)
            {
                int prevPeakIdx = 0;
                int flagsSet = 1;
                for (int i = 1; i < peakIdx.Count; i++)
                {
                    if (flagsSet >= k)
                        break;
                    if (peakIdx[i] >= peakIdx[prevPeakIdx] + k)
                    {
                        flagsSet++;
                        prevPeakIdx = i;
                    }
                }

                maxK = Math.Max(maxK, flagsSet);
            }

            return maxK;
        }
    }
}