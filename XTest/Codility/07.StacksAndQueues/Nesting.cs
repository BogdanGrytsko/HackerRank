using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XTest.Codility._07.StacksAndQueues
{
    public class Nesting
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(1, Solution("(()(())())"));
        }

        [Fact]
        public void Test_2()
        {
            Assert.Equal(0, Solution("())"));
        }

        [Fact]
        public void Test_3()
        {
            Assert.Equal(0, Solution("()(()()(((()())(()()))"));
        }

        public int Solution(String S)
        {
            var stack = new Stack<char>();
            foreach (var c in S)
            {
                if (c == '(')
                    stack.Push(c);
                else if (c == ')')
                {
                    if (!stack.Any())
                        return 0;
                    stack.Pop();
                }
            }

            return stack.Any() ? 0 : 1;
        }
    }
}