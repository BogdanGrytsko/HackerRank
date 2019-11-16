using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class ExplicitTreap
{
    public class Item
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

    public ExplicitTreap(int n)
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

    public static void TSwap(ref ExplicitTreap t1, int l1, int r1, ref ExplicitTreap t2, int l2, int r2)
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

class Solution
{
    static IEnumerable<long> solve(int[] a, int[][] queries)
    {
        var treapCount = 2;
        var treaps = new ExplicitTreap[treapCount];
        for (int i = 0; i < treapCount; i++)
            treaps[i] = new ExplicitTreap(100000);
        for (int i = 0; i < a.Length; i++)
            treaps[i % treapCount].Append(a[i]);
        foreach (var query in queries)
        {
            var l = query[1] - 1;
            var r = query[2] - 1;
            var t = query[0];

            var ql = new int[treapCount];
            var qr = new int[treapCount];
            for (int i = 0; i < treapCount; i++)
            {
                if (l == r && l % 2 != i)
                {
                    ql[i] = 0;
                    qr[i] = -1;
                }
                else
                {
                    ql[i] = (l % 2 == i) ? l / 2 : (l + 1) / 2;
                    qr[i] = (r % 2 == i) ? r / 2 : (r - 1) / 2;
                }
            }

            if (t == 1)
                ExplicitTreap.TSwap(ref treaps[0], ql[0], qr[0], ref treaps[1], ql[1], qr[1]);
            else
            {
                long ans = 0;
                for (int i = 0; i < treapCount; i++)
                {
                    if (ql[i] <= qr[i])
                        ans += treaps[i].Sum(ql[i], qr[i]);
                }
                yield return ans;
            }
        }
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nq = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nq[0]);

        int q = Convert.ToInt32(nq[1]);

        int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp))
        ;

        int[][] queries = new int[q][];

        for (int queriesRowItr = 0; queriesRowItr < q; queriesRowItr++)
        {
            queries[queriesRowItr] = Array.ConvertAll(Console.ReadLine().Split(' '), queriesTemp => Convert.ToInt32(queriesTemp));
        }

        var result = solve(a, queries).ToArray();

        textWriter.WriteLine(string.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
