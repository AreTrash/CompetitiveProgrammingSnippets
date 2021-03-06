﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithm.BasicDataStructure
{
    //$pq
    //@PriorityQueue
    public class PriorityQueue<T> : IEnumerable<T> where T : IComparable<T>
    {
        public int Count { get { return list.Count; } }

        readonly List<T> list = new List<T>();

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        public void Clear()
        {
            list.Clear();
        }

        public bool Contains(T value)
        {
            return list.Contains(value);
        }

        public T Peek()
        {
            return list[0];
        }

        public void Enqueue(T value)
        {
            list.Add(value);
            PushHeap();
        }

        public T Dequeue()
        {
            var ret = list[0];
            list[0] = list[Count - 1];
            list.RemoveAt(Count - 1);
            PopHeap();
            return ret;
        }

        void PushHeap()
        {
            var i = Count - 1;
            while (i != 0)
            {
                var p = (i - 1) / 2;
                if (list[i].CompareTo(list[p]) > 0) return;

                SwapIndex(i, i = p);
            }
        }

        void PopHeap()
        {
            var i = 0;
            while (true)
            {
                var l = 2 * i + 1;
                var r = l + 1;

                var maxi = i;
                if (l < Count && list[maxi].CompareTo(list[l]) > 0) maxi = l;
                if (r < Count && list[maxi].CompareTo(list[r]) > 0) maxi = r;
                if (maxi == i) return;

                SwapIndex(i, i = maxi);
            }
        }

        void SwapIndex(int left, int right)
        {
            var tmp = list[left];
            list[left] = list[right];
            list[right] = tmp;
        }
    }
    //$pq
}