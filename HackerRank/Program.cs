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

    // Complete the connectedCell function below.
    static int connectedCell(int[][] matrix, int n, int m)
    {
        var traversed = new HashSet<Tuple<int, int>>();
        var areas = new List<int>();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                var area = 0;
                BFS(matrix, i, j, traversed, n, m, ref area);
                if (area != 0)
                    areas.Add(area);
            }
        }
        return areas.Max();
    }

    private static void BFS(int[][] matrix, int i, int j, HashSet<Tuple<int, int>> traversed, int n, int m, ref int area)
    {
        var cell = Tuple.Create(i, j);
        if (traversed.Contains(cell) || matrix[i][j] == 0)
            return;
        traversed.Add(cell);
        area++;
        for (int ii = -1; ii <= 1; ii++)
        {
            for (int jj = -1; jj <= 1; jj++)
            {
                var x = i + ii;
                var y = j + jj;
                if (x >= 0 && x < n && y >= 0 && y < m)
                    BFS(matrix, x, y, traversed, n, m, ref area);
            }
        }
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int m = Convert.ToInt32(Console.ReadLine());

        int[][] matrix = new int[n][];

        for (int i = 0; i < n; i++)
        {
            matrix[i] = Array.ConvertAll(Console.ReadLine().Split(' '), matrixTemp => Convert.ToInt32(matrixTemp));
        }

        int result = connectedCell(matrix, n, m);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
