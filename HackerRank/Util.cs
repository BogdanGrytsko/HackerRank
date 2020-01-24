using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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
            Util.Download("https://hr-testcases-us-east-1.s3.amazonaws.com/71636/input07.txt?AWSAccessKeyId=AKIAJ4WZFDFQTZRGO3QA&Expires=1577733342&Signature=T0JspNUmq%2FnBhz34lvaXKKkCJbI%3D&response-content-type=text%2Fplain", path.Replace("Results", "Input"));
            Util.Download("https://hr-testcases-us-east-1.s3.amazonaws.com/71636/output07.txt?AWSAccessKeyId=AKIAJ4WZFDFQTZRGO3QA&Expires=1577733355&Signature=v3Uzk5BDj4dOy3x7e92mGHfx6LU%3D&response-content-type=text%2Fplain", path.Replace("Results", "Expected"));
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

        public static void Download(string url, string filePath) 
        {
            var cl = new HttpClient();
            var res = cl.GetStringAsync(url).Result;
            File.WriteAllText(filePath, res);
        }

        public static void WriteMatrix(int[,] matrix)
        {
            var path = Environment.GetEnvironmentVariable("OUTPUT_PATH");
            var build = new StringBuilder();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] != -1)
                        build.Append($" {matrix[i, j].ToString("00")}");
                    else
                        build.Append(" XX");
                }
                build.AppendLine();
            }
            var newPath = path.Replace("Output", "Matrix");
            File.WriteAllText(newPath, build.ToString());
        }
    }
}
