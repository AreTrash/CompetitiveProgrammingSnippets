using System;
using Algorithm.BasicDataStructure;

namespace Algorithm.MathX
{
    using __int__ = Int32;
    
    //$mathX
    public static class MathX
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
        //$gcd
        public static __int__ Gcd(__int__ x, __int__ y)
        {
            return y == 0 ? x : Gcd(y, x % y);
        }
        //$gcd
        public static __int__ Lcm(__int__ x, __int__ y)
        {
            return x * (y / Gcd(x, y));
        }
        //$lcm
    }
    //$mathX
}
