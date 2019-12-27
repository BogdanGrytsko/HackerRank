using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XTest
{
    public class AVLTreeTest
    {
        [Fact]
        public void AVLTree_Add_Remove()
        {
            var tree = new AVLTree() { 1, 1, 2, 3, 4 };
            Assert.Equal(new List<int> { 1, 1, 2, 3, 4 }, tree.ToList());
            tree.Delete(1);
            tree.Delete(3);
            Assert.Equal(new List<int> { 1, 2, 4 }, tree.ToList());
            Assert.False(tree.Exists(100));
        }

        [Fact]
        public void Median_Updates_Test()
        {
            var tree = new AVLTree() { 1, 1, 3, 5, 5 };
            var median = tree.GetMedian();
            Assert.Equal(3, median);
        }

        [Fact]
        public void Median_Updates_Test1()
        {
            var tree = new AVLTree() { -2147483648, -2147483648 };
            var median = tree.GetMedian();
            Assert.Equal(-2147483648, median);
        }


        [Fact]
        public void Median_Updates_Test1_Part2()
        {
            var tree = new AVLTree() { -2147483647, 2147483647, 10, 10 };
            var median = tree.GetMedian();
            Assert.Equal(10, median);
        }
    }
}
