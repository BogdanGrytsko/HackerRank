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

    // Complete the substrCount function below.
    static long substrCount(int n, string s)
    {
        var cnt = 0;
        for (int i = 0; i < s.Length; i++)
        {
            var startC = s[i];
            var subCntL = SameCntLength(s, startC, i);
            cnt += subCntL * (subCntL + 1) / 2;
            var subCntR = SameCntLength(s, startC, i + subCntL + 1);
            cnt += Math.Min(subCntL, subCntR);
            i += subCntL - 1;
        }
        return cnt;
    }

    private static int SameCntLength(string s, char startC, int start)
    {
        var sameCnt = 0;
        for (int j = start; j < s.Length; j++)
        {
            if (s[j] == startC)
                sameCnt++;
            else
                break;
        }
        return sameCnt;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        string s = Console.ReadLine();

        long result = substrCount(n, s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
