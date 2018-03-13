using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm.ShortestPath
{
    using __int__ = Int32;

    //参考: プログラミングコンテストチャレンジブック（蟻本）P.96
    //辺の数がものすごく多く、頂点数が割と少ないときに有効
    //$dijkmat
    //@DijkstraUsedMatrix O(V^2)
    public class DijkstraUsedMatrix
    {
        readonly __int__[,] costMatrix;

        public DijkstraUsedMatrix(int v)
        {
            costMatrix = new __int__[v, v];

            for (var i = 0; i < v; i++)
            {
                for (var j = 0; j < v; j++)
                {
                    costMatrix[i, j] = __int__.MaxValue;
                }
            }
        }

        public void AddDirectedEdge(int from, int to, __int__ cost)
        {
            costMatrix[from, to] = cost;
        }

        public void AddUndirectedEdge(int v1, int v2, __int__ cost)
        {
            AddDirectedEdge(v1, v2, cost);
            AddDirectedEdge(v2, v1, cost);
        }

        public __int__[] GetDistances(int start)
        {
            var v = costMatrix.GetLength(0);
            var willUse = new HashSet<int>(Enumerable.Range(0, v));
            var dist = new __int__[v];

            for (var i = 0; i < v; i++) dist[i] = __int__.MaxValue;
            dist[start] = 0;

            while (willUse.Count > 0)
            {
                var min = willUse.Min(wu => dist[wu]);
                var from = willUse.First(wu => dist[wu] == min);
                willUse.Remove(from);

                for (var to = 0; to < v; to++)
                {
                    if (costMatrix[from, to] == __int__.MaxValue) continue;
                    dist[to] = Math.Min(dist[to], dist[from] + costMatrix[from, to]);
                }
            }

            return dist;
        }
    }
    //$dijkmat
}
