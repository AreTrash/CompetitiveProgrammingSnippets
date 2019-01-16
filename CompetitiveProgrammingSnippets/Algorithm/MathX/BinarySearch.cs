using System;
using System.Linq;

namespace Algorithm.MathX
{
    using __int__ = Int32;
    using __long__ = Int64;

    //$bs
    //@二分探索
    public static partial class BinarySearch
    {
        static __int__ Left(Func<__int__, bool> pred, __int__ left, __int__ right)
        {
            if (left > right) throw new ArgumentException("left must <= right");

            while (true)
            {
                if (left == right) break;
                var mid = (left + right + 1) / 2;
                if (pred(mid)) left = mid;
                else right = mid - 1;
            }

            return right;
        }

        static __int__ Right(Func<__int__, bool> pred, __int__ left, __int__ right)
        {
            if (left > right) throw new ArgumentException("left must <= right");

            while (true)
            {
                if (left == right) return left;
                var mid = (left + right - 1) / 2;
                if (pred(mid)) right = mid;
                else left = mid + 1;
            }
        }

        enum SearchType
        {
            OutLeft, InLeft, InRight, OutRight
        }

        static __int__ Search(SearchType st, Func<__int__, __long__> func, __long__ value, __int__ min, __int__ max)
        {
            var isInc = func(min) <= func(max);

            //TODO InLeft, InRight
            if (st == SearchType.OutLeft && isInc) return Left(x => func(x) < value, min, max);
            if (st == SearchType.InLeft && isInc) return Math.Min(Left(x => func(x) <= value, min, max), Right(x => func(x) >= value, min, max));
            if (st == SearchType.InRight && isInc) return Math.Max(Left(x => func(x) <= value, min, max), Right(x => func(x) >= value, min, max));
            if (st == SearchType.OutRight && isInc) return Right(x => func(x) > value, min, max);
            if (st == SearchType.OutLeft && !isInc) return Left(x => func(x) > value, min, max);
            if (st == SearchType.InLeft && !isInc) return Math.Min(Left(x => func(x) >= value, min, max), Right(x => func(x) <= value, min, max));
            if (st == SearchType.InRight && !isInc) return Math.Max(Left(x => func(x) >= value, min, max), Right(x => func(x) <= value, min, max));
            if (st == SearchType.OutRight && !isInc) return Right(x => func(x) < value, min, max);

            throw new Exception();
        }

        static int ArraySearch(SearchType st, __long__[] array, __long__ value)
        {
            if (array.Length == 0) throw new ArgumentException($"{nameof(array)}.Length > 0");

            var first = array.First();
            var last = array.Last();
            var isInc = first <= last;

            var isOutOfRangeToTheLeft = false;
            if (isInc && st == SearchType.OutLeft) isOutOfRangeToTheLeft = first >= value;
            if (isInc && st != SearchType.OutLeft) isOutOfRangeToTheLeft = first > value;
            if (!isInc && st == SearchType.OutLeft) isOutOfRangeToTheLeft = first <= value;
            if (!isInc && st != SearchType.OutLeft) isOutOfRangeToTheLeft = first < value;
            if (isOutOfRangeToTheLeft) return -1;

            var isOutOfRangeToTheRight = false;
            if (isInc && st == SearchType.OutRight) isOutOfRangeToTheRight = last <= value;
            if (isInc && st != SearchType.OutRight) isOutOfRangeToTheRight = last < value;
            if (!isInc && st == SearchType.OutRight) isOutOfRangeToTheRight = last >= value;
            if (!isInc && st != SearchType.OutRight) isOutOfRangeToTheRight = last > value;
            if (isOutOfRangeToTheRight) return array.Length;

            return (int)Search(st, x => array[x], value, 0, array.Length - 1);
        }

        public static __int__ OutLeft(Func<__int__, __long__> func, __long__ value, __int__ min, __int__ max)
        {
            return Search(SearchType.OutLeft, func, value, min, max);
        }

        public static __int__ InLeft(Func<__int__, __long__> func, __long__ value, __int__ min, __int__ max)
        {
            return Search(SearchType.InLeft, func, value, min, max);
        }

        public static __int__ InRight(Func<__int__, __long__> func, __long__ value, __int__ min, __int__ max)
        {
            return Search(SearchType.InRight, func, value, min, max);
        }

        public static __int__ OutRight(Func<__int__, __long__> func, __long__ value, __int__ min, __int__ max)
        {
            return Search(SearchType.OutRight, func, value, min, max);
        }

        public static __int__ Range(Func<__int__, __long__> func, __long__ leftValue, __long__ rightValue, __int__ min, __int__ max)
        {
            var minIndex = InLeft(func, leftValue, min, max);
            var maxIndex = InRight(func, rightValue, min, max);
            if (func(min) < func(max) && func(minIndex) < leftValue) minIndex++;
            if (func(max) < func(min) && func(minIndex) > leftValue) minIndex++;
            if (func(min) < func(max) && func(maxIndex) > rightValue) maxIndex--;
            if (func(max) < func(min) && func(maxIndex) < rightValue) maxIndex--;
            return Math.Max(0, maxIndex - minIndex + 1);
        }

        public static int OutLeft(this __long__[] source, __long__ value)
        {
            return ArraySearch(SearchType.OutLeft, source, value);
        }

        public static int InLeft(this __long__[] source, __long__ value)
        {
            return ArraySearch(SearchType.InLeft, source, value);
        }

        public static int InRight(this __long__[] source, __long__ value)
        {
            return ArraySearch(SearchType.InRight, source, value);
        }

        public static int OutRight(this __long__[] source, __long__ value)
        {
            return ArraySearch(SearchType.OutRight, source, value);
        }

        public static int Range(this __long__[] source, __long__ leftValue, __long__ rightValue)
        {
            var minIndex = source.InLeft(leftValue);
            var maxIndex = source.InRight(rightValue);
            if (minIndex == -1 || (minIndex != source.Length && source[minIndex] != leftValue)) minIndex++;
            if (maxIndex == source.Length || (maxIndex != -1 && source[maxIndex] != rightValue)) maxIndex--;
            return Math.Max(0, maxIndex - minIndex + 1);
        }
    }
    //$bs

    public static partial class BinarySearch
    {
        public static __int__ MeguruSearch(Func<int, bool> pred, __int__ inValue, __int__ outValue)
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
