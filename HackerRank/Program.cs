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
        public class LongestCommonSubsequence
    {
        public int LCS(string s1, string s2)
        {
            return LCS(s1, s1.Length, s2, s2.Length);
        }

        private int LCS(string s1, int idx1, string s2, int idx2)
        {
            var table = new int[s1.Length + 1, s2.Length + 1];
            for (int i = 0; i <= s1.Length; i++)
            {
                for (int j = 0; j <= s2.Length; j++)
                {
                    if (i == 0 || j == 0)
                        table[i, j] = 0;
                    else if (s1[i - 1] == s2[j - 1])
                        table[i, j] = table[i - 1, j - 1] + 1;
                    else
                        table[i, j] = Math.Max(table[i - 1, j], table[i, j - 1]);
                }
            }
            return table[idx1, idx2];
        }
    }

    // Complete the commonChild function below.
    static int commonChild(string s1, string s2)
    {
        return new LongestCommonSubsequence().LCS(s1, s2);
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s1 = Console.ReadLine();

        string s2 = Console.ReadLine();

        int result = commonChild(s1, s2);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
