using System.Collections.Generic;
using System.Linq;

namespace HackerRank.Problem
{
    public class CastleOnTheGrid
    {
        public static int minimumMoves(string[] grid, int startX, int startY, int goalX, int goalY)
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

            return matrix[goalX, goalY] - 1;
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
                foreach (var p in GetNeibours(matrix, (x, y)))
                {
                    Enqueue(matrix, queue, (p.x, p.y, mark + 1));
                }
                BFS(matrix, queue, goal);
            }
        }

        private static IEnumerable<(int x, int y)> GetNeibours(int[,] matrix, (int x, int y) p)
        {
            var n = matrix.GetLength(0);
            var m = matrix.GetLength(1);
            for (int i = p.x + 1; i < n; i++)
            {
                var c = (i, p.y);
                if (InBound(matrix, c))
                    yield return c;
                else
                    break;
            }

            for (int i = p.x - 1; i >= 0; i--)
            {
                var c = (i, p.y);
                if (InBound(matrix, c))
                    yield return c;
                else
                    break;
            }

            for (int i = p.y + 1; i < m; i++)
            {
                var c = (p.x, i);
                if (InBound(matrix, c))
                    yield return c;
                else
                    break;
            }

            for (int i = p.y - 1; i >= 0; i--)
            {
                var c = (p.x, i);
                if (InBound(matrix, c))
                    yield return c;
                else
                    break;
            }
        }

        private static bool InBound(int[,] matrix, (int x, int y) p)
        {
            return p.x >= 0 && p.x < matrix.GetLength(0) && p.y >= 0 && p.y < matrix.GetLength(1) && matrix[p.x, p.y] == 0;
        }

        private static void Enqueue(int[,] matrix, Queue<(int, int, int)> queue, (int x, int y, int mark) p)
        {
            if (!InBound(matrix, (p.x, p.y)))
                return;
            queue.Enqueue(p);
        }
    }
}
