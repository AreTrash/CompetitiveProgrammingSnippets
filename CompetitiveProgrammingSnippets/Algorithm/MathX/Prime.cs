using System.Collections.Generic;
using System.Linq;

namespace Algorithm.MathX
{
    //$prime
    //@Prime 素数列挙(2 ~ max), 素数判定(n <= max ^ 2), 素因数分解(1 <= n <= max ^ 2)
    public class Prime
    {
        const int CoverIntRangeMax = 46349;
        readonly List<int> primes;
        public IReadOnlyList<int> List { get { return primes; } }

        public Prime(int max = CoverIntRangeMax)
        {
            primes = new List<int>();
            var sieve = new bool[max + 1];
            for (var i = 2; i <= max; i++)
            {
                if (sieve[i]) continue;
                primes.Add(i);
                for (var j = i << 1; j <= max; j += i) sieve[j] = true;
            }
        }

        public bool Is(long n)
        {
            return n > 1 && List.TakeWhile(p => p * p <= n).All(p => n % p != 0);
        }

        public IEnumerable<long> Factorize(long n)
        {
            foreach (var p in List.TakeWhile(p => p * p <= n))
            {
                while (n % p == 0)
                {
                    n /= p;
                    yield return p;
                }
            }
            if (n != 1) yield return n;
        }

        public long EulersTotient(long n)
        {
            foreach (var x in Factorize(n).Distinct()) n = n / x * (x - 1);
            return n;
        }
    }
    //$prime
}
