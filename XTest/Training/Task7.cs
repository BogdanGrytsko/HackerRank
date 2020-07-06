using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XTest.Training
{
    public class Task7
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(2, Dominos("4-3,5-1,2-2,1-3,4-4"));
        }

        [Fact]
        public void Single()
        {
            Assert.Equal(1, Dominos("4-3"));
        }

        [Fact]
        public void Test2()
        {
            //2-3 --> 3-5 --> 5-2 --> 2-4
            Assert.Equal(4, Dominos("1-1,3-5,5-2,2-3,2-4"));
        }

        [Fact]
        public void Loop()
        {
            Assert.Equal(3, Dominos("1-2,2-3,3-1"));
        }

        //domino("1-1") // 1
        //domino("1-2,1-2") // 1
        //domino("3-2,2-1,1-4,4-4,5-4,4-2,2-1") // 4
        //domino("5-5,5-5,4-4,5-5,5-5,5-5,5-5,5-5,5-5,5-5") // 7
        //domino("1-1,3-5,5-5,5-4,4-2,1-3") // 4
        //domino("1-2,2-2,3-3,3-4,4-5,1-1,1-2") // 3

        [Fact]
        public void Test3()
        {
            Assert.Equal(1, Dominos("1-1"));
            Assert.Equal(1, Dominos("1-2,1-2"));
        }

        [Fact]
        public void Test99()
        {
            Assert.Equal(4, Dominos("3-2,2-1,1-4,4-4,5-4,4-2,2-1"));
        }

        [Fact]
        public void Test5()
        {
            Assert.Equal(7, Dominos("5-5,5-5,4-4,5-5,5-5,5-5,5-5,5-5,5-5,5-5"));
        }

        [Fact]
        public void Test6()
        {
            Assert.Equal(4, Dominos("1-1,3-5,5-5,5-4,4-2,1-3"));
        }

        [Fact]
        public void Test7()
        {
            Assert.Equal(3, Dominos("1-2,2-2,3-3,3-4,4-5,1-1,1-2"));
        }

        private class Domino
        {
            public int Left { get; set; }
            public int Right { get; set; }
            public Domino Next { get; set; }
            public int Len => 1 + (Next?.Len ?? 0);

            public override string ToString()
            {
                return $"{Left}, {Right}";
            }
        }

        public int Dominos(string dominos)
        {
            var list = new List<Domino>();
            foreach (var dom in dominos.Split(","))
            {
                list.Add(new Domino {Left = int.Parse(dom[0].ToString()), Right = int.Parse(dom[2].ToString())});
            }

            foreach (var domino1 in list)
            {
                foreach (var domino2 in list)
                {
                    if (domino1 != domino2 && domino1.Right == domino2.Left)
                        domino1.Next = domino2;
                }
            }

            var maxLen = list.Max(CalcLen);
            return maxLen;
        }

        private int CalcLen(Domino dom)
        {
            return CalcLenInternal(dom, new HashSet<Domino>());
        }

        private int CalcLenInternal(Domino dom, HashSet<Domino> visited)
        {
            if (dom == null || visited.Contains(dom))
                return 0;
            visited.Add(dom);
            return 1 + CalcLenInternal(dom.Next, visited);
        }
    }
}