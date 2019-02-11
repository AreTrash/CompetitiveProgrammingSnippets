using System;
using System.Linq;

namespace Algorithm.ShortestPath
{
    using __long__ = Int64;

    //$bf
    //@BellmanFord O(VE) 負の辺が存在 SPFAでよい
    //ref: プログラミングコンテストチャレンジブック（蟻本）P.95
    public class BellmanFord : SP
    {
        public BellmanFord(int v) : base(v) { }

        public override __long__[] GetDistances(int start)
        {
            var dist = GetInitializedDistances(start);
            var edges = Edges.SelectMany((es, f) => es.Select(e => new { From = f, e.To, e.Cost }));

            for (var i = 0; i < V; i++)
            {
                var updated = false;
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