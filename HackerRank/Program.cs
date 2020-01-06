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

    // Complete the maximumSum function below.
    static long maximumSum(long[] a, long m)
    {
        return new MaximumSubarraySum().Solve(a, m);
    }

    public class MaximumSubarraySum
    {
        public long Solve(long[] a, long m)
        {
            var set = new SortedSet<long>();
            long maxSum = 0;
            long sum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                sum = (sum + a[i] % m) % m;
                var greaterItems = set.GetViewBetween(sum + 1, m + sum - maxSum);
                if (greaterItems.Count > 0)
                    maxSum = Math.Max(maxSum, (sum - greaterItems.Min + m) % m);
                maxSum = Math.Max(maxSum, sum);
                set.Add(sum);
            }
            return maxSum;
        }
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string[] nm = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nm[0]);

            long m = Convert.ToInt64(nm[1]);

            long[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt64(aTemp))
            ;
            long result = maximumSum(a, m);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
