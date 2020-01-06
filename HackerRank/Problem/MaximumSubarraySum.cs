using System;
using System.Collections.Generic;

namespace HackerRank.Problem
{
    public class MaximumSubarraySum
    {
        public long Solve(long[] a, long m)
        {
            var prefixSumArr = GetPrefixSum(a, m);
            var set = new SortedSet<long>();
            long maxSum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                var it = prefixSumArr[i];
                var greaterItems = set.GetViewBetween(it + 1, m + it - maxSum);
                if (greaterItems.Count > 0)
                    maxSum = Math.Max(maxSum, (it - greaterItems.Min + m) % m);
                maxSum = Math.Max(maxSum, it);
                set.Add(it);
            }
            return maxSum;
        }

        private static long[] GetPrefixSum(long[] a, long m)
        {
            var arr = new long[a.Length];
            long sum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                sum = (sum + a[i] % m) % m;
                arr[i] = sum;
            }
            return arr;
        }
    }
}
