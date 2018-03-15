using Xunit;

namespace Algorithm.MathX
{
    public class CombinationTest
    {
        readonly Combination comb;

        public CombinationTest()
        {
            this.comb = new Combination(200);
        }

        [Fact]
        void Fact()
        {
            Assert.Equal(1, comb.Fact(0));
            Assert.Equal(1, comb.Fact(1));
            Assert.Equal(2, comb.Fact(2));
            Assert.Equal(3628800, comb.Fact(10));
            Assert.Equal(437918130, comb.Fact(100));
        }

        [Fact]
        void NCK()
        {
            Assert.Equal(0, comb.NCK(0, 1));
            Assert.Equal(1, comb.NCK(1, 0));
            Assert.Equal(1, comb.NCK(1, 1));
            Assert.Equal(0, comb.NCK(1, 2));

            Assert.Equal(4, comb.NCK(4, 1));
            Assert.Equal(6, comb.NCK(4, 2));
            Assert.Equal(4, comb.NCK(4, 3));

            Assert.Equal(538992043, comb.NCK(100, 50));
        }

        [Fact]
        void NPK()
        {
            Assert.Equal(0, comb.NPK(0, 1));
            Assert.Equal(1, comb.NPK(1, 0));
            Assert.Equal(1, comb.NPK(1, 1));
            Assert.Equal(0, comb.NPK(1, 2));

            Assert.Equal(4, comb.NPK(4, 1));
            Assert.Equal(12, comb.NPK(4, 2));
            Assert.Equal(24, comb.NPK(4, 3));

            Assert.Equal(505671657, comb.NPK(100, 50));
        }

        [Fact]
        void NHK()
        {
            Assert.Equal(0, comb.NHK(0, 1));
            Assert.Equal(1, comb.NHK(1, 0));
            Assert.Equal(1, comb.NHK(1, 1));
            Assert.Equal(1, comb.NHK(1, 2));

            Assert.Equal(4, comb.NHK(4, 1));
            Assert.Equal(10, comb.NHK(4, 2));
            Assert.Equal(20, comb.NHK(4, 3));
            Assert.Equal(35, comb.NHK(4, 4));
            Assert.Equal(56, comb.NHK(4, 5));

            Assert.Equal(475860182, comb.NHK(100, 50));
        }
    }
}
