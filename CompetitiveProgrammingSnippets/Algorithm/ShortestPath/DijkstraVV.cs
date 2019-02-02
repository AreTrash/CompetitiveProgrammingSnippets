using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm.ShortestPath
{
    using __long__ = Int64;

    //参考: プログラミングコンテストチャレンジブック（蟻本）P.96
    //$dijkvv
    //@DijkstraByMatrix O(V^2) 辺の数がものすごく多く、頂点数が割と少ないとき
    public class DijkstraVV : SP
    {
        public DijkstraVV(int v) : base(v) { }

        protected override __long__[] GetDistancesCore(int start, __long__[] dist)
        {
            var willUse = new HashSet<int>(Enumerable.Range(0, V));

            while (willUse.Count > 0)
            {
                var min = willUse.Min(wu => dist[wu]);
                var from = willUse.First(wu => dist[wu] == min);
                willUse.Remove(from);
                if (dist[from] == Infinity) continue;

                foreach (var edge in Edges[from])
                {
                    dist[edge.To] = Math.Min(dist[edge.To], dist[from] + edge.Cost);
                }
            }

            return dist;
        }
    }
    //$dijkvv
}
