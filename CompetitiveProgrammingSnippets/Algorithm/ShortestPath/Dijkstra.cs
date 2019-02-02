using System;
using Algorithm.BasicDataStructure;

namespace Algorithm.ShortestPath
{
    using __long__ = Int64;

    //参考: プログラミングコンテストチャレンジブック（蟻本）P.97
    //$dijk
    //@Dijkstra O((V+E)LogV) 頂点の数が多く、辺の数が割と少ないとき dependency: pq
    public class Dijkstra : SP
    {
        struct Node : IComparable<Node>
        {
            public int Id;
            public __long__ Cost;

            public int CompareTo(Node other)
            {
                return Math.Sign(Cost - other.Cost);
            }
        }

        public Dijkstra(int v) : base(v) { }

        protected override __long__[] GetDistancesCore(int start, __long__[] dist)
        {
            var pq = new PriorityQueue<Node>();
            pq.Enqueue(new Node {Id = start, Cost = 0});

            while (pq.Count > 0)
            {
                var node = pq.Dequeue();
                var from = node.Id;

                foreach (var edge in Edges[from])
                {
                    var to = edge.To;
                    var cost = node.Cost + edge.Cost;

                    if (dist[to] <= cost) continue;
                    dist[to] = cost;
                    pq.Enqueue(new Node {Id = to, Cost = cost});
                }
            }

            return dist;
        }
    }
    //$dijk
}
