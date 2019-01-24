using System;

namespace Algorithm.MathX
{
    //$permutation
    //https://stackoverflow.com/questions/11208446/generating-permutations-of-a-set-most-efficiently
    //by Sani Singh Huttunen
    public static class Permutation
    {
        public static bool NextPermutation<T>(this T[] items) where T : IComparable<T>
        {
            return PermutationCore(items, 1);
        }

        public static bool PrevPermutation<T>(this T[] items) where T : IComparable<T>
        {
            return PermutationCore(items, -1);
        }

        static bool PermutationCore<T>(T[] items, int sign) where T : IComparable<T>
        {
            int x, y;

            for (x = items.Length - 2; x >= 0; x--)
            {
                if (sign * items[x].CompareTo(items[x + 1]) < 0) break;
            }

            if (x < 0)
            {
                Array.Reverse(items);
                return false;
            }

            for (y = items.Length - 1; y >= 0; y--)
            {
                if (sign * items[x].CompareTo(items[y]) < 0) break;
            }

            SwapIndex(items, x, y);

            for (int i = x + 1, j = items.Length - 1; i < j; i++, j--)
            {
                SwapIndex(items, i, j);
            }

            return true;
        }

        static void SwapIndex<T>(T[] items, int left, int right) where T : IComparable<T>
        {
            var tmp = items[left];
            items[left] = items[right];
            items[right] = tmp;
        }
    }
    //$permutation
}