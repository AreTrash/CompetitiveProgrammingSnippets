using System;
using System.Collections.Generic;

namespace Algorithm.ShortestPath
{
    using __long__ = Int64;

    //$sp
    public abstract class SP
    {
        public static readonly __long__ Infinity = __long__.MaxValue;
        public static readonly __long__[] NegativeCycle = null;

        protected struct Edge
        {
            public int To;
            public __long__ Cost;
        }

        protected int V { get; }
        protected List<Edge>[] Edges { get; }

        protected SP(int v)
        {
            V = v;
            Edges = new List<Edge>[v];
            for (var i = 0; i < v; i++) Edges[i] = new List<Edge>();
        }

        public void AddEdge(int from, int to, __long__ cost)
        {
            Edges[from].Add(new Edge { To = to, Cost = cost });
        }

        public void AddUndirectedEdge(int v1, int v2, __long__ cost)
        {
            AddEdge(v1, v2, cost);
            AddEdge(v2, v1, cost);
        }

        public abstract __long__[] GetDistances(int start);

        protected __long__[] GetInitializedDistances(int start)
        {
            var dist = new __long__[V];
            for (var i = 0; i < V; i++) dist[i] = Infinity;
            dist[start] = 0;
            return dist;
        }
    }
    //$sp
}