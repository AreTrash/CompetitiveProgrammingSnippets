using System;
using Xunit;

namespace Algorithm.MathX
{
    public class BinarySearchTest
    {
        [Fact]
        void Exist()
        {
            var a = new long[] {1, 5, 6, 7, 9};
            Assert.Equal(1, a.LowerBound(5));
            Assert.Equal(2, a.UpperBound(5));
        }

        [Fact]
        void ExistMultiple()
        {
            var a = new long[] {1, 5, 5, 5, 9};
            Assert.Equal(1, a.LowerBound(5));
            Assert.Equal(4, a.UpperBound(5));
        }

        [Fact]
        void ExistFirst()
        {
            var a = new long[] {5, 6, 7, 8, 9};
            Assert.Equal(0, a.LowerBound(5));
            Assert.Equal(1, a.UpperBound(5));
        }

        [Fact]
        void ExistLast()
        {
            var a = new long[] {1, 2, 3, 4, 5};
            Assert.Equal(4, a.LowerBound(5));
            Assert.Equal(5, a.UpperBound(5));
        }

        [Fact]
        void InsideButNotExist()
        {
            var a = new long[] {0, 2, 4, 6, 8};
            Assert.Equal(3, a.LowerBound(5));
            Assert.Equal(3, a.UpperBound(5));
        }

        [Fact]
        void OutOfLeft()
        {
            var a = new long[] {6, 7, 8, 9, 10};
            Assert.Equal(0, a.LowerBound(5));
            Assert.Equal(0, a.UpperBound(5));
        }

        [Fact]
        void OutOfRight()
        {
            var a = new long[] {0, 1, 2, 3, 4};
            Assert.Equal(5, a.LowerBound(5));
            Assert.Equal(5, a.UpperBound(5));
        }

        [Fact]
        void Phi()
        {
            var a = new long[0];
            Assert.Equal(0, a.LowerBound(5));
            Assert.Equal(0, a.UpperBound(5));
        }

        [Fact]
        void Single()
        {
            var a = new long[] {5};
            Assert.Equal(0, a.LowerBound(5));
            Assert.Equal(1, a.UpperBound(5));
        }

        [Fact]
        void Double()
        {
            var a = new long[] {0, 10};
            Assert.Equal(1, a.LowerBound(5));
            Assert.Equal(1, a.UpperBound(5));
        }

        [Fact]
        void AllSame()
        {
            var a = new long[] {5, 5, 5, 5, 5};
            Assert.Equal(0, a.LowerBound(5));
            Assert.Equal(5, a.UpperBound(5));
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

            Assert.Equal(0, new[] {0, 1, 2, 3, 4}.Range(3, 1));
        }

        [Fact]
        void StringSearch()
        {
            var a = new[] {"a", "bb", "ccc", "e", "ff"};
            Assert.Equal(2, a.LowerBound("ccc"));
            Assert.Equal(3, a.UpperBound("ccc"));
            Assert.Equal(3, a.LowerBound("ddd"));
            Assert.Equal(3, a.UpperBound("ddd"));
        }

        [Fact]
        void FuncSearch()
        {
            Func<long, long> func = x => x * x;
            Assert.Equal(5, BinarySearch.LowerBound(func, 25, 0, 20));
            Assert.Equal(6, BinarySearch.UpperBound(func, 25, 0, 20));
        }
    }
}