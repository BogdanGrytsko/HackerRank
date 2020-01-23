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

    // Complete the largestPermutation function below.
    static int[] largestPermutation(int k, int[] arr)
    {
        int j = 0;
        var dic = arr.ToDictionary(el => el, el => j++);
        var currIdx = 0;
        for (int i = arr.Length; i > 0; i--)
        {
            var idx = dic[i];
            if (idx == currIdx) 
            {
                currIdx++;
                continue;
            }
            //swap
            var tmp = arr[idx];
            arr[idx] = arr[currIdx];
            arr[currIdx] = tmp;

            dic[arr[currIdx]] = currIdx;
            dic[arr[idx]] = idx;
            currIdx++;
            k--;
            if (k == 0) break;
        }
        return arr;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nk = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nk[0]);

        int k = Convert.ToInt32(nk[1]);

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        ;
        int[] result = largestPermutation(k, arr);

        textWriter.WriteLine(string.Join(" ", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
