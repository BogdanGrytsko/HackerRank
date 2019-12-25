using System;
using System.Collections;
using System.Collections.Generic;

namespace HackerRank.DataStructure
{
    public class ImplicitTreap : IEnumerable<int>
    {
        public class Node
        {
            public int Priority { get; set; }
            public int Value { get; set; }
            public int Count { get; set; }
            public long Sum { get; set; }
            public bool Reverse { get; set; }
            public Node Left, Right, Parent;

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

        private Node root;
        private int size;
        private readonly Random random;

        public ImplicitTreap(int n) 
        {
            Nodes = new List<Node>(n);
            for (int i = 0; i < n; i++)
            {
                Nodes.Add(new Node());
            }
            root = null;
            random = new Random();
        }

        private Node Allocate(int value)
        {
            var it = Nodes[size++];
            it.Priority = random.Next();
            it.Value = value;
            it.Sum = value;
            it.Count = 1;
            return it;
        }

        private static int Count(Node t)
        {
            return t != null ? t.Count : 0;
        }

        private static long Sum(Node t)
        {
            return t != null ? t.Sum : 0;
        }

        private static void Revert(Node t)
        {
            if (t != null)
                t.Reverse = !t.Reverse;
        }

        private static void Push(Node t)
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

        public int GetIdx(Node node)
        {
            PushUp(node);
            return GetIdxInternal(node);
        }

        private void PushUp(Node node)
        {
            if (node.Parent != null)
                PushUp(node.Parent);
            Push(node);
        }

        private int GetIdxInternal(Node node)
        {
            if (node.Parent == null)
                return Count(node.Left);
            if (node.Parent.Left == node)
                return GetIdxInternal(node.Parent) - Count(node.Right) - 1;
            else
                return GetIdxInternal(node.Parent) + Count(node.Left) + 1;
        }

        private static void Update(Node t)
        {
            if (t == null) return;
            t.Count = Count(t.Left) + Count(t.Right) + 1;
            t.Sum = Sum(t.Left) + Sum(t.Right) + t.Value;
        }

        private static void Split(Node t, int key, ref Node l, ref Node r)
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

        private static Node Merge(Node l, Node r)
        {
            Node t;
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
            Node p1 = null, p2 = null, p3 = null;
            Split(root, r + 1, ref p2, ref p3);
            Split(p2, l, ref p1, ref p2);
            var ans = Sum(p2);
            root = Merge(p1, Merge(p2, p3));
            return ans;
        }

        public long this[int idx]
        {
            get
            {
                Node p1 = null, p2 = null, p3 = null;
                Split(root, idx + 1, ref p2, ref p3);
                Split(p2, idx, ref p1, ref p2);
                var ans = p2.Value;
                root = Merge(p1, Merge(p2, p3));
                return ans;
            }
        }

        public void Reverse(int l, int r)
        {
            CheckParent(root);
            Node p1 = null, p2 = null, p3 = null;
            Split(root, r + 1, ref p2, ref p3);
            CheckParent(root);
            Split(p2, l, ref p1, ref p2);
            CheckParent(root);
            Revert(p2);
            CheckParent(root);
            root = Merge(p1, Merge(p2, p3));
            CheckParent(root);
        }

        public void Add(int value)
        {
            var t = Allocate(value);
            root = Merge(root, t);
        }

        public IEnumerable<int> InOrder()
        {
            return InOrder(root);
        }

        private static IEnumerable<int> InOrder(Node t)
        {
            if (t == null) yield break;
            Push(t);
            foreach (var item in InOrder(t.Left))
                yield return item;
            yield return t.Value;
            foreach (var item in InOrder(t.Right))
                yield return item;
        }

        public static void TSwap(ref ImplicitTreap t1, int l1, int r1, ref ImplicitTreap t2, int l2, int r2)
        {
            Node p1 = null, p2 = null, p3 = null, q1 = null, q2 = null, q3 = null;
            Split(t1.root, r1 + 1, ref p2, ref p3);
            Split(p2, l1, ref p1, ref p2);

            Split(t2.root, r2 + 1, ref q2, ref q3);
            Split(q2, l2, ref q1, ref q2);

            t1.root = Merge(p1, Merge(q2, p3));
            t2.root = Merge(q1, Merge(p2, q3));
        }

        public List<Node> Nodes { get; }

        public IEnumerator<int> GetEnumerator()
        {
            return InOrder().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return InOrder().GetEnumerator();
        }

        private static void CheckParent(Node node)
        {
            if (node == null) return;
            if ((node.Left != null && node.Left.Parent != node) || (node.Right != null) && node.Right.Parent != node)
                throw new Exception("bad parent");
            CheckParent(node.Left);
            CheckParent(node.Right);
        }
    }
}
