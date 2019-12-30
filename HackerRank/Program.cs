using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

class Solution
{

    // Complete the freqQuery function below.
    static IEnumerable<int> freqQuery(List<List<int>> queries)
    {
        var valDic = new Dictionary<int, long>();
        var freqDic = new Dictionary<long, HashSet<int>>();
        for (int j = 0; j < queries.Count; j++)
        {
            var query = queries[j];
            var val = query[1];
            if (query[0] == 1)
            {
                long prevFreq = -1;
                if (!valDic.ContainsKey(val) || valDic[val] == 0)
                    valDic[val] = 1;
                else
                {
                    prevFreq = valDic[val];
                    valDic[val]++;
                }
                var freq = valDic[val];
                if (!freqDic.ContainsKey(freq))
                    freqDic.Add(freq, new HashSet<int> { val });
                else
                    freqDic[freq].Add(val);

                if (prevFreq != -1)
                    freqDic[prevFreq].Remove(val);
            }
            else if (query[0] == 2)
            {
                if (!valDic.ContainsKey(val) || valDic[val] == 0) continue;
                var freq = valDic[val];
                valDic[val]--;
                freqDic[freq].Remove(val);
                if (freq > 1)
                    freqDic[freq - 1].Add(val);
            }
            else if (query[0] == 3)
            {
                HashSet<int> freqSet;
                if (freqDic.TryGetValue(val, out freqSet) && freqSet.Any())
                    yield return 1;
                else
                    yield return 0;
            }
        }
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<int>> queries = new List<List<int>>();

        for (int i = 0; i < q; i++)
        {
            queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
        }

        List<int> ans = freqQuery(queries).ToList();

        textWriter.WriteLine(String.Join("\n", ans));

        textWriter.Flush();
        textWriter.Close();
    }
}
