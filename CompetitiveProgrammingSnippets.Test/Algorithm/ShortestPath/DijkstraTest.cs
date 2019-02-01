using System.Collections.Generic;
using Xunit;

namespace Algorithm.ShortestPath
{
    public class DijkstraTest
    {
        //Test Case
        //AOJ ALDS1_12_B Graph II - Single Source Shortest Path I
        //http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ALDS1_12_B&lang=jp

        readonly int v = 5;

        readonly IEnumerable<(int from, int to, int cost)> edges = new[]
        {
            (0, 2, 3), (0, 3, 1), (0, 1, 2),
            (1, 0, 2), (1, 3, 4),
            (2, 0, 3), (2, 3, 1), (2, 4, 1),
            (3, 2, 1), (3, 0, 1), (3, 1, 4), (3, 4, 3),
            (4, 2, 1), (4, 3, 3),
        };

        [Fact]
        void Dijkstra()
        {
            var dijkstra = new Dijkstra(v);

            foreach (var (from, to, cost) in edges)
            {
                dijkstra.AddEdge(from, to, cost);
            }

            Assert.Equal(new long[] {0, 2, 2, 1, 3}, dijkstra.GetDistances(0));
        }

        [Fact]
        void DijkstraUsedMatrix()
        {
            var dijkstra = new DijkstraByMatrix(v);

            foreach (var (from, to, cost) in edges)
            {
                dijkstra.AddEdge(from, to, cost);
            }

            Assert.Equal(new long[] { 0, 2, 2, 1, 3 }, dijkstra.GetDistances(0));
        }
    }
}
