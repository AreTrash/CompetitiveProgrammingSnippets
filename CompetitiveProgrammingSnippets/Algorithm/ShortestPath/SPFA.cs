using System;
using System.Collections.Generic;

namespace Algorithm.ShortestPath
{
    using __long__ = Int64;

    //$spfa
    //@SPFA O(VE) 負の辺が存在 bfより速い
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
                if (pushCounts[n] >= v) return false;
                if (isIns[n]) return true;

                pushCounts[n]++;
                isIns[n] = true;
                que.Enqueue(n);
                return true;
            }

            public int Dequeue()
            {
                var ret = que.Dequeue();
                isIns[ret] = false;
                return ret;
            }
        }

        public SPFA(int v) : base(v) { }

        public override __long__[] GetDistances(int start)
        {
            var dist = GetInitializedDistances(start);
            var que = new SPFAQueue(V);
            que.Enqueue(start);

            while (que.Count > 0)
            {
                var from = que.Dequeue();
                foreach (var edge in Edges[from])
                {
                    if (dist[from] == Infinity || dist[edge.To] <= dist[from] + edge.Cost) continue;
                    dist[edge.To] = dist[from] + edge.Cost;
                    if (!que.Enqueue(edge.To)) return NegativeCycle;
                }
            }

            return dist;
        }
    }
    //$spfa
}