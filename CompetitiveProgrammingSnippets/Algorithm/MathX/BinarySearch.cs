using System;
using System.Collections.Generic;

namespace Algorithm.MathX
{
    //$bs
    //@二分探索 単調増加であることが条件 left <= ret < right
    public static partial class BinarySearch
    {
        public static BinarySearch<T> Default<T>(Func<long, T> func, long left, long right) where T : IComparable<T>
        {
            return new BinarySearch<T>().SetFunc(func).SetInterval(left, right);
        }

        public static BinarySearch<T> ToBinarySearch<T>(this IList<T> source) where T : IComparable<T>
        {
            return new BinarySearch<T>().SetFunc(x => source[(int)x]).SetInterval(0, source.Count);
        }
    }

    public class BinarySearch<T> where T : IComparable<T>
    {
        Func<long, T> Func { get; set; } = null;
        long Left { get; set; } = 0;
        long Right { get; set; } = 0;
        bool IsOrderAscending { get; set; } = true;

        public BinarySearch<T> SetFunc(Func<long, T> func)
        {
            Func = func;
            return this;
        }

        public BinarySearch<T> SetInterval(long left, long right)
        {
            if (left > right) throw new ArgumentException($"{nameof(left)} <= {nameof(right)}");
            Left = left;
            Right = right;
            return this;
        }

        public BinarySearch<T> SetOrder(bool isOrderAscending)
        {
            IsOrderAscending = isOrderAscending;
            return this;
        }

        long BoundToTheRight(Func<long, bool> pred, long left, long right)
        {
            while (true)
            {
                if (left == right) return right;
                var mid = (left + right - 1) >> 1;
                if (pred(mid)) right = mid;
                else left = mid + 1;
            }
        }

        public long LowerBound(T value)
        {
            var sign = IsOrderAscending ? 1 : -1;
            return BoundToTheRight(x => sign * Func(x).CompareTo(value) >= 0, Left, Right);
        }

        public long UpperBound(T value)
        {
            var sign = IsOrderAscending ? 1 : -1;
            return BoundToTheRight(x => sign * Func(x).CompareTo(value) > 0, Left, Right);
        }

        public long Range(T vLeft, T vRight)
        {
            return Math.Max(0, UpperBound(vRight) - LowerBound(vLeft));
        }

        public long Count(T value)
        {
            return Range(value, value);
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
                var mid = (left + right + 1) >> 1;
                if (pred(mid)) left = mid;
                else right = mid - 1;
            }
        }

        static long MeguruSearch(Func<long, bool> pred, long inValue, long outValue)
        {
            while (true)
            {
                if (Math.Abs(inValue - outValue) <= 1) return inValue;
                var mid = (inValue + outValue) >> 1;
                if (pred(mid)) inValue = mid;
                else outValue = mid;
            }
        }
    }
}