using System;
using Xunit;

namespace Algorithm.MathX
{
    public class ModIntTest : IDisposable
    {
        readonly int OriginalMod;

        public ModIntTest()
        {
            OriginalMod = ModInt.Mod;
            ModInt.Mod = 17;
        }

        [Fact]
        void Construct()
        {
            Assert.Equal(12, new ModInt(12).Value);
            Assert.Equal(0, new ModInt(17).Value);
            Assert.Equal(0, new ModInt(0).Value);
            Assert.Equal(8, new ModInt(42).Value);
            Assert.Equal(15, new ModInt(100).Value);
            Assert.Equal(0, new ModInt(171717).Value);

            Assert.Equal(15, new ModInt((long)1e18).Value);

            Assert.Equal(14, new ModInt(-3).Value);
            Assert.Equal(0, new ModInt(-17).Value);
            Assert.Equal(9, new ModInt(-42).Value);
        }

        [Fact]
        void Inverse()
        {
            Assert.Equal(1, new ModInt(1).Inverse.Value);
            Assert.Equal(7, new ModInt(5).Inverse.Value);
            Assert.Equal(12, new ModInt(10).Inverse.Value);

            Assert.Throws<InvalidOperationException>(() => new ModInt(0).Inverse);
        }

        [Fact]
        void Implicit()
        {
            Assert.Equal(new ModInt(42), (ModInt)42);
        }

        [Fact]
        void Add()
        {
            Assert.Equal(7, ((ModInt)3 + 4).Value);
            Assert.Equal(0, ((ModInt)8 + 9).Value);
            Assert.Equal(6, ((ModInt)11 + 12).Value);
        }

        [Fact]
        void Subtract()
        {
            Assert.Equal(4, ((ModInt)7 - 3).Value);
            Assert.Equal(9, ((ModInt)0 - 8).Value);
            Assert.Equal(3, ((ModInt)36 - 16).Value);
        }

        [Fact]
        void Multiply()
        {
            Assert.Equal(12, ((ModInt)3 * 4).Value);
            Assert.Equal(4, ((ModInt)8 * 9).Value);
            Assert.Equal(5, ((ModInt)(-4) * 3).Value);
        }

        [Fact]
        void Divide()
        {
            Assert.Equal(4, ((ModInt)12 / 3).Value);
            Assert.Equal(9, ((ModInt)36 / 4).Value);
            Assert.Equal(7, ((ModInt)48 / 2).Value);
            Assert.Equal(2, ((ModInt)48 / 24).Value);
            Assert.Equal(5, ((ModInt)100 / 20).Value);
            Assert.Equal(0, ((ModInt)51 / 3).Value);

            Assert.Throws<InvalidOperationException>(() => (ModInt)51 / 17);
        }

        [Fact]
        void Pow()
        {
            Assert.Equal(10, ((ModInt)3).Pow(3).Value);
            Assert.Equal(16, ((ModInt)2).Pow(100).Value);
            Assert.Equal(1, ((ModInt)2).Pow(1000).Value);
            Assert.Equal(1, ((ModInt)2).Pow(16).Value);

            Assert.Equal(0, ((ModInt)0).Pow(999).Value);
            Assert.Equal(1, ((ModInt)999).Pow(0).Value);

            Assert.Equal(0, ((ModInt)0).Pow(16).Value);
            Assert.Equal(1, ((ModInt)17).Pow(0).Value);

            Assert.Equal(1, ((ModInt)0).Pow(0).Value);
        }

        public void Dispose()
        {
            ModInt.Mod = OriginalMod;
        }
    }
}
