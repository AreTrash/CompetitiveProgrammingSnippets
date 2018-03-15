namespace Algorithm.MathX
{
    //組み合わせ、階乗は事前計算
    //maxは10^6 ~ 10^7ぐらいが限度

    //$comb
    //@Combination n!, nCk, nPk, nHk (0 <= n, k && n + k <= max) dependency: modint
    public class Combination
    {
        readonly ModInt[] facts;

        public Combination(int max)
        {
            facts = new ModInt[max + 1];
            facts[0] = 1;
            for (var i = 1; i <= max; i++) facts[i] = facts[i - 1] * i;
        }

        public ModInt Fact(int n)
        {
            return facts[n];
        }

        public ModInt NCK(int n, int k)
        {
            if (n < k) return 0;
            return facts[n] / facts[k] / facts[n - k];
        }

        public ModInt NPK(int n, int k)
        {
            if (n < k) return 0;
            return facts[n] / facts[n - k];
        }

        public ModInt NHK(int n, int k)
        {
            if (k == 0) return 1;
            if (n == 0) return 0;
            return facts[n + k - 1] / facts[k] / facts[n - 1];
        }
    }
    //$comb
}
