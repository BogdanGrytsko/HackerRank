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

    // Complete the formingMagicSquare function below.
    static int formingMagicSquare(int[][] s)
    {
        var list = new List<List<List<int>>> {
            new List<List<int>>
            {
                new List<int> { 8, 1 ,6 },
                new List<int> { 3, 5 ,7 },
                new List<int> { 4, 9 ,2 },
            },
            new List<List<int>>
            {
                new List<int> { 6, 1 ,8 },
                new List<int> { 7, 5 ,3 },
                new List<int> { 2, 9 ,4 },
            },
            new List<List<int>>
            {
                new List<int> { 4, 9 ,2 },
                new List<int> { 3, 5 ,7 },
                new List<int> { 8, 1 ,6 },
            },
            new List<List<int>>
            {
                new List<int> { 2, 9 ,4 },
                new List<int> { 7, 5 ,3 },
                new List<int> { 6, 1 ,8 },
            },
            new List<List<int>>
            {
                new List<int> { 8, 3 ,4 },
                new List<int> { 1, 5 ,9 },
                new List<int> { 6, 7 ,2 },
            },
            new List<List<int>>
            {
                new List<int> { 4, 3 ,8 },
                new List<int> { 9, 5 ,1 },
                new List<int> { 2, 7 ,6 },
            },
            new List<List<int>>
            {
                new List<int> { 6, 7 ,2 },
                new List<int> { 1, 5 ,9 },
                new List<int> { 8, 3 ,4 },
            },
            new List<List<int>>
            {
                new List<int> { 2, 7 ,6 },
                new List<int> { 9, 5 ,1 },
                new List<int> { 4, 3 ,8 },
            },
        };

        var minDist = int.MaxValue;
        var dist = 0;
        foreach (var item in list)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    dist += Math.Abs(item[i][j] - s[i][j]);
                }
            }
            minDist = Math.Min(minDist, dist);
            dist = 0;
        }
        return minDist;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int[][] s = new int[3][];

        for (int i = 0; i < 3; i++)
        {
            s[i] = Array.ConvertAll(Console.ReadLine().Split(' '), sTemp => Convert.ToInt32(sTemp));
        }

        int result = formingMagicSquare(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
