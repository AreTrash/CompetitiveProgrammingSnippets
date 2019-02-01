namespace Algorithm.MathX
{
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
        public static long Gcd(long a, long b)
        {
            return b == 0 ? a : Gcd(b, a % b);
        }
        //$gcd
        public static long Lcm(long a, long b)
        {
            return a * (b / Gcd(a, b));
        }
        //$lcm
        //$gcdex
        //@拡張ユークリッドの互除法 (a > 0 && b > 0)
        public static long GcdEx(long a, long b, out long x, out long y)
        {
            if (b == 0)
            {
                x = 1;
                y = 0;
                return a;
            }

            long tx, ty;
            var gcd = GcdEx(b, a % b, out tx, out ty);

            x = ty;
            y = tx - ty * (a / b);
            return gcd;
        }
        //$gcdex
        //$gcdexf
        //@拡張ユークリッドの互除法タプル利用 (a > 0 && b > 0)
        public static (long gcd, long x, long y) GcdEx(long a, long b)
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
