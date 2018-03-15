using System.Linq;
using Xunit;

namespace Algorithm.MathX
{
    public class PrimeTest
    {
        readonly Prime prime;

        public PrimeTest()
        {
            prime = new Prime(100);
        }

        [Fact]
        void Construct()
        {
            Assert.Equal(new[]{2, 3, 5, 7}, new Prime(10).List);
            Assert.Equal(new[]{2, 3, 5, 7, 11}, new Prime(11).List);
        }

        [Fact]
        void Is()
        {
            Assert.False(prime.Is(-1));
            Assert.False(prime.Is(0));
            Assert.False(prime.Is(1));

            Assert.True(prime.Is(2));
            Assert.True(prime.Is(3));
            Assert.False(prime.Is(4));

            Assert.False(prime.Is(57));

            Assert.False(prime.Is(99));
            Assert.False(prime.Is(100));
            Assert.True(prime.Is(101));

            Assert.True(prime.Is(9973));
            Assert.False(prime.Is(9999));
            Assert.False(prime.Is(10000));

            //n <= max ^ 2 じゃないと駄目
            Assert.True(prime.Is(101 * 101));
        }

        [Fact]
        void Factorize()
        {
            Assert.Equal(new int[0], prime.Factorize(1));

            Assert.Equal(new[] {2}, prime.Factorize(2));
            Assert.Equal(new[] {3}, prime.Factorize(3));
            Assert.Equal(new[] {2, 2}, prime.Factorize(4));

            Assert.Equal(new[] {3, 19}, prime.Factorize(57));
            Assert.Equal(new[] {2, 2, 5, 5}, prime.Factorize(100));
            Assert.Equal(new[] {2, 2, 2, 3, 3, 5}, prime.Factorize(360));

            Assert.Equal(new[] {9973}, prime.Factorize(9973));
            Assert.Equal(new[] {3, 3, 11, 101}, prime.Factorize(9999));
            Assert.Equal(new[] {2, 2, 2, 2, 5, 5, 5, 5}, prime.Factorize(10000));

            //n <= max ^ 2 じゃないと駄目
            Assert.Equal(new[] {10201}, prime.Factorize(101 * 101));
        }

        [Fact]
        void EulersTotient()
        {
            Assert.Equal(1, prime.EulersTotient(1));
            Assert.Equal(1, prime.EulersTotient(2));
            Assert.Equal(2, prime.EulersTotient(3));

            Assert.Equal(8, prime.EulersTotient(16));
            Assert.Equal(12, prime.EulersTotient(36));
            Assert.Equal(100, prime.EulersTotient(101));
        }
    }
}
