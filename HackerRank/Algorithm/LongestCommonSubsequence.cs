using System;

namespace HackerRank.Algorithm
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

        public int[] LCS(int[] s1, int[] s2)
        {
            return LCS(s1, s1.Length, s2, s2.Length);
        }

        private static int[] LCS(int[] s1, int idx1, int[] s2, int idx2)
        {
            var t = new int[s1.Length + 1, s2.Length + 1];
            for (int i = 0; i <= s1.Length; i++)
            {
                for (int j = 0; j <= s2.Length; j++)
                {
                    if (i == 0 || j == 0)
                        t[i, j] = 0;
                    else if (s1[i - 1] == s2[j - 1])
                        t[i, j] = t[i - 1, j - 1] + 1;
                    else
                        t[i, j] = Math.Max(t[i - 1, j], t[i, j - 1]);
                }
            }

            // Following code is used to print LCS 
            int index = t[idx1, idx2];
            var lcs = new int[index];

            // Start from the right-most-bottom-most corner 
            // and one by one store characters in lcs[] 
            int k = idx1, l = idx2;
            while (k > 0 && l > 0)
            {
                if (s1[k - 1] == s2[l - 1])
                {
                    lcs[index - 1] = s1[k - 1];
                    k--;
                    l--;
                    index--;
                }

                // If not same, then find the larger of two and 
                // go in the direction of larger value 
                else if (t[k - 1, l] > t[k, l - 1])
                    k--;
                else
                    l--;
            }
            return lcs;
        }
    }
}
