using System;
using System.IO;
using Xunit;
using __PROJECT__;

namespace Basic
{
    public class MainTest
    {
        [Fact]
        void StreamScannerTest()
        {
            var ss = new StreamScanner(new StringReader(@"
apple  364
114514
        
8.10"
            ));

            Assert.Equal("apple", ss.Next(s => s));
            Assert.Equal(364, ss.Next(int.Parse));
            Assert.Equal(114514L, ss.Next(long.Parse));
            Assert.Equal(8.10, ss.Next(double.Parse));
            Assert.Throws<NullReferenceException>(() => ss.Next(float.Parse));
        }
    }
}