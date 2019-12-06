using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{
    static int cookies(int k, int[] A)
    {
        var heap = new MinHeap();
        foreach (var item in A)
        {
            heap.Add(item);
        }
        var counter = 0;
        while (heap.Any() && heap.Root < k)
        {
            var item1 = heap.Pop();
            if (!heap.Any())
                return -1;
            var item2 = heap.Pop();
            var newItem = item1 + 2 * item2;
            heap.Add(newItem);
            counter++;
        }
        return counter;
    }

    public class MinHeap
    {
        private readonly List<int> items = new List<int>();

        public void Add(int it)
        {
            items.Add(it);
            FixHeapUp(items.Count - 1);
        }

        private void FixHeapUp(int idx)
        {
            var parentIdx = ParentIdx(idx);
            var parent = items[parentIdx];
            var curr = items[idx];
            if (parent <= curr)
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
            return idx / 2;
        }

        public int Pop()
        {
            return RemoveByIdx(0);
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
            return item;
        }

        private void FixHeapDown(int idx)
        {
            var curr = items[idx];
            var childIdx1 = ChildIdx1(idx);
            if (childIdx1 >= items.Count)
                return;
            var childIdx2 = idx * 2 + 2;
            var childVal1 = items[childIdx1];
            var childVal2 = childIdx2 >= items.Count ? int.MaxValue : items[childIdx2];
            if (curr <= childVal1 && curr <= childVal2)
                return;
            else
            {
                if (childVal1 < childVal2)
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

        private static int ChildIdx1(int idx)
        {
            return idx * 2 + 1;
        }

        public bool Any()
        {
            return items.Any();
        }

        public int Root => items[0];

        public int BruteForce => items.Min();
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nk = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nk[0]);

        int k = Convert.ToInt32(nk[1]);

        int[] A = Array.ConvertAll(Console.ReadLine().Split(' '), ATemp => Convert.ToInt32(ATemp))
        ;
        int result = cookies(k, A);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
