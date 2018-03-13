using System;
using System.Collections.Generic;
using Algorithm.BasicDataStructure;

namespace Algorithm.ShortestPath
{
    using __int__ = Int32;

    //参考: プログラミングコンテストチャレンジブック（蟻本）P.97
    //$dijk
    //@Dijkstra O((V+E)LogV)
    public class Dijkstra
    {
        public struct Edge
        {
            public int To;
            public __int__ Cost;
        }

        public struct Node : IComparable<Node>
        {
            public int Id;
            public __int__ Cost;

            public int CompareTo(Node other)
            {
                return Math.Sign(this.Cost - other.Cost);
            }
        }

        readonly List<Edge>[] adjacencyList;

        public Dijkstra(int v)
        {
            adjacencyList = new List<Edge>[v];
            for (var i = 0; i < v; i++) adjacencyList[i] = new List<Edge>();
        }

        public void AddDirectedEdge(int from, int to, __int__ cost)
        {
            adjacencyList[from].Add(new Edge { To = to, Cost = cost });
        }

        public void AddUndirectedEdge(int v1, int v2, __int__ cost)
        {
            AddDirectedEdge(v1, v2, cost);
            AddDirectedEdge(v2, v1, cost);
        }

        public __int__[] GetDistances(int start)
        {
            var v = adjacencyList.Length;
            var dist = new __int__[v];

            for (var i = 0; i < v; i++) dist[i] = __int__.MaxValue;
            dist[start] = 0;

            var pq = new PriorityQueue<Node>();
            pq.Enqueue(new Node{Id = start, Cost = 0});

            while (pq.Count > 0)
            {
                var node = pq.Dequeue();
                var from = node.Id;

                foreach (var edge in adjacencyList[from])
                {
                    var to = edge.To;
                    var cost = node.Cost + edge.Cost;

                    if (dist[to] <= cost) continue;
                    dist[to] = cost;
                    pq.Enqueue(new Node{Id = to, Cost = cost});
                }
            }

            return dist;
        }
    }
    //$dijk
}
