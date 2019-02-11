using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm.ShortestPath
{
    using __long__ = Int64;

    //$dijkvv
    //@DijkstraVV O(V^2) 辺の数がものすごく多く、頂点数が割と少ないとき
    //ref: プログラミングコンテストチャレンジブック（蟻本）P.96
    public class DijkstraVV : ShortestPath
    {
        public DijkstraVV(int v) : base(v) { }

        public override __long__[] GetDistances(int start)
        {
            var dist = GetInitializedDistances(start);
            var vSet = new HashSet<int>(Enumerable.Range(0, V));

            while (vSet.Count > 0)
            {
                var min = vSet.Min(x => dist[x]);
                var from = vSet.First(x => dist[x] == min);
                vSet.Remove(from);
                if (dist[from] == Infinity) break;

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
