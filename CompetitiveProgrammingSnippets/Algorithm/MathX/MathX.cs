using System;
using Algorithm.BasicDataStructure;

namespace Algorithm.MathX
{
    using __int__ = Int32;
    using __long__ = Int64;

    //$mathx
    public static partial class MathX
    {
        /*$END$*/
    }
    //$mathx

    public static partial class MathX
    {
        //$swap
        public static void Swap<T>(ref T left, ref T right)
        {
            var tmp = left;
            left = right;
            right = tmp;
        }
        //$swap
        //$lcm
        //@LeastCommonMultiple (a > 0 && b > 0)
        //$gcd
        //@GreatestCommonDivisor (a > 0 && b > 0)
        public static __int__ Gcd(__int__ a, __int__ b)
        {
            return b == 0 ? a : Gcd(b, a % b);
        }
        //$gcd
        public static __int__ Lcm(__int__ a, __int__ b)
        {
            return a * (b / Gcd(a, b));
        }
        //$lcm
        //$gcdex
        //@拡張ユークリッドの互除法 (a > 0 && b > 0)
        public static __int__ GcdEx(__int__ a, __int__ b, out __int__ x, out __int__ y)
        {
            if (b == 0)
            {
                x = 1;
                y = 0;
                return a;
            }

            __int__ tx, ty;
            var gcd = GcdEx(b, a % b, out tx, out ty);

            x = ty;
            y = tx - ty * (a / b);
            return gcd;
        }
        //$gcdex
        //$gcdexf
        //@拡張ユークリッドの互除法タプル利用 (a > 0 && b > 0)
        public static (__int__ gcd, __int__ x, __int__ y) GcdEx(__int__ a, __int__ b)
        {
            if (b == 0) return (a, 1, 0);
            var (gcd, x, y) = GcdEx(b, a % b);
            return (gcd, y, x - y * (a / b));
        }
        //$gcdexf
        //$pbs
        public static long ParseBigString(string str, long mod)
        {
            var ret = 0L;
            foreach (var c in str) ret = (ret * 10 + (c - '0')) % mod;
            return ret;
        }
        //$pbs
    }
}
