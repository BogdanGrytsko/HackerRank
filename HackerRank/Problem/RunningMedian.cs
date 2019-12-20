using HackerRank.DataStructure;
using System;
using System.Collections.Generic;

namespace HackerRank.Problem
{
    public class RunningMedian
    {
        private readonly Heap minHeap = new Heap();
        private readonly Heap maxHeap = new Heap(true);

        public IEnumerable<double> Solve(IEnumerable<int> values)
        {
            foreach (var val in values)
            {
                yield return Solve(val);
            }
        }

        private double Solve(int val)
        {
            if (maxHeap.Count > 0 && val < maxHeap.Peek)
                maxHeap.Add(val);
            else
                minHeap.Add(val);
            //balance
            while (Math.Abs(minHeap.Count - maxHeap.Count) > 1)
            {
                if (maxHeap.Count > minHeap.Count)
                    minHeap.Add(maxHeap.Pop());
                else
                    maxHeap.Add(minHeap.Pop());
            }
            if ((maxHeap.Count + minHeap.Count) % 2 == 1)
            {
                if (maxHeap.Count > minHeap.Count)
                    return maxHeap.Peek;
                else
                    return minHeap.Peek;
            }
            else
            {
                return Math.Round((double)(maxHeap.Peek + minHeap.Peek) / 2, 1);
            }
        }
    }
}
