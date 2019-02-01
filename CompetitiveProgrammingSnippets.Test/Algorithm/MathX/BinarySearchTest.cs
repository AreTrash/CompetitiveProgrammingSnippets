using Xunit;

namespace Algorithm.MathX
{
    public class BinarySearchTest
    {
        [Fact]
        void Exist()
        {
            var bs = new[] {1, 5, 6, 7, 9}.ToBinarySearch();
            Assert.Equal(1, bs.LowerBound(5));
            Assert.Equal(2, bs.UpperBound(5));
        }

        [Fact]
        void ExistMultiple()
        {
            var bs = new[] {1, 5, 5, 5, 9}.ToBinarySearch();
            Assert.Equal(1, bs.LowerBound(5));
            Assert.Equal(4, bs.UpperBound(5));
        }

        [Fact]
        void ExistFirst()
        {
            var bs = new[] {5, 6, 7, 8, 9}.ToBinarySearch();
            Assert.Equal(0, bs.LowerBound(5));
            Assert.Equal(1, bs.UpperBound(5));
        }

        [Fact]
        void ExistLast()
        {
            var bs = new[] {1, 2, 3, 4, 5}.ToBinarySearch();
            Assert.Equal(4, bs.LowerBound(5));
            Assert.Equal(5, bs.UpperBound(5));
        }

        [Fact]
        void InsideButNotExist()
        {
            var bs = new[] {0, 2, 4, 6, 8}.ToBinarySearch();
            Assert.Equal(3, bs.LowerBound(5));
            Assert.Equal(3, bs.UpperBound(5));
        }

        [Fact]
        void OutOfLeft()
        {
            var bs = new[] {6, 7, 8, 9, 10}.ToBinarySearch();
            Assert.Equal(0, bs.LowerBound(5));
            Assert.Equal(0, bs.UpperBound(5));
        }

        [Fact]
        void OutOfRight()
        {
            var bs = new[] {0, 1, 2, 3, 4}.ToBinarySearch();
            Assert.Equal(5, bs.LowerBound(5));
            Assert.Equal(5, bs.UpperBound(5));
        }

        [Fact]
        void Phi()
        {
            var bs = new int[0].ToBinarySearch();
            Assert.Equal(0, bs.LowerBound(5));
            Assert.Equal(0, bs.UpperBound(5));
        }

        [Fact]
        void Single()
        {
            var bs = new[] {5}.ToBinarySearch();
            Assert.Equal(0, bs.LowerBound(5));
            Assert.Equal(1, bs.UpperBound(5));
        }

        [Fact]
        void Double()
        {
            var bs = new[] {0, 10}.ToBinarySearch();
            Assert.Equal(1, bs.LowerBound(5));
            Assert.Equal(1, bs.UpperBound(5));
        }

        [Fact]
        void AllSame()
        {
            var bs = new[] {5, 5, 5, 5, 5}.ToBinarySearch();
            Assert.Equal(0, bs.LowerBound(5));
            Assert.Equal(5, bs.UpperBound(5));
        }

        [Fact]
        void Range()
        {
            Assert.Equal(3, new[] {0, 1, 2, 3, 4}.ToBinarySearch().Range(1, 3));
            Assert.Equal(4, new[] {0, 1, 1, 1, 3, 4}.ToBinarySearch().Range(1, 3));
            Assert.Equal(4, new[] {0, 1, 1, 3, 3, 4}.ToBinarySearch().Range(1, 3));
            Assert.Equal(4, new[] {0, 1, 3, 3, 3, 4}.ToBinarySearch().Range(1, 3));
            Assert.Equal(2, new[] {0, 1, 3}.ToBinarySearch().Range(1, 3));
            Assert.Equal(2, new[] {1, 3, 4}.ToBinarySearch().Range(1, 3));
            Assert.Equal(4, new[] {0, 2, 2, 2, 3}.ToBinarySearch().Range(1, 3));
            Assert.Equal(4, new[] {1, 2, 2, 2, 4}.ToBinarySearch().Range(1, 3));
            Assert.Equal(3, new[] {2, 2, 2}.ToBinarySearch().Range(1, 3));
            Assert.Equal(1, new[] {0, 1}.ToBinarySearch().Range(1, 3));
            Assert.Equal(1, new[] {3, 4}.ToBinarySearch().Range(1, 3));
            Assert.Equal(0, new[] {0}.ToBinarySearch().Range(1, 3));
            Assert.Equal(1, new[] {1}.ToBinarySearch().Range(1, 3));
            Assert.Equal(1, new[] {2}.ToBinarySearch().Range(1, 3));
            Assert.Equal(1, new[] {3}.ToBinarySearch().Range(1, 3));
            Assert.Equal(0, new[] {4}.ToBinarySearch().Range(1, 3));

            Assert.Equal(0, new[] {0, 1, 2, 3, 4}.ToBinarySearch().Range(3, 1));
            Assert.Equal(3, new[] {1, 2, 2, 2, 4}.ToBinarySearch().Count(2));
        }

        [Fact]
        void StringSearch()
        {
            var a = new[] {"a", "bb", "ccc", "e", "ff"}.ToBinarySearch();
            Assert.Equal(2, a.LowerBound("ccc"));
            Assert.Equal(3, a.UpperBound("ccc"));
            Assert.Equal(3, a.LowerBound("ddd"));
            Assert.Equal(3, a.UpperBound("ddd"));
        }

        [Fact]
        void FuncSearch()
        {
            var bs = BinarySearch.Default(x => x * x, 0, 20);
            Assert.Equal(5, bs.LowerBound(25));
            Assert.Equal(6, bs.UpperBound(25));
        }
    }
}