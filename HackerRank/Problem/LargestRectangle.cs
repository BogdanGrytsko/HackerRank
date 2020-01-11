using HackerRank.Algorithm;
using System;

namespace HackerRank.Problem
{
    public class LargestRectangle
    {
        static long largestRectangle(int[] h)
        {
            var rmq = new RMQSparseTable(h);
            return LargestRec(rmq, 0, h.Length - 1);
        }

        private static long LargestRec(RMQSparseTable rmq, int l, int r)
        {
            if (l == r)
                return rmq[l];
            var minIdx = rmq.MinIdx(l, r);
            var minElem = rmq[minIdx];
            long maxRect = minElem * (r - l + 1);
            if (minIdx - 1 > 0 && l <= minIdx - 1)
                maxRect = Math.Max(maxRect, LargestRec(rmq, l, minIdx - 1));
            if (minIdx + 1 < rmq.Count && minIdx + 1 <= r)
                maxRect = Math.Max(maxRect, LargestRec(rmq, minIdx + 1, r));
            return maxRect;
        }
    }
}
