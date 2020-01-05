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
using HackerRank;

class Solution
{
    static long triplets(int[] a, int[] b, int[] c)
    {
        return new TripleSum().Solve(a, b, c);
    }

    public class TripleSum
    {
        public long Solve(int[] a, int[] b, int[] c)
        {
            a = new SortedSet<int>(a).ToArray();
            b = new SortedSet<int>(b).ToArray();
            c = new SortedSet<int>(c).ToArray();
            Array.Sort(a);
            Array.Sort(b);
            Array.Sort(c);
            long cnt = 0;
            for (int i = 0; i < b.Length; i++)
            {
                var el = b[i];
                var smallerCnta = FindSmallerEqualCnt(a, el);
                var smallerCntc = FindSmallerEqualCnt(c, el);
                cnt += (long)smallerCnta * smallerCntc;
            }
            return cnt;
        }

        public static int FindSmallerEqualCnt(int[] arr, int elem)
        {
            return FindSmallerEqualCnt(arr, elem, 0, arr.Length - 1);
        }

        private static int FindSmallerEqualCnt(int[] arr, int elem, int l, int r)
        {
            var mid = (l + r) / 2;
            if (arr[mid] <= elem)
            {
                if (mid == arr.Length - 1 || arr[mid + 1] > elem)
                    return mid + 1;
                return FindSmallerEqualCnt(arr, elem, mid + 1, r);
            }
            else
            {
                if (mid == 0)
                    return 0;
                return FindSmallerEqualCnt(arr, elem, l, mid);
            }
        }

        public static int FindBiggerEqualCnt(int[] arr, int elem)
        {
            return FindBiggerEqualCnt(arr, elem, 0, arr.Length - 1);
        }

        private static int FindBiggerEqualCnt(int[] arr, int elem, int l, int r)
        {
            var mid = (l + r) / 2;
            if (arr[mid] < elem)
            {
                if (mid == arr.Length - 1)
                    return 0;
                return FindBiggerEqualCnt(arr, elem, mid + 1, r);
            }
            else
            {
                if (mid == 0 || arr[mid - 1] < elem)
                    return arr.Length - mid;
                return FindBiggerEqualCnt(arr, elem, l, mid);
            }
        }
    }

    static void Main(string[] args)
    {
        var path = Environment.GetEnvironmentVariable("OUTPUT_PATH");
        TextWriter textWriter = new StreamWriter(path, true);

        var lines = File.ReadAllLines(path.Replace("Results", "Input"));
        string[] lenaLenbLenc = lines[0].Split(' ');

        int lena = Convert.ToInt32(lenaLenbLenc[0]);

        int lenb = Convert.ToInt32(lenaLenbLenc[1]);

        int lenc = Convert.ToInt32(lenaLenbLenc[2]);

        int[] arra = Array.ConvertAll(lines[1].Split(' '), arraTemp => Convert.ToInt32(arraTemp))
        ;

        int[] arrb = Array.ConvertAll(lines[2].Split(' '), arrbTemp => Convert.ToInt32(arrbTemp))
        ;

        int[] arrc = Array.ConvertAll(lines[3].Split(' '), arrcTemp => Convert.ToInt32(arrcTemp))
        ;
        long ans = triplets(arra, arrb, arrc);

        textWriter.WriteLine(ans);

        textWriter.Flush();
        textWriter.Close();
    }
}
