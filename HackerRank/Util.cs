using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HackerRank
{
    public class Util
    {
        public void Main()
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] nq = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nq[0]);

            int q = Convert.ToInt32(nq[1]);

            int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp));

            int[][] queries = new int[q][];

            for (int queriesRowItr = 0; queriesRowItr < q; queriesRowItr++)
            {
                queries[queriesRowItr] = Array.ConvertAll(Console.ReadLine().Split(' '), queriesTemp => Convert.ToInt32(queriesTemp));
            }

            var result = new int[0];

            textWriter.WriteLine(string.Join("\n", result));

            textWriter.Flush();
            textWriter.Close();
        }

        public static void ReadFromFile()
        {
            var path = Environment.GetEnvironmentVariable("OUTPUT_PATH");
            TextWriter textWriter = new StreamWriter(path, true);

            var lines = File.ReadAllLines(path.Replace("Results", "Input"));
            string[] nr = lines[0].TrimEnd().Split(' ');

            int n = Convert.ToInt32(nr[0]);

            long r = Convert.ToInt64(nr[1]);

            List<long> arr = lines[1].TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt64(arrTemp)).ToList();

            long ans = -1;

            textWriter.WriteLine(ans);

            textWriter.Flush();
            textWriter.Close();
        }

        public static void AddToDic<TKey>(IDictionary<TKey, long> dic, TKey key)
        {
            if (dic.ContainsKey(key))
                dic[key]++;
            else
                dic[key] = 1;
        }
    }
}
