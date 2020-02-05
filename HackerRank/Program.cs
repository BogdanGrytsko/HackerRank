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

    // Complete the maxRegion function below.
    static int maxRegion(int[][] grid, int n, int m)
    {
        var set = new HashSet<(int, int)>();
        var max = int.MinValue;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                var que = new Queue<(int, int)>();
                que.Enqueue((i, j));
                var reg = BFS(grid, n, m, set, que);
                max = Math.Max(max, reg);
            }
        }
        return max;
    }

    private static int BFS(int[][] grid, int n, int m, HashSet<(int, int)> set, Queue<(int i, int j)> queue)
    {
        int c = 0;
        while (queue.Any())
        {
            var x = queue.Dequeue();
            if (set.Contains(x) || x.i < 0 || x.i >= n || x.j < 0 || x.j >= m || grid[x.i][x.j] == 0) continue;
            c++;
            set.Add(x);
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    queue.Enqueue((x.i + i, x.j + j));
                }
            }
        }
        return c;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int m = Convert.ToInt32(Console.ReadLine());

        int[][] grid = new int[n][];

        for (int i = 0; i < n; i++)
        {
            grid[i] = Array.ConvertAll(Console.ReadLine().Split(' '), gridTemp => Convert.ToInt32(gridTemp));
        }

        int res = maxRegion(grid, n, m);

        textWriter.WriteLine(res);

        textWriter.Flush();
        textWriter.Close();
    }
}
