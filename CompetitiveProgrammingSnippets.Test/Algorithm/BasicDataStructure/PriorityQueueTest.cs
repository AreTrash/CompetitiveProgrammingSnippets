using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Algorithm.BasicDataStructure
{
    public class PriorityQueueTest
    {
        [Fact]
        void PriorityQueue()
        {
            var pq = new PriorityQueue<int>();

            pq.Enqueue(5);
            pq.Enqueue(1);
            pq.Enqueue(7);
            pq.Enqueue(3);

            Assert.Equal(4, pq.Count);
            Assert.Equal(1, pq.Peek());
            Assert.Equal(1, pq.Dequeue());
            Assert.Equal(3, pq.Dequeue());
            Assert.Equal(5, pq.Dequeue());
            Assert.Equal(7, pq.Dequeue());
        }
    }
}