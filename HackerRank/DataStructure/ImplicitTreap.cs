using System;
using System.Collections;
using System.Collections.Generic;

namespace HackerRank.DataStructure
{
    public class ImplicitTreap : IEnumerable<int>
    {
        public class TreapNode
        {
            public int Priority { get; set; }
            public int Value { get; set; }
            public int Count { get; set; }
            public long Sum { get; set; }
            public bool Reverse { get; set; }
            public TreapNode Left, Right, Parent;

            public void Swap()
            {
                var x = Left;
                Left = Right;
                Right = x;
            }

            public override string ToString()
            {
                return $"{Value}, C:{Count}, L:{Left?.Value}, R:{Right?.Value}, P:{Parent?.Value}";
            }
        }

        private int size;
        private readonly Random random;

        public TreapNode Root { get; set; }

        public ImplicitTreap(int n) 
        {
            Nodes = new List<TreapNode>(n);
            for (int i = 0; i < n; i++)
            {
                Nodes.Add(new TreapNode());
            }
            Root = null;
            random = new Random();
        }

        private TreapNode Allocate(int value)
        {
            var it = Nodes[size++];
            it.Priority = random.Next();
            it.Value = value;
            it.Sum = value;
            it.Count = 1;
            return it;
        }

        private static int Count(TreapNode t)
        {
            return t != null ? t.Count : 0;
        }

        private static long Sum(TreapNode t)
        {
            return t != null ? t.Sum : 0;
        }

        private static void Revert(TreapNode t)
        {
            if (t != null)
                t.Reverse = !t.Reverse;
        }

        private static void Push(TreapNode t)
        {
            if (t == null) return;
            if (t.Reverse)
            {
                t.Reverse = false;
                t.Swap();
                Revert(t.Left);
                Revert(t.Right);
            }
        }

        public int GetIdx(TreapNode node)
        {
            PushUp(node);
            return GetIdxInternal(node);
        }

        private void PushUp(TreapNode node)
        {
            if (node.Parent != null)
                PushUp(node.Parent);
            Push(node);
        }

        private int GetIdxInternal(TreapNode node)
        {
            if (node.Parent == null)
                return Count(node.Left);
            if (node.Parent.Left == node)
                return GetIdxInternal(node.Parent) - Count(node.Right) - 1;
            else
                return GetIdxInternal(node.Parent) + Count(node.Left) + 1;
        }

        private static void Update(TreapNode t)
        {
            if (t == null) return;
            t.Count = Count(t.Left) + Count(t.Right) + 1;
            t.Sum = Sum(t.Left) + Sum(t.Right) + t.Value;
        }

        public static void Split(TreapNode t, int key, ref TreapNode l, ref TreapNode r)
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

        public static TreapNode Merge(TreapNode l, TreapNode r)
        {
            TreapNode t;
            Push(l);
            Push(r);
            if (l == null || r == null)
                t = l != null ? l : r;
            else if (l.Priority > r.Priority)
            {
                l.Right = Merge(l.Right, r);
                l.Right.Parent = l;
                t = l;
            }
            else
            {
                r.Left = Merge(l, r.Left);
                r.Left.Parent = r;
                t = r;
            }
            Update(t);
            return t;
        }

        public long Sum(int l, int r)
        {
            TreapNode p1 = null, p2 = null, p3 = null;
            Split(Root, r + 1, ref p2, ref p3);
            Split(p2, l, ref p1, ref p2);
            var ans = Sum(p2);
            Root = Merge(p1, Merge(p2, p3));
            return ans;
        }

        public long this[int idx]
        {
            get
            {
                TreapNode p1 = null, p2 = null, p3 = null;
                Split(Root, idx + 1, ref p2, ref p3);
                Split(p2, idx, ref p1, ref p2);
                var ans = p2.Value;
                Root = Merge(p1, Merge(p2, p3));
                return ans;
            }
        }

        public void Reverse(int l, int r)
        {
            CheckParent(Root);
            TreapNode p1 = null, p2 = null, p3 = null;
            Split(Root, r + 1, ref p2, ref p3);
            CheckParent(Root);
            Split(p2, l, ref p1, ref p2);
            CheckParent(Root);
            Revert(p2);
            CheckParent(Root);
            Root = Merge(p1, Merge(p2, p3));
            CheckParent(Root);
        }

        public void Add(int value)
        {
            var t = Allocate(value);
            Root = Merge(Root, t);
        }

        public IEnumerable<int> InOrder()
        {
            return InOrder(Root);
        }

        private static IEnumerable<int> InOrder(TreapNode t)
        {
            if (t == null) yield break;
            Push(t);
            foreach (var item in InOrder(t.Left))
                yield return item;
            yield return t.Value;
            foreach (var item in InOrder(t.Right))
                yield return item;
        }



        public List<TreapNode> Nodes { get; }

        public IEnumerator<int> GetEnumerator()
        {
            return InOrder().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return InOrder().GetEnumerator();
        }

        private static void CheckParent(TreapNode node)
        {
            if (node == null) return;
            if ((node.Left != null && node.Left.Parent != node) || (node.Right != null) && node.Right.Parent != node)
                throw new Exception("bad parent");
            CheckParent(node.Left);
            CheckParent(node.Right);
        }
    }
}
