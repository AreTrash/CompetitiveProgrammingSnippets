using System;
using System.Collections.Generic;
using Algorithm.BasicDataStructure;

namespace Algorithm.ShortestPath
{
    //参考: プログラミングコンテストチャレンジブック（蟻本）P.97
    //$dijk
    //@Dijkstra O((V+E)LogV) 頂点の数が多く、辺の数が割と少ないとき dependency: pq
    public class Dijkstra
    {
        public struct Edge
        {
            public int To;
            public long Cost;
        }

        public struct Node : IComparable<Node>
        {
            public int Id;
            public long Cost;

            public int CompareTo(Node other)
            {
                return Math.Sign(this.Cost - other.Cost);
            }
        }

        readonly List<Edge>[] edges;

        public Dijkstra(int v)
        {
            edges = new List<Edge>[v];
            for (var i = 0; i < v; i++) edges[i] = new List<Edge>();
        }

        public void AddEdge(int from, int to, long cost)
        {
            edges[from].Add(new Edge {To = to, Cost = cost});
        }

        public void AddUndirectedEdge(int v1, int v2, long cost)
        {
            AddEdge(v1, v2, cost);
            AddEdge(v2, v1, cost);
        }

        public long[] GetDistances(int start)
        {
            var v = edges.Length;
            var dist = new long[v];

            for (var i = 0; i < v; i++) dist[i] = long.MaxValue;
            dist[start] = 0;

            var pq = new PriorityQueue<Node>();
            pq.Enqueue(new Node {Id = start, Cost = 0});

            while (pq.Count > 0)
            {
                var node = pq.Dequeue();
                var from = node.Id;

                foreach (var edge in edges[from])
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