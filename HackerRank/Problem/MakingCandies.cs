using System;

namespace HackerRank.Problem
{
    public class MakingCandies
    {
        public static ulong MinimumPasses(ulong m, ulong w, ulong p, ulong n)
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
                iterIfJustProd = Math.Min(iterIfJustProd, iter + DaysToProduce(n - leftovers, thisDay));

                var canBuyCnt = leftovers / p;
                if (canBuyCnt == 0)
                {
                    var fastForwardDays = DaysToProduce(p - leftovers, thisDay) - 1;
                    iter += fastForwardDays;
                    leftovers += fastForwardDays * thisDay;
                    continue;
                }

                leftovers -= canBuyCnt * p;
                var diff = m > w ? m - w : w - m;
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
    }
}
