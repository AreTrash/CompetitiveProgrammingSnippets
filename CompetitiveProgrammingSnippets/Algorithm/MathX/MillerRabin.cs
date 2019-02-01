using System;
using System.Linq;
using System.Numerics;

namespace Algorithm.MathX
{
    //$millerRabin
    public static class MillerRabin
    {
        const int RandomTestCount = 30;

        static readonly BigInteger[] BasePrimes = {2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41,};
        static readonly BigInteger[] WitnessRanges =
        {
            2047,
            1373653,
            25326001,
            118670087467, //3215031751が例外
            2152302898747,
            3474749660383,
            341550071728321,
            341550071728321,
            3825123056546413051,
            3825123056546413051,
            3825123056546413051,
            BigInteger.Parse("318665857834031151167461"),
            BigInteger.Parse("3317044064679887385961981"),
        };

        public static bool IsPrime(BigInteger n)
        {
            if (n < 2 || n == 3215031751) return false;
            if (n < 42) return BasePrimes.Contains(n);
            if (BasePrimes.Any(p => n % p == 0)) return false;

            var d = n - 1;
            while ((d & 1) == 0) d >>= 1;

            for (var i = 0; i < BasePrimes.Length; i++)
            {
                if (!MillerRabinTest(n, d, BasePrimes[i])) return false;
                if (n < WitnessRanges[i]) return true;
            }

            //n > 3.3e24
            var random = new Random();
            for (var i = 0; i < RandomTestCount; i++)
            {
                if (!MillerRabinTest(n, d, random.Next(1, int.MaxValue))) return false;
            }
            return true;
        }

        static bool MillerRabinTest(BigInteger n, BigInteger d, BigInteger a)
        {
            a = BigInteger.ModPow(a, d, n);
            if (a == 1 || a == n - 1) return true;

            while ((d <<= 1) < n - 1)
            {
                a = a * a % n;
                if (a == n - 1) return true;
            }

            return false;
        }
    }
    //$millerRabin
}