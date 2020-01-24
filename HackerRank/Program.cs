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

    // Complete the minimumMoves function below.
    static int minimumMoves(string[] grid, int startX, int startY, int goalX, int goalY)
    {
        var matrix = new int[grid.Length, grid.Length];
        for (int i = 0; i < grid.Length; i++)
        {
            var row = grid[i];
            for (int j = 0; j < row.Length; j++)
            {
                if (row[j] == 'X')
                    matrix[i, j] = -1;
            }
        }
        var queue = new Queue<(int, int, int)>();
        queue.Enqueue((startX, startY, 1));
        BFS(matrix, queue, (goalX, goalY));

        var dirChange = 0;
        var curr = (goalX, goalY);
        var currMark = matrix[goalX, goalY];
        var currDir = 0;
        while (!curr.Equals((startX, startY)))
        {
            foreach (var p in GetNeibours(curr, matrix.GetLength(0), matrix.GetLength(1)))
            {
                if (matrix[p.x, p.y] == currMark - 1)
                {
                    currMark--;
                    curr = (p.x, p.y);
                    var pDir = Math.Abs(p.dir) <= 1 ? 1 : 2;
                    if (pDir != currDir)
                        dirChange++;
                    currDir = pDir;
                    continue;
                }
            }
        }
        Util.WriteMatrix(matrix);
        return dirChange;
    }

    private static void BFS(int[,] matrix, Queue<(int, int, int)> queue, (int, int) goal)
    {
        while (queue.Any())
        {
            var (x, y, mark) = queue.Dequeue();
            if (matrix[x, y] != 0) continue;
            matrix[x, y] = mark;
            if (x == goal.Item1 && y == goal.Item2)
                return;
            foreach (var p in GetNeibours((x, y), matrix.GetLength(0), matrix.GetLength(1)))
            {
                Enqueue(matrix, queue, (p.x, p.y, mark + 1));
            }
            BFS(matrix, queue, goal);
        }
    }

    private static IEnumerable<(int x, int y, int dir)> GetNeibours((int x, int y) p, int n, int m)
    {
        if (p.x + 1 < n)
            yield return (p.x + 1, p.y, 1);
        if (p.x - 1 >= 0)
            yield return (p.x - 1, p.y, -1);
        if (p.y + 1 < m)
            yield return (p.x, p.y + 1, 2);
        if (p.y - 1 >= 0)
            yield return (p.x , p.y - 1, -2);
    }

    private static void Enqueue(int[,] matrix, Queue<(int, int, int)> queue, (int x, int y, int mark) p)
    {
        if (p.x < 0 || p.x >= matrix.GetLength(0) || p.y < 0 || p.y >= matrix.GetLength(1) || matrix[p.x, p.y] != 0)
            return;
        queue.Enqueue(p);
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        string[] grid = new string[n];

        for (int i = 0; i < n; i++)
        {
            string gridItem = Console.ReadLine();
            grid[i] = gridItem;
        }

        string[] startXStartY = Console.ReadLine().Split(' ');

        int startX = Convert.ToInt32(startXStartY[0]);

        int startY = Convert.ToInt32(startXStartY[1]);

        int goalX = Convert.ToInt32(startXStartY[2]);

        int goalY = Convert.ToInt32(startXStartY[3]);

        int result = minimumMoves(grid, startX, startY, goalX, goalY);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
