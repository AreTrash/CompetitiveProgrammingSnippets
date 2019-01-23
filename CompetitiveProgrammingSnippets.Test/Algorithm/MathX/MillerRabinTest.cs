using System;
using System.Diagnostics;
using System.Numerics;
using Xunit;

namespace Algorithm.MathX
{
    public class MillerRabinTest
    {
        [Fact]
        void Prime()
        {
            Assert.True(MillerRabin.IsPrime(2));
            Assert.True(MillerRabin.IsPrime(3));
            Assert.True(MillerRabin.IsPrime(11));
            Assert.True(MillerRabin.IsPrime(100003));
            Assert.True(MillerRabin.IsPrime(679067));
            Assert.True(MillerRabin.IsPrime(1000000007));
            Assert.True(MillerRabin.IsPrime(1000000000000000003));

            var e64 = "10000000000000000000000000000000000000000000000000000000000000057";
            Assert.True(MillerRabin.IsPrime(BigInteger.Parse(e64)));

            //素数大富豪
            var primeMillionaire = "99998888777766665555444433332222131313131313121212121111111011010101111";
            Assert.True(MillerRabin.IsPrime(BigInteger.Parse(primeMillionaire)));

            //メルセンヌ素数
            var mersennePrime12th = BigInteger.Pow(2, 127) - 1;
            Assert.True(MillerRabin.IsPrime(mersennePrime12th));
        }

        [Fact]
        void NotPrime()
        {
            Assert.False(MillerRabin.IsPrime(0));
            Assert.False(MillerRabin.IsPrime(1));
            Assert.False(MillerRabin.IsPrime(57));
            Assert.False(MillerRabin.IsPrime(3215031751));
        }

        /*
        [Fact]
        void Performance()
        {
            const long Min = 0;
            const long Max = 10000000;
            var so = new Stopwatch();
            
            so.Start();
            var prime =  new Prime();
            var pc1 = 0;
            for (var i = Min; i <= Max; i++)
            {
                if (prime.Is(i)) pc1++;
            }
            so.Stop();
            Console.WriteLine(so.ElapsedMilliseconds);

            so.Reset();
            so.Start();
            var pc2 = 0;
            for (var i = Min; i <= Max; i++)
            {
                if (MillerRabin.IsPrime(i)) pc2++;
            }
            so.Stop();
            Console.WriteLine(so.ElapsedMilliseconds);
            Assert.Equal(pc1, pc2);
        }
        */
    }
}