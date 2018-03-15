using System;

namespace Algorithm.MathX
{
    using __long__ = Int64;

    //Modがstaticなので一つのプロジェクトでの複数のModには対応していない
    //ModのセットはModIntを使う前にする

    //BigIntegerに対応するとなぜかintやlongからの暗黙のキャストが効かないので以下のメソッドを追加する
    /*
    public static implicit operator ModInt(long value)
    {
        return new ModInt(value);
    }
    */
    //ただ、BigInteger遅すぎて辛い

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
        public static int Mod = 1000000007;

        readonly __long__ value;
        public int Value { get { return (int)value; } }
        public ModInt Inverse { get { return GetInverse(); } }

        public ModInt(__long__ value)
        {
            value %= Mod;
            this.value = value < 0 ? value + Mod : value;
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

        public ModInt Pow(__long__ exp)
        {
            if (exp == 0) return 1;
            if (exp % 2 == 0) return Pow(exp / 2).Square();
            return this * Pow(exp - 1);
        }

        public static ModInt Parse(string str)
        {
            return __long__.Parse(str);
        }

        public static implicit operator ModInt(__long__ value)
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
