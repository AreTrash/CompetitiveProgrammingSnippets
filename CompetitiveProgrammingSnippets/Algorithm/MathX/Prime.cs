using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm.MathX
{
    using __int__ = Int32;

    //$prime
    //@Prime 素数列挙(2 ~ max), 素数判定(n <= max ^ 2), 因数分解(1 <= n <= max ^ 2)
    public class Prime
    {
        readonly List<__int__> primes;
        public IReadOnlyList<__int__> List { get { return primes; } }

        public Prime(int max)
        {
            primes = new List<__int__>();

            var sieve = new bool[max + 1];
            for (var i = 2; i <= max; i++)
            {
                if (sieve[i]) continue;
                primes.Add(i);
                for (var j = i * 2; j <= max; j += i) sieve[j] = true;
            }
        }

        public bool Is(__int__ n)
        {
            return n > 1 && primes.TakeWhile(p => p * p <= n).All(p => n % p != 0);
        }

        public IEnumerable<__int__> Factorize(__int__ n)
        {
            foreach (var p in primes.TakeWhile(p => p * p <= n))
            {
                while (n % p == 0)
                {
                    n /= p;
                    yield return p;
                }
            }
            if (n != 1) yield return n;
        }
    }
    //$prime
}
