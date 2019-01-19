using System;
using Xunit;

namespace Algorithm.MathX
{
    public class BinarySearchTest
    {
        [Fact]
        void Exist()
        {
            var asc = new[] {1, 5, 6, 7, 9};
            Assert.Equal(1, asc.LowerBound(5));
            Assert.Equal(2, asc.UpperBound(5));

            var desc = new[] {9, 7, 6, 5, 1};
            Assert.Equal(3, desc.LowerBound(5));
            Assert.Equal(4, desc.UpperBound(5));
        }

        [Fact]
        void ExistMultiple()
        {
            var asc = new[] {1, 5, 5, 5, 9};
            Assert.Equal(1, asc.LowerBound(5));
            Assert.Equal(4, asc.UpperBound(5));

            var desc = new[] {9, 5, 5, 5, 1};
            Assert.Equal(1, desc.LowerBound(5));
            Assert.Equal(4, desc.UpperBound(5));
        }

        [Fact]
        void ExistFirst()
        {
            var asc = new[] {5, 6, 7, 8, 9};
            Assert.Equal(0, asc.LowerBound(5));
            Assert.Equal(1, asc.UpperBound(5));

            var desc = new[] {5, 4, 3, 2, 1};
            Assert.Equal(0, desc.LowerBound(5));
            Assert.Equal(1, desc.UpperBound(5));
        }

        [Fact]
        void ExistLast()
        {
            var asc = new[] {1, 2, 3, 4, 5};
            Assert.Equal(4, asc.LowerBound(5));
            Assert.Equal(5, asc.UpperBound(5));

            var desc = new[] {9, 8, 7, 6, 5};
            Assert.Equal(4, desc.LowerBound(5));
            Assert.Equal(5, desc.UpperBound(5));
        }

        [Fact]
        void InsideButNotExist()
        {
            var asc = new[] {0, 2, 4, 6, 8};
            Assert.Equal(3, asc.LowerBound(5));
            Assert.Equal(3, asc.UpperBound(5));

            var desc = new[] {8, 6, 4, 2, 0};
            Assert.Equal(2, desc.LowerBound(5));
            Assert.Equal(2, desc.UpperBound(5));
        }

        [Fact]
        void OutOfLeft()
        {
            var asc = new[] {6, 7, 8, 9, 10};
            Assert.Equal(0, asc.LowerBound(5));
            Assert.Equal(0, asc.UpperBound(5));

            var desc = new[] {4, 3, 2, 1, 0};
            Assert.Equal(0, desc.LowerBound(5));
            Assert.Equal(0, desc.UpperBound(5));
        }

        [Fact]
        void OutOfRight()
        {
            var asc = new[] {0, 1, 2, 3, 4};
            Assert.Equal(5, asc.LowerBound(5));
            Assert.Equal(5, asc.UpperBound(5));

            var desc = new[] {10, 9, 8, 7, 6};
            Assert.Equal(5, desc.LowerBound(5));
            Assert.Equal(5, desc.UpperBound(5));
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
            var a = new[] {5};
            Assert.Equal(0, a.LowerBound(4));
            Assert.Equal(0, a.UpperBound(4));
            Assert.Equal(0, a.LowerBound(5));
            Assert.Equal(1, a.UpperBound(5));
            Assert.Equal(1, a.LowerBound(6));
            Assert.Equal(1, a.UpperBound(6));
        }

        [Fact]
        void Double()
        {
            var asc = new[] {0, 10};
            Assert.Equal(1, asc.LowerBound(5));
            Assert.Equal(1, asc.UpperBound(5));

            var desc = new[] {10, 0};
            Assert.Equal(1, desc.LowerBound(5));
            Assert.Equal(1, desc.UpperBound(5));
        }

        [Fact]
        void AllSame()
        {
            var a = new[] {5, 5, 5, 5, 5};
            Assert.Equal(0, a.LowerBound(4));
            Assert.Equal(0, a.UpperBound(4));
            Assert.Equal(0, a.LowerBound(5));
            Assert.Equal(5, a.UpperBound(5));
            Assert.Equal(5, a.LowerBound(6));
            Assert.Equal(5, a.UpperBound(6));
        }

        [Fact]
        void Range()
        {
            Assert.Equal(3, new[] {0, 1, 2, 3, 4}.Range(1, 3));
            Assert.Equal(4, new[] {0, 1, 1, 1, 3, 4}.Range(1, 3));
            Assert.Equal(4, new[] {0, 1, 1, 3, 3, 4}.Range(1, 3));
            Assert.Equal(4, new[] {0, 1, 3, 3, 3, 4}.Range(1, 3));
            Assert.Equal(2, new[] {0, 1, 3}.Range(1, 3));
            Assert.Equal(2, new[] {1, 3, 4}.Range(1, 3));
            Assert.Equal(4, new[] {0, 2, 2, 2, 3}.Range(1, 3));
            Assert.Equal(4, new[] {1, 2, 2, 2, 4}.Range(1, 3));
            Assert.Equal(3, new[] {2, 2, 2}.Range(1, 3));
            Assert.Equal(1, new[] {0, 1}.Range(1, 3));
            Assert.Equal(1, new[] {3, 4}.Range(1, 3));
            Assert.Equal(0, new[] {0}.Range(1, 3));
            Assert.Equal(1, new[] {1}.Range(1, 3));
            Assert.Equal(1, new[] {2}.Range(1, 3));
            Assert.Equal(1, new[] {3}.Range(1, 3));
            Assert.Equal(0, new[] {4}.Range(1, 3));

            Assert.Equal(3, new[] {0, 1, 2, 3, 4}.Range(1, 3));
            Assert.Equal(0, new[] {0, 1, 2, 3, 4}.Range(3, 1));
            Assert.Equal(0, new[] {4, 3, 2, 1, 0}.Range(1, 3));
            Assert.Equal(3, new[] {4, 3, 2, 1, 0}.Range(3, 1));
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