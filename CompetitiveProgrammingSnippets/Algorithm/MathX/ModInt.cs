using System;

namespace Algorithm.MathX
{
    //A^N mod P の周期は P-1（フェルマーの小定理？）
    //ただ0^0になったときの場合分けが面倒なので実装は取り敢えず保留
    //if (exp >= Mod - 1) return Pow(exp % (Mod - 1));
    //http://hamayanhamayan.hatenablog.jp/entry/2017/10/14/125941 @hamayanhamayan0さん

    //繰り返し二乗法
    //http://satanic0258.hatenablog.com/entry/2016/04/29/004730 ‎@satanic0258さん

    //逆元、拡張ユークリッドの互除法使うやつ dependency: mathx, gcdex
    /*
    ModInt GetInverse()
    {
       int x, y;
       if (MathX.GcdEx(Value, Mod, out x, out y) != 1)
       {
           throw new InvalidOperationException("'Value' and 'Mod' must be disjoint.");
       }
       return x;
    }
    */

    //$modint
    //@ModInt Modは素数推奨
    public struct ModInt
    {
        public static int DefaultMod = 1000000007;

        readonly long value;
        readonly int mod;

        public int Value { get { return (int)value; } }
        public int Mod { get { return mod; } }
        public ModInt Inverse { get { return GetInverse(); } }

        public ModInt(long value) : this(value, DefaultMod) { }

        public ModInt(long value, int mod)
        {
            value %= mod;
            this.value = value < 0 ? value + mod : value;
            this.mod = mod;
        }

        ModInt GetInverse()
        {
            if (value == 0) throw new InvalidOperationException("value must NOT equal 0");
            return Pow(Mod - 2);
        }

        public ModInt Square()
        {
            return this * this;
        }

        public ModInt Pow(long exp)
        {
            if (exp == 0) return new ModInt(1, mod);
            if (exp % 2 == 0) return Pow(exp / 2).Square();
            return this * Pow(exp - 1);
        }

        public static ModInt Parse(string str)
        {
            return long.Parse(str);
        }

        public static ModInt Parse(string str, int mod)
        {
            return new ModInt(long.Parse(str), mod);
        }

        public static implicit operator ModInt(long value)
        {
            return new ModInt(value);
        }

        static void AssertSameMod(ModInt left, ModInt right)
        {
            if (left.mod != right.mod) throw new ArgumentException($"{nameof(left.Mod)} != {nameof(right.Mod)}");
        }

        public static ModInt operator +(ModInt left, ModInt right)
        {
            AssertSameMod(left, right);
            return new ModInt(left.value + right.value, left.mod);
        }

        public static ModInt operator +(ModInt mi, long num)
        {
            return mi + new ModInt(num, mi.mod);
        }

        public static ModInt operator -(ModInt left, ModInt right)
        {
            AssertSameMod(left, right);
            return new ModInt(left.value - right.value, left.mod);
        }

        public static ModInt operator -(ModInt mi, long num)
        {
            return mi - new ModInt(num, mi.mod);
        }

        public static ModInt operator *(ModInt left, ModInt right)
        {
            AssertSameMod(left, right);
            return new ModInt(left.value * right.value, left.mod);
        }

        public static ModInt operator *(ModInt mi, long num)
        {
            return mi * new ModInt(num, mi.mod);
        }

        public static ModInt operator /(ModInt left, ModInt right)
        {
            return left * right.Inverse;
        }

        public static ModInt operator /(ModInt mi, long num)
        {
            return mi / new ModInt(num, mi.mod);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ModInt)) return false;
            var mi = (ModInt)obj;
            return value == mi.value && mod == mi.mod;
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