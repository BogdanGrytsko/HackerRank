﻿// ReSharper disable IdentifierTypo

using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XTest.Training
{
    //72/93
    //didn't handle int.MinValue
    public class Task1
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(3, Solution("ABDCA", new[] {2, -1, -4, -3, 3}, new[] {2, -2, 4, 1, -3}));
        }

        [Fact]
        public void Test2()
        {
            Assert.Equal(1, Solution("ABB", new[] {1, -2, -2}, new[] {1, -2, 2}));
        }

        [Fact]
        public void Test3()
        {
            Assert.Equal(0, Solution("CCD", new[] {1, -1, 2}, new[] {1, -1, -2}));
        }

        [Fact]
        public void Test4()
        {
            Assert.Equal(4, Solution("ABCD", new[] {0, -1, 1, 2}, new[] {0, -1, 1, 2}));
        }

        [Fact]
        public void Max_Test()
        {
            var x = int.MinValue * (long) int.MinValue;
            Assert.True(x > 0);
            var y = x * 2;
            Assert.False(y > 0);
            Assert.Equal(3, Solution("ABC", new[] { 0, int.MinValue, int.MaxValue }, new[] { 0, int.MinValue, int.MaxValue }));
        }

        public int Solution(string S, int[] X, int[] Y)
        {
            int cnt = 0;
            var encountered = new HashSet<char>();
            var points = new List<Tuple<int, int, long, char>>();
            for (int i = 0; i < X.Length; i++)
            {
                points.Add(Tuple.Create(X[i], Y[i], X[i] * (long) X[i] + Y[i] * (long) Y[i], S[i]));
            }

            var overFlow = points.Where(p => p.Item3 < 0);
            points = points.Where(p => p.Item3 >= 0).OrderBy(p => p.Item3).ToList();
            points.AddRange(overFlow);
            for (int i = 0; i < points.Count; i++)
            {
                var point = points[i];
                if (encountered.Contains(point.Item4))
                    break;
                else
                {
                    var tmpCnt = 0;
                    while (i < points.Count && points[i].Item3 == point.Item3)
                    {
                        if (encountered.Contains(points[i].Item4))
                            return cnt;
                        else
                        {
                            encountered.Add(point.Item4);
                            i++;
                            tmpCnt++;
                        }
                    }
                    i--;
                    encountered.Add(point.Item4);
                    cnt += tmpCnt;
                }
            }
            return cnt;
        }
    }
}