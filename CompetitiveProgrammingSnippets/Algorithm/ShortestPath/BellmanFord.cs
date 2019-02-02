using System;
using System.Linq;

namespace Algorithm.ShortestPath
{
    using __long__ = Int64;

    //参考: プログラミングコンテストチャレンジブック（蟻本）P.95
    //$bf
    //@BellmanFord O(VE) 負の辺が存在するときに使う
    public class BellmanFord : SP
    {
        public BellmanFord(int v) : base(v) { }

        protected override __long__[] GetDistancesCore(int start, __long__[] dist)
        {
            for (var i = 0; i < V; i++)
            {
                var updated = false;
                var edges = Edges.SelectMany((es, f) => es.Select(e => new {From = f, e.To, e.Cost}));
                foreach (var edge in edges)
                {
                    if (dist[edge.From] == Infinity || dist[edge.To] <= dist[edge.From] + edge.Cost) continue;
                    dist[edge.To] = dist[edge.From] + edge.Cost;
                    updated = true;
                }
                if (!updated) return dist;
            }

            return NegativeCycle;
        }
    }
    //$bf
}