using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm.MathX
{
    //$permutation
    //ref: https://stackoverflow.com/questions/11208446/generating-permutations-of-a-set-most-efficiently
    //by Sani Singh Huttunen
    public static class Permutation
    {
        public static IEnumerable<IReadOnlyList<T>> NextPermutations<T>(this IEnumerable<T> source) where T : IComparable<T>
        {
            return EnumeratePermutations(source, 1);
        }

        public static IEnumerable<IReadOnlyList<T>> PrevPermutations<T>(this IEnumerable<T> source) where T : IComparable<T>
        {
            return EnumeratePermutations(source, -1);
        }

        static IEnumerable<IReadOnlyList<T>> EnumeratePermutations<T>(IEnumerable<T> source, int sign) where T : IComparable<T>
        {
            var copy = source.ToList();
            var copyAsReadOnly = copy.AsReadOnly();
            do yield return copyAsReadOnly;
            while (PermutationCore(copy, sign));
        }

        static bool PermutationCore<T>(IList<T> items, int sign) where T : IComparable<T>
        {
            int x, y;
            
            for (x = items.Count - 2; x >= 0; x--)
            {
                if (sign * items[x].CompareTo(items[x + 1]) < 0) break;
            }

            if (x < 0)
            {
                ReverseSegment(items, 0);
                return false;
            }

            for (y = items.Count - 1; y >= 0; y--)
            {
                if (sign * items[x].CompareTo(items[y]) < 0) break;
            }

            SwapPosition(items, x, y);
            ReverseSegment(items, x + 1);
            return true;
        }

        static void ReverseSegment<T>(IList<T> items, int offset) where T : IComparable<T>
        {
            for (int i = offset, j = items.Count - 1; i < j; i++, j--) SwapPosition(items, i, j);
        }

        static void SwapPosition<T>(IList<T> items, int left, int right) where T : IComparable<T>
        {
            var tmp = items[left];
            items[left] = items[right];
            items[right] = tmp;
        }
    }
    //$permutation
}