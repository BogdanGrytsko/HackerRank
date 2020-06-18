using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XTest.Codility._06.Sorting
{
    public class IntersectingDiscs
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(11, Solution(new[] { 1, 5, 2, 1, 4, 0 }));
        }

        [Fact]
        public void Intersect_Exactly_Test()
        {
            Assert.Equal(3, Solution(new[] { 1, 0, 1 }));
        }

        [Fact]
        public void Intersect_Test2()
        {
            Assert.Equal(3, Solution(new[] { 1, 5, 2 }));
        }

        public int Solution(int[] A)
        {
            var events = new List<Tuple<long, bool>>();
            for (int i = 0; i < A.Length; i++)
            {
                events.Add(Tuple.Create(i + (long)A[i], false));
                events.Add(Tuple.Create(i - (long)A[i], true));
            }
            events = events.OrderBy(e => e.Item1)
                .ThenByDescending(e => e.Item2).ToList();

            var activeCircles = 0;
            var intersections = 0;
            foreach (var evt in events)
            {
                if (evt.Item2)
                {
                    activeCircles++;
                    intersections += (activeCircles - 1);
                    if (intersections > 10000000)
                        return -1;
                }
                else if (activeCircles > 0)
                {
                    activeCircles--;
                }
            }

            return intersections;
        }
    }
}
