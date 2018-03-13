using Xunit;

namespace Algorithm.MathX
{
    public class MathXTest
    {
        [Fact]
        void Swap()
        {
            var a = 3;
            var b = 5;
            MathX.Swap(ref a, ref b);
            Assert.Equal((5, 3), (a, b));
        }

        [Fact]
        void Gcd()
        {
            Assert.Equal(42, MathX.Gcd(42, 42));
            Assert.Equal(1, MathX.Gcd(42, 23));
            Assert.Equal(6, MathX.Gcd(42, 30));
        }

        [Fact]
        void Lcm()
        {
            Assert.Equal(6, MathX.Lcm(6, 6));
            Assert.Equal(6, MathX.Lcm(2, 3));
            Assert.Equal(36, MathX.Lcm(12, 18));
        }
    }
}
