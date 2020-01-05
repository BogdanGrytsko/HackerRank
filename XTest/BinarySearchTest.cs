using HackerRank.Algorithm;
using Xunit;

namespace XTest
{
    public class BinarySearchTest
    {
        [Fact]
        public void Num_Of_Elements_Smaller_Eq_Than()
        {
            var arr = new int[] { 1, 2, 3, 3, 5, 7, 7 };
            Assert.Equal(0, BinarySearch.FindSmallerEqualCnt(arr, 0));
            Assert.Equal(1, BinarySearch.FindSmallerEqualCnt(arr, 1));
            Assert.Equal(4, BinarySearch.FindSmallerEqualCnt(arr, 3));
            Assert.Equal(4, BinarySearch.FindSmallerEqualCnt(arr, 4));
            Assert.Equal(5, BinarySearch.FindSmallerEqualCnt(arr, 6));
            Assert.Equal(7, BinarySearch.FindSmallerEqualCnt(arr, 7));
            Assert.Equal(7, BinarySearch.FindSmallerEqualCnt(arr, 9));
        }

        [Fact]
        public void Num_Of_Elements_Bigger_Eq_Than()
        {
            var arr = new int[] { 1, 2, 3, 3, 5, 7, 7 };
            Assert.Equal(7, BinarySearch.FindBiggerEqualCnt(arr, 0));
            Assert.Equal(7, BinarySearch.FindBiggerEqualCnt(arr, 1));
            Assert.Equal(5, BinarySearch.FindBiggerEqualCnt(arr, 3));
            Assert.Equal(3, BinarySearch.FindBiggerEqualCnt(arr, 4));
            Assert.Equal(2, BinarySearch.FindBiggerEqualCnt(arr, 6));
            Assert.Equal(2, BinarySearch.FindBiggerEqualCnt(arr, 7));
            Assert.Equal(0, BinarySearch.FindBiggerEqualCnt(arr, 9));
        }
    }
}
