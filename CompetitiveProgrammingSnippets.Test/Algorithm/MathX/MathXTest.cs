using System;
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
            Assert.Equal(6, MathX.Gcd(30, 42));

            //0以下は未定義
            Assert.Equal(114, MathX.Gcd(0, 114));
            Assert.Equal(514, MathX.Gcd(514, 0));
            Assert.Equal(0, MathX.Gcd(0, 0));
        }

        [Fact]
        void Lcm()
        {
            Assert.Equal(6, MathX.Lcm(6, 6));
            Assert.Equal(6, MathX.Lcm(2, 3));
            Assert.Equal(36, MathX.Lcm(12, 18));
            Assert.Equal(36, MathX.Lcm(18, 12));

            //Assert.Throws<OverflowException>(() => MathX.Lcm(1000000007, 1000000009));

            //0以下は未定義
            Assert.Equal(0, MathX.Lcm(0, 114));
            Assert.Equal(0, MathX.Lcm(514, 0));
            Assert.Throws<DivideByZeroException>(() => MathX.Lcm(0, 0));
        }

        [Fact]
        void GcdEx()
        {
            {
                Assert.Equal((1, -12, 17), (MathX.GcdEx(41, 29, out var x, out var y), x, y));
                Assert.Equal((1, -12, 17), MathX.GcdEx(41, 29));
            }
            {
                Assert.Equal((1, 17, -12), (MathX.GcdEx(29, 41, out var x, out var y), x, y));
                Assert.Equal((1, 17, -12), MathX.GcdEx(29, 41));
            }
        }
    }
}
