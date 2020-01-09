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

    // Complete the minimumPasses function below.
    static ulong minimumPasses(ulong m, ulong w, ulong p, ulong n)
    {
        ulong leftovers = 0;
        ulong iter = 0;
        ulong iterIfJustProd = long.MaxValue;
        while (leftovers < n)
        {
            iter++;
            ulong thisDay;
            try
            {
                thisDay = checked(m * w);
                leftovers = checked(leftovers + thisDay);
            }
            catch (OverflowException)
            {
                break;
            }
            if (leftovers >= n)
                break;
            var canBuyCnt = leftovers / p;
            if (canBuyCnt == 0)
            {
                var fastForwardDays = DaysToProduce(p, thisDay) - 2;
                iter += fastForwardDays;
                leftovers += fastForwardDays * thisDay;
                continue;
            }

            iterIfJustProd = Math.Min(iterIfJustProd, iter + DaysToProduce(n - leftovers, thisDay));
            leftovers -= canBuyCnt * p;
            var diff = (m - w) >= 0 ? m - w : w - m;
            if (m <= w)
            {
                if (canBuyCnt <= diff)
                {
                    m += canBuyCnt;
                    canBuyCnt = 0;
                }
                else
                {
                    m += diff;
                    canBuyCnt -= diff;
                }
            }
            else
            {
                if (canBuyCnt <= diff)
                {
                    w += canBuyCnt;
                    canBuyCnt = 0;
                }
                else
                {
                    w += diff;
                    canBuyCnt -= diff;
                }
            }
            if (canBuyCnt != 0)
            {
                m += canBuyCnt / 2 + canBuyCnt % 2;
                w += canBuyCnt / 2;
            }
        }
        return Math.Min(iter, iterIfJustProd);
    }

    private static ulong DaysToProduce(ulong desired, ulong perDay)
    {
        var x = desired / perDay;
        if (desired % perDay == 0)
            return x;
        return x + 1;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] mwpn = Console.ReadLine().Split(' ');

        var m = Convert.ToUInt64(mwpn[0]);

        var w = Convert.ToUInt64(mwpn[1]);

        var p = Convert.ToUInt64(mwpn[2]);

        var n = Convert.ToUInt64(mwpn[3]);

        var result = minimumPasses(m, w, p, n);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
