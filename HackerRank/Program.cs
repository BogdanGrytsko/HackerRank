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

    // Complete the minimumBribes function below.
    static void minimumBribes(int[] q)
    {
        var bribe = new int[q.Length + 1];
        var bribes = 0;
        for (int i = 0; i < q.Length; i++)
        {
            if (q[i] - i == 1) continue;
            var pos = GetPos(q, i + 1);
            if (!MarkBribed(bribe, q, i, pos))
            {
                Console.WriteLine("Too chaotic");
                return;
            }
            ShiftValueLeft(q, i, pos);
            bribes += pos - i;
        }
        Console.WriteLine(bribes);
    }

    private static int GetPos(int[] q, int value)
    {
        for (int i = value; i < q.Length; i++)
        {
            if (q[i] == value)
                return i;
        }
        throw new NotImplementedException();
    }

    private static void ShiftValueLeft(int[] q, int start, int end)
    {
        var tmp = q[end];
        for (int i = end; i > start; i--)
        {
            q[i] = q[i - 1];
        }
        q[start] = tmp;
    }

    private static bool MarkBribed(int[] bribe, int[] q, int start, int end)
    {
        for (int i = start; i <= end; i++)
        {
            if (++bribe[q[i]] > 2)
                return false;
        }
        return true;
    }

    static void Main(string[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] q = Array.ConvertAll(Console.ReadLine().Split(' '), qTemp => Convert.ToInt32(qTemp))
            ;
            minimumBribes(q);
        }
    }
}
