using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm.ShortestPath
{
    //参考: プログラミングコンテストチャレンジブック（蟻本）P.96
    //$dijkmat
    //@DijkstraByMatrix O(V^2) 辺の数がものすごく多く、頂点数が割と少ないとき
    public class DijkstraByMatrix
    {
        readonly long[,] costMatrix;

        public DijkstraByMatrix(int v)
        {
            costMatrix = new long[v, v];

            for (var i = 0; i < v; i++)
            for (var j = 0; j < v; j++)
            {
                costMatrix[i, j] = long.MaxValue;
            }
        }

        public void AddEdge(int from, int to, long cost)
        {
            costMatrix[from, to] = cost;
        }

        public void AddUndirectedEdge(int v1, int v2, long cost)
        {
            AddEdge(v1, v2, cost);
            AddEdge(v2, v1, cost);
        }

        public long[] GetDistances(int start)
        {
            var v = costMatrix.GetLength(0);
            var willUse = new HashSet<int>(Enumerable.Range(0, v));
            var dist = new long[v];

            for (var i = 0; i < v; i++) dist[i] = long.MaxValue;
            dist[start] = 0;

            while (willUse.Count > 0)
            {
                var min = willUse.Min(wu => dist[wu]);
                var from = willUse.First(wu => dist[wu] == min);
                willUse.Remove(from);

                for (var to = 0; to < v; to++)
                {
                    if (costMatrix[from, to] == long.MaxValue) continue;
                    dist[to] = Math.Min(dist[to], dist[from] + costMatrix[from, to]);
                }
            }

            return dist;
        }
    }
    //$dijkmat
}
