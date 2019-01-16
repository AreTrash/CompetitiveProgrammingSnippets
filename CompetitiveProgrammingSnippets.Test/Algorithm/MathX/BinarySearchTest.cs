using System;
using Xunit;

namespace Algorithm.MathX
{
    public class BinarySearchTest
    {
        [Fact]
        void Exist()
        {
            var inc = new long[] {1, 5, 6, 7, 9};
            Assert.Equal(0, inc.OutLeft(5));
            Assert.Equal(1, inc.InLeft(5));
            Assert.Equal(1, inc.InRight(5));
            Assert.Equal(2, inc.OutRight(5));

            var dec = new long[] {9, 5, 3, 2, 1};
            Assert.Equal(0, dec.OutLeft(5));
            Assert.Equal(1, dec.InLeft(5));
            Assert.Equal(1, dec.InRight(5));
            Assert.Equal(2, dec.OutRight(5));
        }

        [Fact]
        void ExistMultiple()
        {
            var a = new long[] {1, 5, 5, 5, 9};

            Assert.Equal(0, a.OutLeft(5));
            Assert.Equal(1, a.InLeft(5));
            Assert.Equal(3, a.InRight(5));
            Assert.Equal(4, a.OutRight(5));
        }

        [Fact]
        void ExistFirst()
        {
            var a = new long[] {5, 6, 7, 8, 9};

            Assert.Equal(-1, a.OutLeft(5));
            Assert.Equal(0, a.InLeft(5));
            Assert.Equal(0, a.InRight(5));
            Assert.Equal(1, a.OutRight(5));
        }

        [Fact]
        void ExistLast()
        {
            var a = new long[] {1, 2, 3, 4, 5};

            Assert.Equal(3, a.OutLeft(5));
            Assert.Equal(4, a.InLeft(5));
            Assert.Equal(4, a.InRight(5));
            Assert.Equal(5, a.OutRight(5));
        }

        [Fact]
        void InsideButNotExist()
        {
            var a = new long[] {0, 2, 4, 6, 8};

            Assert.Equal(2, a.OutLeft(5));
            Assert.Equal(2, a.InLeft(5));
            Assert.Equal(3, a.InRight(5));
            Assert.Equal(3, a.OutRight(5));
        }

        [Fact]
        void OutOfLeft()
        {
            var a = new long[] {6, 7, 8, 9, 10};

            Assert.Equal(-1, a.OutLeft(5));
            Assert.Equal(-1, a.InLeft(5));
            Assert.Equal(-1, a.InRight(5));
            Assert.Equal(-1, a.OutRight(5));
        }

        [Fact]
        void OutOfRight()
        {
            var a = new long[] {0, 1, 2, 3, 4};

            Assert.Equal(5, a.OutLeft(5));
            Assert.Equal(5, a.InLeft(5));
            Assert.Equal(5, a.InRight(5));
            Assert.Equal(5, a.OutRight(5));
        }

        [Fact]
        void Phi()
        {
            var inc = new long[0];

            Assert.Throws<ArgumentException>(() => inc.InLeft(5));
            Assert.Throws<ArgumentException>(() => inc.OutLeft(5));
            Assert.Throws<ArgumentException>(() => inc.InRight(5));
            Assert.Throws<ArgumentException>(() => inc.OutRight(5));
        }

        [Fact]
        void Single()
        {
            var a = new long[] {5};

            Assert.Equal(-1, a.OutLeft(5));
            Assert.Equal(0, a.InLeft(5));
            Assert.Equal(0, a.InRight(5));
            Assert.Equal(1, a.OutRight(5));
        }

        [Fact]
        void Double()
        {
            var a = new long[] {0, 10};

            Assert.Equal(0, a.OutLeft(5));
            Assert.Equal(0, a.InLeft(5));
            Assert.Equal(1, a.InRight(5));
            Assert.Equal(1, a.OutRight(5));
        }

        [Fact]
        void AllSame()
        {
            var a = new long[] {5, 5, 5, 5, 5};

            Assert.Equal(-1, a.OutLeft(5));
            Assert.Equal(0, a.InLeft(5));
            Assert.Equal(4, a.InRight(5));
            Assert.Equal(5, a.OutRight(5));
        }

        [Fact]
        void Range()
        {
            Assert.Equal(3, new long[] {0, 1, 2, 3, 4}.Range(1, 3));
            Assert.Equal(4, new long[] {0, 1, 1, 1, 3, 4}.Range(1, 3));
            Assert.Equal(4, new long[] {0, 1, 1, 3, 3, 4}.Range(1, 3));
            Assert.Equal(4, new long[] {0, 1, 3, 3, 3, 4}.Range(1, 3));
            Assert.Equal(2, new long[] {0, 1, 3}.Range(1, 3));
            Assert.Equal(2, new long[] {1, 3, 4}.Range(1, 3));
            Assert.Equal(4, new long[] {0, 2, 2, 2, 3}.Range(1, 3));
            Assert.Equal(4, new long[] {1, 2, 2, 2, 4}.Range(1, 3));
            Assert.Equal(3, new long[] {2, 2, 2}.Range(1, 3));
            Assert.Equal(1, new long[] {0, 1}.Range(1, 3));
            Assert.Equal(1, new long[] {3, 4}.Range(1, 3));
            Assert.Equal(0, new long[] {0}.Range(1, 3));
            Assert.Equal(1, new long[] {1}.Range(1, 3));
            Assert.Equal(1, new long[] {2}.Range(1, 3));
            Assert.Equal(1, new long[] {3}.Range(1, 3));
            Assert.Equal(0, new long[] {4}.Range(1, 3));
        }

        [Fact]
        void FuncSearch()
        {
            Func<int, long> func = x => x * x;

            Assert.Equal(4, BinarySearch.OutLeft(func, 25, 0, 20));
            Assert.Equal(5, BinarySearch.InLeft(func, 25, 0, 20));
            Assert.Equal(5, BinarySearch.InRight(func, 25, 0, 20));
            Assert.Equal(6, BinarySearch.OutRight(func, 25, 0, 20));

            Assert.Equal(0, BinarySearch.Range(func, -10, -5, 0, 20));
            Assert.Equal(1, BinarySearch.Range(func, -10, 0, 0, 20));
            Assert.Equal(5, BinarySearch.Range(func, -10, 20, 0, 20));
            Assert.Equal(6, BinarySearch.Range(func, 20, 100, 0, 20));
            Assert.Equal(11, BinarySearch.Range(func, 100, 400, 0, 20));
            Assert.Equal(1, BinarySearch.Range(func, 400, 114514, 0, 20));
            Assert.Equal(21, BinarySearch.Range(func, -114514, 114514, 0, 20));
            Assert.Equal(20, BinarySearch.Range(func, -74977, 399, 0, 20));
        }
    }
}