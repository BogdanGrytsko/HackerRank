using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XTest.Codility._07.StacksAndQueues
{
    public class Brackets
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(1, Solution("{[()()]}"));
        }

        [Fact]
        public void Test_2()
        {
            Assert.Equal(0, Solution("([)()]"));
        }

        public int Solution(String S)
        {
            var stack = new Stack<char>();
            foreach (var c in S)
            {
                if (c == '(' || c == '[' || c == '{')
                    stack.Push(c);
                else
                {
                    if (!stack.Any())
                        return 0;
                    var x = stack.Pop();
                    if (x == '(' && c != ')')
                        return 0;
                    if (x == '[' && c != ']')
                        return 0;
                    if (x == '{' && c != '}')
                        return 0;
                }
            }

            return stack.Any() ? 0 : 1;
        }
    }
}