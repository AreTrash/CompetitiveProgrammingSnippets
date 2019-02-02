using System;
using System.Collections.Generic;

namespace Algorithm.ShortestPath
{
    using __long__ = Int64;

    //$spfa
    //@SPFA O(VE) bfより速い
    public class SPFA : SP
    {
        class SPFAQueue
        {
            readonly int v;
            readonly Queue<int> que;
            readonly bool[] isIns;
            readonly int[] pushCounts;

            public int Count { get { return que.Count; } }

            public SPFAQueue(int v)
            {
                this.v = v;
                que = new Queue<int>();
                isIns = new bool[v];
                pushCounts = new int[v];
            }

            public bool Enqueue(int n)
            {
                if (isIns[n]) return true;
                isIns[n] = true;
                que.Enqueue(n);
                return (++pushCounts[n]) < v;
            }

            public int Dequeue()
            {
                var ret = que.Dequeue();
                isIns[ret] = false;
                return ret;
            }
        }

        public SPFA(int v) : base(v) { }

        protected override __long__[] GetDistancesCore(int start, __long__[] dist)
        {
            var que = new SPFAQueue(V);
            que.Enqueue(start);

            while (que.Count > 0)
            {
                var from = que.Dequeue();
                foreach (var edge in Edges[from])
                {
                    if (dist[from] == Infinity || dist[edge.To] <= dist[from] + edge.Cost) continue;
                    dist[edge.To] = dist[from] + edge.Cost;

                    if (que.Enqueue(edge.To)) continue;
                    return NegativeCycle;
                }
            }

            return dist;
        }
    }
    //$spfa
}