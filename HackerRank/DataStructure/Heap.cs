using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank.DataStructure
{
    public class Heap : IEnumerable<int>
    {
        private readonly List<int> items = new List<int>();
        private readonly Func<int, int, bool> comp;
        private readonly bool minHeap;

        public Heap()
            : this((i, j) => i <= j)
        {
            minHeap = true;
        }

        public Heap(bool maxHeap)
            : this((i, j) => i >= j)
        {
            minHeap = false;
        }

        private Heap(Func<int, int, bool> comp)
        {
            this.comp = comp;
        }

        public void Add(int it)
        {
            items.Add(it);
            FixHeapUp(items.Count - 1);
#if DEBUG
            CheckHeapProperty(0);
#endif
        }

        private void FixHeapUp(int idx)
        {
            var parentIdx = ParentIdx(idx);
            var parent = items[parentIdx];
            var curr = items[idx];
            if (comp(parent, curr))
                return;
            else
            {
                items[parentIdx] = curr;
                items[idx] = parent;
                FixHeapUp(parentIdx);
            }
        }

        private static int ParentIdx(int idx)
        {
            return (idx - 1) / 2;
        }

        public int Pop()
        {
            return RemoveByIdx(0);
        }

        public int Peek
        {
            get
            {
                return items[0];
            }
        }

        public int Count
        {
            get
            {
                return items.Count;
            }
        }

        public void Remove(int it)
        {
            //this can be improved by using Dictionary
            var idx = items.IndexOf(it);
            RemoveByIdx(idx);
        }

        private int RemoveByIdx(int idx)
        {
            var item = items[idx];
            items[idx] = items[items.Count - 1];
            items.RemoveAt(items.Count - 1);
            if (idx < items.Count)
                FixHeapDown(idx);
#if DEBUG
            CheckHeapProperty(0);
#endif
            return item;
        }

        private void FixHeapDown(int idx)
        {
            var curr = items[idx];
            var childIdx1 = ChildIdx1(idx);
            if (childIdx1 >= items.Count)
                return;
            var childIdx2 = ChildIdx2(idx);
            var childVal1 = items[childIdx1];
            var childVal2 = childIdx2 >= items.Count ? GetMissingVal() : items[childIdx2];
            if (comp(curr, childVal1) && comp(curr, childVal2))
                return;
            else
            {
                if (comp(childVal1, childVal2))
                {
                    items[idx] = childVal1;
                    items[childIdx1] = curr;
                    FixHeapDown(childIdx1);
                }
                else
                {
                    items[idx] = childVal2;
                    items[childIdx2] = curr;
                    FixHeapDown(childIdx2);
                }
            }
        }

        private int GetMissingVal()
        {
            return minHeap ? int.MaxValue : int.MinValue;
        }

        private static int ChildIdx1(int idx)
        {
            return idx * 2 + 1;
        }

        private static int ChildIdx2(int idx)
        {
            return idx * 2 + 2;
        }

        public bool Any()
        {
            return items.Any();
        }

        public int Root => items[0];

        public int BruteForce => minHeap ? items.Min() : items.Max();

        private void CheckHeapProperty(int idx)
        {
            if (idx >= items.Count)
                return;
            var c1 = ChildIdx1(idx);
            var c2 = ChildIdx2(idx);
            if ((c1 < items.Count && !comp(items[idx], items[c1])) || (c2 < items.Count && !comp(items[idx], items[c2])))
                throw new Exception("Heap is bad");
            CheckHeapProperty(c1);
            CheckHeapProperty(c2);
        }

        public IEnumerator<int> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
