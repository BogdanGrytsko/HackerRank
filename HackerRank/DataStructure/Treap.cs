using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.DataStructure
{
    public class Treap
    {
        private class Item
        {
            public int Priority { get; set; }
            public int Value { get; set; }
            public int Count { get; set; }
            public long Sum { get; set; }
            public bool Reverse { get; set; }
            public Item Left, Right;

            public void Swap()
            {
                var x = Left;
                Left = Right;
                Right = x;
            }

            public override string ToString()
            {
                return $"{Value}, C:{Count}, L:{Left?.Value}, R:{Right?.Value}";
            }
        }

        private readonly List<Item> items;
        private Item root;
        private int size;
        private readonly Random random;

        public Treap(int n)
        {
            items = new List<Item>(n);
            for (int i = 0; i < n; i++)
            {
                items.Add(new Item());
            }
            root = null;
            random = new Random();
        }

        private Item Allocate(int value)
        {
            var it = items[size++];
            it.Priority = random.Next();
            it.Value = value;
            it.Sum = value;
            it.Count = 1;
            return it;
        }

        private static int Count(Item t)
        {
            return t != null ? t.Count : 0;
        }

        private static long Sum(Item t)
        {
            return t != null ? t.Sum : 0;
        }

        private static void Revert(Item t)
        {
            if (t != null)
                t.Reverse = !t.Reverse;
        }

        private static void Push(Item t)
        {
            if (t == null) return;
            if (t.Reverse)
            {
                t.Swap();
                Revert(t.Left);
                Revert(t.Right);
                Revert(t);
            }
        }

        private static void Update(Item t)
        {
            if (t == null) return;
            t.Count = Count(t.Left) + Count(t.Right) + 1;
            t.Sum = Sum(t.Left) + Sum(t.Right) + t.Value;
        }

        private static void Split(Item t, int key, ref Item l, ref Item r)
        {
            Push(t);
            if (t == null)
            {
                l = r = null;
                return;
            }
            var leftCount = Count(t.Left);
            if (leftCount < key)
            {
                Split(t.Right, key - leftCount - 1, ref t.Right, ref r);
                l = t;
            }
            else
            {
                Split(t.Left, key, ref l, ref t.Left);
                r = t;
            }
            Update(l);
            Update(r);
        }

        private static Item Merge(Item l, Item r)
        {
            Push(l);
            Push(r);
            if (l == null || r == null)
                return l == null ? r : l;
            Item t;
            if (l.Priority > r.Priority)
            {
                l.Right = Merge(l.Right, r);
                t = l;
            }
            else
            {
                r.Left = Merge(l, r.Left);
                t = r;
            }
            Update(t);
            return t;
        }

        public long Sum(int l, int r)
        {
            Item p1 = null, p2 = null, p3 = null;
            Split(root, r + 1, ref p2, ref p3);
            Split(p2, l, ref p1, ref p2);
            var ans = Sum(p2);
            root = Merge(p1, Merge(p2, p3));
            return ans;
        }

        public void Reverse(int l, int r)
        {
            Item p1 = null, p2 = null, p3 = null;
            Split(root, r + 1, ref p2, ref p3);
            Split(p2, l, ref p1, ref p2);
            Revert(p2);
            root = Merge(p1, Merge(p2, p3));
        }

        public void Append(int value)
        {
            var t = Allocate(value);
            root = Merge(root, t);
        }

        public IEnumerable<int> InOrder()
        {
            return InOrder(root);
        }

        private static IEnumerable<int> InOrder(Item t)
        {
            if (t == null) yield break;
            Push(t);
            foreach (var item in InOrder(t.Left))
                yield return item;
            yield return t.Value;
            foreach (var item in InOrder(t.Right))
                yield return item;
        }

        public static void TSwap(ref Treap t1, int l1, int r1, ref Treap t2, int l2, int r2)
        {
            Item p1 = null, p2 = null, p3 = null, q1 = null, q2 = null, q3 = null;
            Split(t1.root, r1 + 1, ref p2, ref p3);
            Split(p2, l1, ref p1, ref p2);

            Split(t2.root, r2 + 1, ref q2, ref q3);
            Split(q2, l2, ref q1, ref q2);

            t1.root = Merge(p1, Merge(q2, p3));
            t2.root = Merge(q1, Merge(p2, q3));
        }
    }
}
