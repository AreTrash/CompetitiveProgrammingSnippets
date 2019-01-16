using System;

namespace Algorithm.MathX
{
    //$bs
    //@二分探索 単調増加であることが条件 left <= ret < right
    public static partial class BinarySearch
    {
        static long BoundToTheRight(Func<long, bool> pred, long left, long right)
        {
            if (left > right) throw new ArgumentException("left must <= right");

            while (true)
            {
                if (left == right) return right;
                var mid = (left + right - 1) / 2;
                if (pred(mid)) right = mid;
                else left = mid + 1;
            }
        }

        public static long LowerBound<T>(Func<long, T> func, T value, long left, long right) where T : IComparable<T>
        {
            return BoundToTheRight(x => func(x).CompareTo(value) >= 0, left, right);
        }

        public static long UpperBound<T>(Func<long, T> func, T value, long left, long right) where T : IComparable<T>
        {
            return BoundToTheRight(x => func(x).CompareTo(value) > 0, left, right);
        }

        public static int LowerBound<T>(this T[] source, T value) where T : IComparable<T>
        {
            return (int)LowerBound(x => source[x], value, 0, source.Length);
        }

        public static int UpperBound<T>(this T[] source, T value) where T : IComparable<T>
        {
            return (int)UpperBound(x => source[x], value, 0, source.Length);
        }

        public static int Range<T>(this T[] source, T vLeft, T vRight) where T : IComparable<T>
        {
            return source.UpperBound(vRight) - source.LowerBound(vLeft);
        }
    }
    //$bs

    public static partial class BinarySearch
    {
        static long BoundToTheLeft(Func<long, bool> pred, long left, long right)
        {
            if (left > right) throw new ArgumentException("left must <= right");

            while (true)
            {
                if (left == right) return left;
                var mid = (left + right + 1) / 2;
                if (pred(mid)) left = mid;
                else right = mid - 1;
            }
        }

        static long MeguruSearch(Func<long, bool> pred, long inValue, long outValue)
        {
            while (true)
            {
                if (Math.Abs(inValue - outValue) <= 1) return inValue;
                var mid = (inValue + outValue) / 2;
                if (pred(mid)) inValue = mid;
                else outValue = mid;
            }
        }
    }
}