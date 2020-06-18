using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XTest
{
    public class AvlTreeTest
    {
        [Fact]
        public void AVLTree_Add_Remove()
        {
            var tree = new AVLTree() { 1, 1, 2, 3, 4 };
            Assert.Equal(new List<int> { 1, 2, 3, 4 }, tree.ToList());
            tree.Delete(1);
            tree.Delete(3);
            Assert.Equal(new List<int> { 1, 2, 4 }, tree.ToList());
            Assert.False(tree.Exists(100));
        }

        [Fact]
        public void Median_Updates_Test()
        {
            var tree = new AVLTree() { 1, 2, 3, 3, 3 };
            Assert.Equal(3, tree.GetMedian());
            tree.Add(4);
            tree.Add(4);
            tree.Add(4);
            tree.Add(4);
            tree.Add(4);
            Assert.Equal(3.5, tree.GetMedian());
        }

        [Fact]
        public void Median_Updates_Test1()
        {
            var tree = new AVLTree() { -2147483648, -2147483648 };
            Assert.Equal(-2147483648, tree.GetMedian());
            tree.Add(-2147483647);
            Assert.Equal(-2147483648, tree.GetMedian());
        }


        [Fact]
        public void Median_Updates_Test1_Part2()
        {
            var tree = new AVLTree() { -2147483647, 2147483647, 10, 10 };
            Assert.Equal(10, tree.GetMedian());
        }

        [Fact]
        public void Median_Updates_Test1_Part3()
        {
            var tree = new AVLTree() { -2147483647, 0, 10, 2147483640, 2147483646, 2147483647 };
            Assert.Equal(1073741825, tree.GetMedian());
        }
    }
}
