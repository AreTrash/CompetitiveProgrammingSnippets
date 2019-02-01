using System;
using Xunit;

namespace Algorithm.MathX
{
    public class ModIntTest
    {
        [Fact]
        void Construct()
        {
            Assert.Equal(12, new ModInt(12, 13).Value);
            Assert.Equal(0, new ModInt(13, 13).Value);
            Assert.Equal(0, new ModInt(0, 13).Value);
            Assert.Equal(12, new ModInt(25, 13).Value);
            Assert.Equal(0, new ModInt(26, 13).Value);
            Assert.Equal(1, new ModInt(27, 13).Value);

            Assert.Equal(10, new ModInt(-3, 13).Value);
            Assert.Equal(1, new ModInt(-25, 13).Value);
            Assert.Equal(0, new ModInt(-26, 13).Value);
            Assert.Equal(12, new ModInt(-27, 13).Value);
        }

        [Fact]
        void Inverse()
        {
            Assert.Equal(1, new ModInt(1, 13).Inverse.Value);
            Assert.Equal(8, new ModInt(5, 13).Inverse.Value);
            Assert.Equal(4, new ModInt(10, 13).Inverse.Value);
            Assert.Throws<InvalidOperationException>(() => new ModInt(0, 13).Inverse);
        }

        [Fact]
        void Implicit()
        {
            Assert.Equal(new ModInt(42), (ModInt)42);
            Assert.Equal(ModInt.DefaultMod, ((ModInt)42).Mod);
        }

        [Fact]
        void Add()
        {
            Assert.Equal(7, (new ModInt(3, 13) + new ModInt(4, 13)).Value);
            Assert.Equal(0, (new ModInt(6, 13) + new ModInt(7, 13)).Value);
            Assert.Equal(4, (new ModInt(8, 13) + new ModInt(9, 13)).Value);
        }

        [Fact]
        void Subtract()
        {
            Assert.Equal(4, (new ModInt(7, 13) - new ModInt(3, 13)).Value);
            Assert.Equal(0, (new ModInt(0, 13) - new ModInt(0, 13)).Value);
            Assert.Equal(12, (new ModInt(0, 13) - new ModInt(1, 13)).Value);
        }

        [Fact]
        void Multiply()
        {
            Assert.Equal(12, (new ModInt(3, 13) * new ModInt(4, 13)).Value);
            Assert.Equal(2, (new ModInt(3, 13) * new ModInt(5, 13)).Value);
            Assert.Equal(12, (new ModInt(-3, 13) * new ModInt(-4, 13)).Value);
        }

        [Fact]
        void Divide()
        {
            Assert.Equal(4, (new ModInt(12, 13) / new ModInt(3, 13)).Value);
            Assert.Equal(3, (new ModInt(36, 13) / new ModInt(12, 13)).Value);
            Assert.Equal(0, (new ModInt(0, 13) / new ModInt(3, 13)).Value);
            Assert.Throws<InvalidOperationException>(() => new ModInt(7, 13) / new ModInt(0, 13));
        }

        [Fact]
        void Pow()
        {
            Assert.Equal(2, new ModInt(2, 13).Pow(1).Value);
            Assert.Equal(8, new ModInt(2, 13).Pow(3).Value);
            Assert.Equal(6, new ModInt(2, 13).Pow(5).Value);

            Assert.Equal(7, new ModInt(2, 13).Pow(11).Value);
            Assert.Equal(1, new ModInt(2, 13).Pow(12).Value);
            Assert.Equal(2, new ModInt(2, 13).Pow(13).Value);

            Assert.Equal(0, new ModInt(0, 13).Pow(99).Value);
            Assert.Equal(1, new ModInt(2, 13).Pow(0).Value);
            Assert.Equal(1, new ModInt(0, 13).Pow(0).Value);
        }

        [Fact]
        void ModAssertion()
        {
            Assert.Throws<ArgumentException>(() => new ModInt(12, 13) + new ModInt(4, 17));
            Assert.Throws<ArgumentException>(() => new ModInt(12, 13) - new ModInt(4, 17));
            Assert.Throws<ArgumentException>(() => new ModInt(12, 13) * new ModInt(4, 17));
            Assert.Throws<ArgumentException>(() => new ModInt(12, 13) / new ModInt(4, 17));

            Assert.Throws<ArgumentException>(() => 12 + new ModInt(4, 17));
            Assert.Throws<ArgumentException>(() => 12 - new ModInt(4, 17));
            Assert.Throws<ArgumentException>(() => 12 * new ModInt(4, 17));
            Assert.Throws<ArgumentException>(() => 12 / new ModInt(4, 17));

            Assert.Equal(3, (new ModInt(12, 13) + 4).Value);
            Assert.Equal(8, (new ModInt(12, 13) - 4).Value);
            Assert.Equal(9, (new ModInt(12, 13) * 4).Value);
            Assert.Equal(3, (new ModInt(12, 13) / 4).Value);

            Assert.Throws<ArgumentException>(() => new ModInt(12, 13) + (ModInt)4);
            Assert.Throws<ArgumentException>(() => new ModInt(12, 13) - (ModInt)4);
            Assert.Throws<ArgumentException>(() => new ModInt(12, 13) * (ModInt)4);
            Assert.Throws<ArgumentException>(() => new ModInt(12, 13) / (ModInt)4);
        }
    }
}