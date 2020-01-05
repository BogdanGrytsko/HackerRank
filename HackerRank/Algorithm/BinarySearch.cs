namespace HackerRank.Algorithm
{
    public class BinarySearch
    {
        public static int FindSmallerEqualCnt(int[] arr, int elem)
        {
            return FindSmallerEqualCnt(arr, elem, 0, arr.Length - 1);
        }

        private static int FindSmallerEqualCnt(int[] arr, int elem, int l, int r)
        {
            var mid = (l + r) / 2;
            if (arr[mid] <= elem)
            {
                if (mid == arr.Length - 1 || arr[mid + 1] > elem)
                    return mid + 1;
                return FindSmallerEqualCnt(arr, elem, mid + 1, r);
            }
            else
            {
                if (mid == 0)
                    return 0;
                return FindSmallerEqualCnt(arr, elem, l, mid);
            }
        }

        public static int FindBiggerEqualCnt(int[] arr, int elem)
        {
            return FindBiggerEqualCnt(arr, elem, 0, arr.Length - 1);
        }

        private static int FindBiggerEqualCnt(int[] arr, int elem, int l, int r)
        {
            var mid = (l + r) / 2;
            if (arr[mid] < elem)
            {
                if (mid == arr.Length - 1)
                    return 0;
                return FindBiggerEqualCnt(arr, elem, mid + 1, r);
            }
            else
            {
                if (mid == 0 || arr[mid - 1] < elem)
                    return arr.Length - mid;
                return FindBiggerEqualCnt(arr, elem, l, mid);
            }
        }
    }
}
