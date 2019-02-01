using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm.ShortestPath
{
    using __long__ = Int64;

    //参考: プログラミングコンテストチャレンジブック（蟻本）P.96
    //$dijkmat
    //@DijkstraByMatrix O(V^2) 辺の数がものすごく多く、頂点数が割と少ないとき
    public class DijkstraByMatrix
    {
        public static readonly __long__ Infinity = __long__.MaxValue;
        readonly __long__[,] costMatrix;

        public DijkstraByMatrix(int v)
        {
            costMatrix = new __long__[v, v];

            for (var i = 0; i < v; i++)
            for (var j = 0; j < v; j++)
            {
                costMatrix[i, j] = Infinity;
            }
        }

        public void AddEdge(int from, int to, __long__ cost)
        {
            costMatrix[from, to] = cost;
        }

        public void AddUndirectedEdge(int v1, int v2, __long__ cost)
        {
            AddEdge(v1, v2, cost);
            AddEdge(v2, v1, cost);
        }

        public __long__[] GetDistances(int start)
        {
            var v = costMatrix.GetLength(0);
            var willUse = new HashSet<int>(Enumerable.Range(0, v));
            var dist = new __long__[v];

            for (var i = 0; i < v; i++) dist[i] = Infinity;
            dist[start] = 0;

            while (willUse.Count > 0)
            {
                var min = willUse.Min(wu => dist[wu]);
                var from = willUse.First(wu => dist[wu] == min);
                willUse.Remove(from);

                for (var to = 0; to < v; to++)
                {
                    if (costMatrix[from, to] == Infinity) continue;
                    dist[to] = Math.Min(dist[to], dist[from] + costMatrix[from, to]);
                }
            }

            return dist;
        }
    }
    //$dijkmat
}
