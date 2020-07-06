using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XTest.Training
{
    public class Task6
    {

        [Fact]
        public void Test()
        {
            Assert.Equal("PERU", FindWord(new List<string>{ "P>E", "E>R", "R>U" }));
        }

        [Fact]
        public void Test2()
        {
            Assert.Equal("SPAIN", FindWord(new List<string> { "I>N", "A>I", "P>A", "S>P" }));
        }

        //findWord(["U>N", "G>A", "R>Y", "H>U", "N>G", "A>R"]) // HUNGARY
        //findWord(["I>F", "W>I", "S>W", "F>T"]) // SWIFT
        //findWord(["R>T", "A>L", "P>O", "O>R", "G>A", "T>U", "U>G"]) // PORTUGAL
        //findWord(["W>I", "R>L", "T>Z", "Z>E", "S>W", "E>R", "L>A", "A>N", "N>D", "I>T"]) // SWITZERLAND

        [Fact]
        public void Test3()
        {
            Assert.Equal("HUNGARY", FindWord(new List<string> { "U>N", "G>A", "R>Y", "H>U", "N>G", "A>R" }));
        }


        [Fact]
        public void Test4()
        {
            Assert.Equal("SWIFT", FindWord(new List<string> { "I>F", "W>I", "S>W", "F>T" }));
        }

        [Fact]
        public void Test5()
        {
            Assert.Equal("PORTUGAL", FindWord(new List<string> { "R>T", "A>L", "P>O", "O>R", "G>A", "T>U", "U>G" }));
        }

        [Fact]
        public void Test6()
        {
            Assert.Equal("SWITZERLAND", FindWord(new List<string> { "W>I", "R>L", "T>Z", "Z>E", "S>W", "E>R", "L>A", "A>N", "N>D", "I>T" }));
        }

        private class Node
        {
            public char Start { get; set; }
            public char End { get; set; }
            public Node Next { get; set; }

            public int Len => 1 + Next?.Len ?? 0;

            public override string ToString()
            {
                return $"{Start}, {Next}";
            }
        }

        public string FindWord(List<string> rules)
        {
            var nodes = new List<Node>();
            foreach (var rule in rules)
            {
                nodes.Add(new Node {Start = rule[0], End = rule[2]});
            }

            foreach (var node1 in nodes)
            {
                foreach (var node2 in nodes)
                {
                    if (node1.End == node2.Start)
                        node1.Next = node2;
                }
            }

            var maxLen = nodes.Max(n => n.Len);
            var maxNode = nodes.Single(n => n.Len == maxLen);
            var word = "";
            while (maxNode.Next != null)
            {
                word += maxNode.Start;
                maxNode = maxNode.Next;
            }

            word += maxNode.Start;
            word += maxNode.End;
            return word;
        }
    }
}