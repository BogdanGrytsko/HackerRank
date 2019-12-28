using System;
using System.Collections;
using System.Collections.Generic;

public class AVLTree : IEnumerable<int>
{
    public class AVLNode
    {
        public int Key { get; set; }
        public int Height { get; set; }
        public int Count { get; set; }
        public int SameKeyCnt { get; set; }
        public AVLNode Left { get; set; }
        public AVLNode Right { get; set; }

        public AVLNode(int key)
        {
            Key = key;
            Height = 1;
            Count = 1;
            SameKeyCnt = 1;
        }

        public override string ToString()
        {
            return $"K: {Key}, H:{Height}, C:{Count}";
        }
    }

    private AVLNode root;

    private static int Height(AVLNode n)
    {
        return n == null? 0 : n.Height;
    }

    private static int Count(AVLNode n)
    {
        return n == null ? 0 : n.Count;
    }

    private static AVLNode RightRotate(AVLNode y)
    {
        var x = y.Left;
        var T2 = x.Right;

        x.Right = y;
        y.Left= T2;

        Update(y);
        Update(x);
        return x;
    }

    public double GetMedian()
    {
        if (root == null)
            return double.NaN;
        return GetMedian(root, 0, 0);
    }

    private double GetMedian(AVLNode n, int lSeed, int rSeed)
    {
        var lc = Count(n.Left) + lSeed;
        var rc = Count(n.Right) + rSeed;
        if (Math.Abs(lc - rc) <= n.SameKeyCnt - 1)
            return n.Key;
        if (lc + n.SameKeyCnt == rc)
            return ((double)n.Key + LeftMost(n.Right).Key) / 2;
        if (lc == n.SameKeyCnt + rc)
            return ((double)n.Key + RightMost(n.Left).Key) / 2;
        if (lc > rc)
            return GetMedian(n.Left, lSeed, rc + n.SameKeyCnt);
        if (lc < rc)
            return GetMedian(n.Right, lc + n.SameKeyCnt, rSeed);
        throw new Exception("Should never happen");
    }

    private static void Update(AVLNode n)
    {
        n.Height = Math.Max(Height(n.Left), Height(n.Right)) + 1;
        n.Count = Count(n.Left) + Count(n.Right) + n.SameKeyCnt;
    }

    private static AVLNode LeftRotate(AVLNode x)
    {
        var y = x.Right;
        var T2 = y.Left;

        y.Left= x;
        x.Right = T2;

        Update(x);
        Update(y);
        return y;
    }

    private static int GetBalance(AVLNode n)
    {
        if (n == null)
            return 0;
        return Height(n.Left) - Height(n.Right);
    }

    public void Add(int key)
    {
        root = Insert(root, key);
    }

    private AVLNode Insert(AVLNode n, int key)
    {
        if (n == null)
            return new AVLNode(key);

        if (key < n.Key)
            n.Left = Insert(n.Left, key);
        else if (key > n.Key)
            n.Right = Insert(n.Right, key);
        else
            n.SameKeyCnt++;

        Update(n);

        int balance = GetBalance(n);

        if (balance > 1 && key <= n.Left.Key)
            return RightRotate(n);
        if (balance < -1 && key > n.Right.Key)
            return LeftRotate(n);
        if (balance > 1 && key > n.Left.Key)
        {
            n.Left = LeftRotate(n.Left);
            return RightRotate(n);
        }
        if (balance < -1 && key <= n.Right.Key)
        {
            n.Right = RightRotate(n.Right);
            return LeftRotate(n);
        }
        return n;
    }

    private static AVLNode LeftMost(AVLNode node)
    {
        var current = node;
        while (current.Left != null)
            current = current.Left;
        return current;
    }

    private static AVLNode RightMost(AVLNode node)
    {
        var current = node;
        while (current.Right != null)
            current = current.Right;
        return current;
    }

    public void Delete(int key)
    {
        root = DeleteNode(root, key);
    }

    public bool Exists(int key)
    {
        return Exists(root, key);
    }

    private bool Exists(AVLNode node, int key)
    {
        if (node == null) return false;
        if (node.Key == key)
            return true;
        if (node.Key > key)
            return Exists(node.Left, key);
        return Exists(node.Right, key);
    }

    private AVLNode DeleteNode(AVLNode root, int key)
    {
        if (root == null)
            return root;

        if (key < root.Key)
            root.Left= DeleteNode(root.Left, key);
        else if (key > root.Key)
            root.Right = DeleteNode(root.Right, key);
        else if (root.SameKeyCnt > 1)
        {
            root.SameKeyCnt--;
        }
        else
        {
            if ((root.Left== null) || (root.Right == null))
            {
                AVLNode temp = null;
                if (temp == root.Left)
                    temp = root.Right;
                else
                    temp = root.Left;

                if (temp == null)
                {
                    temp = root;
                    root = null;
                }
                else 
                    root = temp; 
            }
            else
            {
                var temp = LeftMost(root.Right);
                root.Key = temp.Key;
                root.Right = DeleteNode(root.Right, temp.Key);
            }
        }

        if (root == null)
            return root;

        Update(root);

        int balance = GetBalance(root);

        if (balance > 1 && GetBalance(root.Left) >= 0)
            return RightRotate(root);
        if (balance > 1 && GetBalance(root.Left) < 0)
        {
            root.Left= LeftRotate(root.Left);
            return RightRotate(root);
        }
        if (balance < -1 && GetBalance(root.Right) <= 0)
            return LeftRotate(root);
        if (balance < -1 && GetBalance(root.Right) > 0)
        {
            root.Right = RightRotate(root.Right);
            return LeftRotate(root);
        }

        return root;
    }

    public IEnumerable<int> InOrder()
    {
        return InOrder(root);
    }

    public IEnumerable<int> InOrder(AVLNode node)
    {
        if (node == null)
            yield break;
        foreach (var v in InOrder(node.Left))
            yield return v;
        for (int i = 0; i < node.SameKeyCnt; i++)
            yield return node.Key;
        foreach (var v in InOrder(node.Right))
            yield return v;
    }

    public IEnumerator<int> GetEnumerator()
    {
        return InOrder().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return InOrder().GetEnumerator();
    }
}
