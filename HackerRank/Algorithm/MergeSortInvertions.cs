using System;

namespace HackerRank.Algorithm
{
    public class MergeSortInvertions
    {
        public long MergeAndCount(int[] a)
        {
            return MergeAndCount(a, 0, a.Length - 1, new int[a.Length]);
        }

        private long MergeAndCount(int[] a, int l, int r, int[] c)
        {
            if (l == r) return 0;
            var mid = (l + r) / 2;
            long cnt = 0;
            cnt += MergeAndCount(a, l, mid, c);
            cnt += MergeAndCount(a, mid + 1, r, c);
            cnt += Merge(a, l, mid, r, c);
            return cnt;
        }

        private long Merge(int[] a, int l, int mid, int r, int[] c)
        {
            //result gets stored in c, then copy back to A
            long invCount = 0;
            var lIdx = l;
            var rIdx = mid + 1;
            var idx = 0;
            while (lIdx <= mid && rIdx <= r)
            {
                if (a[lIdx] <= a[rIdx])
                {
                    c[idx] = a[lIdx];
                    lIdx++;
                }
                else
                {
                    c[idx] = a[rIdx];
                    rIdx++;
                    invCount += mid - lIdx + 1;
                }
                idx++;
            }
            Array.Copy(a, lIdx, c, idx, mid - lIdx + 1);
            Array.Copy(a, rIdx, c, idx, r - rIdx + 1);
            Array.Copy(c, 0, a, l, r - l + 1);
            return invCount;
        }
    }
}
