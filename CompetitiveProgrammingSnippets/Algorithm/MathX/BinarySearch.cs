using System;

namespace Algorithm.MathX
{
    using __long__ = Int32;

    //$bs
    //@二分探索 単調増加であることが条件 left <= ret < right
    public static partial class BinarySearch
    {
        public static bool IsOrderAscending = true;

        static long BoundToTheRight(Func<long, bool> pred, long left, long right)
        {
            if (left > right) throw new ArgumentException("left must <= right");

            while (true)
            {
                if (left == right) return right;
                var mid = (left + right - 1) >> 1;
                if (pred(mid)) right = mid;
                else left = mid + 1;
            }
        }

        public static long LowerBound<T>(Func<long, T> func, T value, long left, long right) where T : IComparable<T>
        {
            return BoundToTheRight(x => IsOrderAscending ^ (func(x).CompareTo(value) >= 0), left, right);
        }

        public static long UpperBound<T>(Func<long, T> func, T value, long left, long right) where T : IComparable<T>
        {
            return BoundToTheRight(x => IsOrderAscending ^ (func(x).CompareTo(value) > 0), left, right);
        }

        public static long Range<T>(Func<long, T> func, T vLeft, T vRight, long inLeft, long inRight) where T : IComparable<T>
        {
            return Math.Max(0, UpperBound(func, vRight, inLeft, inRight) - LowerBound(func, vLeft, inLeft, inRight));
        }

        public static long Count<T>(Func<long, T> func, T value, long inLeft, long inRight) where T : IComparable<T>
        {
            return Range(func, value, value, inLeft, inRight);
        }

        public static int LowerBound<T>(this T[] source, Func<T, T> func, T value) where T : IComparable<T>
        {
            return (int)LowerBound(x => func(source[x]), value, 0, source.Length);
        }

        public static int UpperBound<T>(this T[] source, Func<T, T> func, T value) where T : IComparable<T>
        {
            return (int)UpperBound(x => func(source[x]), value, 0, source.Length);
        }

        public static int Range<T>(this T[] source, Func<T, T> func, T vLeft, T vRight) where T : IComparable<T>
        {
            return Math.Max(0, source.UpperBound(func, vRight) - source.LowerBound(func, vLeft));
        }

        public static int Count<T>(this T[] source, Func<T, T> func, T value) where T : IComparable<T>
        {
            return source.Range(func, value, value);
        }

        public static int LowerBound<T>(this T[] source, T value) where T : IComparable<T>
        {
            return source.LowerBound(t => t, value);
        }

        public static int UpperBound<T>(this T[] source, T value) where T : IComparable<T>
        {
            return source.UpperBound(t => t, value);
        }

        public static int Range<T>(this T[] source, T vLeft, T vRight) where T : IComparable<T>
        {
            return source.Range(t => t, vLeft, vRight);
        }

        public static int Count<T>(this T[] source, T value) where T : IComparable<T>
        {
            return source.Range(value, value);
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

    public static class BinarySearchFactory
    {
        public static BinarySearch<T> Default<T>(Func<long, T> func, long left, long right) where T : IComparable<T>
        {
            return new BinarySearch<T>().SetFunc(func).SetInterval(left, right);
        }

        public static BinarySearch<T> Array<T>(T[] array) where T : IComparable<T>
        {
            return new ArrayBinarySearch<T>(array);
        }

        public static BinarySearch<T> BinarySearch<T>(this T[] source) where T : IComparable<T>
        {
            return Array(source);
        }
    }

    public class BinarySearch<T> where T : IComparable<T>
    {
        protected Func<long, T> Func { get; set; }
        protected long Left { get; set; }
        protected long Right { get; set; }
        protected bool IsAscending { get; set; } = true;

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
            return BoundToTheRight(x => IsAscending ^ (Func(x).CompareTo(value) >= 0), Left, Right);
        }

        public long UpperBound(T value)
        {
            return BoundToTheRight(x => IsAscending ^ (Func(x).CompareTo(value) > 0), Left, Right);
        }

        public long Range(T vLeft, T vRight)
        {
            return Math.Max(0, UpperBound(vRight) - LowerBound(vLeft));
        }

        public long Count(T value)
        {
            return Range(value, value);
        }

        public virtual BinarySearch<T> SetFunc(Func<long, T> func)
        {
            Func = func;
            return this;
        }

        public virtual BinarySearch<T> SetArrayFunc(Func<T[], long, T> func)
        {
            throw new NotSupportedException();
        }

        public virtual BinarySearch<T> SetInterval(long left, long right)
        {
            if (left > right) throw new ArgumentException($"{nameof(left)} <= {nameof(right)}");
            Left = left;
            Right = right;
            return this;
        }

        public virtual BinarySearch<T> SetOrder(bool isAscending)
        {
            IsAscending = isAscending;
            return this;
        }
    }

    public class ArrayBinarySearch<T> : BinarySearch<T> where T : IComparable<T>
    {
        readonly T[] array;

        public ArrayBinarySearch(T[] array)
        {
            this.array = array;
            Func = x => array[x];
            Left = 0;
            Right = array.Length;
        }

        public override BinarySearch<T> SetFunc(Func<long, T> func)
        {
            throw new NotSupportedException();
        }

        public override BinarySearch<T> SetArrayFunc(Func<T[], long, T> func)
        {
            return base.SetFunc(x => func(array, x));
        }

        public override BinarySearch<T> SetInterval(long left, long right)
        {
            if (left < 0 || array.Length < left) throw new ArgumentOutOfRangeException(nameof(left));
            if (right < 0 || array.Length < right) throw new ArgumentOutOfRangeException(nameof(right));
            return base.SetInterval(left, right);
        }
    }
}