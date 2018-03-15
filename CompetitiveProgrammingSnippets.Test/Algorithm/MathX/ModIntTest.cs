using System;
using Xunit;

namespace Algorithm.MathX
{
    public class ModIntTest
    {
        [Fact]
        void Construct()
        {
            Assert.Equal(12, new ModInt(12).Value);
            Assert.Equal(0, new ModInt(1000000007).Value);
            Assert.Equal(0, new ModInt(0).Value);
            Assert.Equal(1000000006, new ModInt(2000000013).Value);
            Assert.Equal(0, new ModInt(2000000014).Value);
            Assert.Equal(1, new ModInt(2000000015).Value);

            Assert.Equal(49, new ModInt((long)1e18).Value);

            Assert.Equal(1000000004, new ModInt(-3).Value);
            Assert.Equal(1, new ModInt(-2000000013).Value);
            Assert.Equal(0, new ModInt(-2000000014).Value);
            Assert.Equal(1000000006, new ModInt(-2000000015).Value);
        }

        [Fact]
        void Inverse()
        {
            Assert.Equal(1, new ModInt(1).Inverse.Value);
            Assert.Equal(400000003, new ModInt(5).Inverse.Value);
            Assert.Equal(700000005, new ModInt(10).Inverse.Value);

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
            Assert.Equal(1000000006, ((ModInt)1000000000 + 6).Value);
            Assert.Equal(0, ((ModInt)1000000000 + 7).Value);
            Assert.Equal(1, ((ModInt)1000000000 + 8).Value);
        }

        [Fact]
        void Subtract()
        {
            Assert.Equal(4, ((ModInt)7 - 3).Value);
            Assert.Equal(0, ((ModInt)0 - 0).Value);
            Assert.Equal(1000000006, ((ModInt)0 - 1).Value);
        }

        [Fact]
        void Multiply()
        {
            Assert.Equal(12, ((ModInt)3 * 4).Value);
            Assert.Equal(999999995, ((ModInt)(-4) * 3).Value);
            Assert.Equal(724778809, ((ModInt)114514 * 364364).Value);
        }

        [Fact]
        void Divide()
        {
            Assert.Equal(4, ((ModInt)12 / 3).Value);
            Assert.Equal(500000010, ((ModInt)1000000020 / 2).Value);
            Assert.Equal(13, ((ModInt)2000000040 / 2).Value);
            Assert.Equal(2, ((ModInt)2000000040 / 1000000020).Value);
            Assert.Equal(5, ((ModInt)5000000100 / 1000000020).Value);
            Assert.Equal(0, ((ModInt)5000000035 / 5).Value);

            Assert.Throws<InvalidOperationException>(() => (ModInt)5000000035 / 1000000007);
        }

        [Fact]
        void Pow()
        {
            Assert.Equal(2, ((ModInt)2).Pow(1).Value);
            Assert.Equal(1024, ((ModInt)2).Pow(10).Value);
            Assert.Equal(976371285, ((ModInt)2).Pow(100).Value);
            Assert.Equal(688423210, ((ModInt)2).Pow(1000).Value);

            Assert.Equal(500000004, ((ModInt)2).Pow(1000000005).Value);
            Assert.Equal(1, ((ModInt)2).Pow(1000000006).Value);
            Assert.Equal(2, ((ModInt)2).Pow(1000000007).Value);

            Assert.Equal(0, ((ModInt)0).Pow(99999).Value);
            Assert.Equal(1, ((ModInt)99999).Pow(0).Value);

            Assert.Equal(0, ((ModInt)0).Pow(1000000005).Value);
            Assert.Equal(0, ((ModInt)0).Pow(1000000006).Value);
            Assert.Equal(0, ((ModInt)0).Pow(1000000007).Value);

            Assert.Equal(1, ((ModInt)1000000007).Pow(0).Value);
            Assert.Equal(1, ((ModInt)0).Pow(0).Value);
        }
    }
}
