using System;

namespace Algorithm.MathX
{
    //参考: 繰り返し二乗法 http://satanic0258.hatenablog.com/entry/2016/04/29/004730 ‎@satanic0258さん

    //$modint
    //@ModInt Modは素数推奨 dependency: mathx, gcdex
    public struct ModInt
    {
        public static int Mod = 1000000007;

        readonly long value;
        public int Value { get { return (int)value; } }
        public ModInt Inverse { get { return GetInverse(); } }

        public ModInt(long value)
        {
            value %= Mod;
            this.value = value < 0 ? value + Mod : value;
        }

        ModInt GetInverse()
        {
            long x, y;
            if (MathX.GcdEx(value, Mod, out x, out y) != 1)
            {
                throw new InvalidOperationException("'Value' and 'Mod' must be disjoint.");
            }
            return x;
        }

        public ModInt Square()
        {
            return this * this;
        }

        public ModInt Pow(long exp)
        {
            if (exp == 0) return 1;
            if (exp % 2 == 0) return Pow(exp / 2).Square();
            return this * Pow(exp - 1);
        }

        public static implicit operator ModInt(long value)
        {
            return new ModInt(value);
        }

        public static ModInt operator +(ModInt left, ModInt right)
        {
            return left.value + right.value;
        }

        public static ModInt operator -(ModInt left, ModInt right)
        {
            return left.value - right.value;
        }

        public static ModInt operator *(ModInt left, ModInt right)
        {
            return left.value * right.value;
        }

        public static ModInt operator /(ModInt left, ModInt right)
        {
            return left * right.Inverse;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ModInt)) return false;
            return value == ((ModInt)obj).value;
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
    //$modint
}
