using Xunit;

namespace Algorithm.ShortestPath
{
    public class DijkstraTest
    {
        [Fact]
        void Basic()
        {
            //Test Case
            //AOJ ALDS1_12_B Graph II - Single Source Shortest Path I
            //http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ALDS1_12_B&lang=jp

            var v = 5;
            var s = 0;
            var edges = new (int from, int to, int cost)[]
            {
                (0, 2, 3), (0, 3, 1), (0, 1, 2),
                (1, 0, 2), (1, 3, 4),
                (2, 0, 3), (2, 3, 1), (2, 4, 1),
                (3, 2, 1), (3, 0, 1), (3, 1, 4), (3, 4, 3),
                (4, 2, 1), (4, 3, 3),
            };

            {
                var sp = new Dijkstra(v);
                foreach (var (from, to, cost) in edges) sp.AddEdge(from, to, cost);
                Assert.Equal(new long[] {0, 2, 2, 1, 3}, sp.GetDistances(s));
            }
            {
                var sp = new DijkstraVV(v);
                foreach (var (from, to, cost) in edges) sp.AddEdge(from, to, cost);
                Assert.Equal(new long[] {0, 2, 2, 1, 3}, sp.GetDistances(s));
            }
            {
                var sp = new BellmanFord(v);
                foreach (var (from, to, cost) in edges) sp.AddEdge(from, to, cost);
                Assert.Equal(new long[] {0, 2, 2, 1, 3}, sp.GetDistances(s));
            }
            {
                var sp = new SPFA(v);
                foreach (var (from, to, cost) in edges) sp.AddEdge(from, to, cost);
                Assert.Equal(new long[] {0, 2, 2, 1, 3}, sp.GetDistances(s));
            }
        }

        [Fact]
        void ExistInfinityDistance()
        {
            //Test Case
            //AOJ GRL_1_A Shortest Path -Single Source Shortest Path
            //http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ALDS1_12_B&lang=jp

            var v = 4;
            var s = 1;
            var edges = new (int from, int to, int cost)[]
            {
                (0, 1, 1), (0, 2, 4),
                (1, 2, 2),
                (2, 0, 1),
                (3, 1, 1), (3, 2, 5),
            };

            {
                var sp = new Dijkstra(v);
                foreach (var (from, to, cost) in edges) sp.AddEdge(from, to, cost);
                Assert.Equal(new long[] {3, 0, 2, SP.Infinity}, sp.GetDistances(s));
            }
            {
                var sp = new DijkstraVV(v);
                foreach (var (from, to, cost) in edges) sp.AddEdge(from, to, cost);
                Assert.Equal(new long[] {3, 0, 2, SP.Infinity}, sp.GetDistances(s));
            }
            {
                var sp = new BellmanFord(v);
                foreach (var (from, to, cost) in edges) sp.AddEdge(from, to, cost);
                Assert.Equal(new long[] {3, 0, 2, SP.Infinity}, sp.GetDistances(s));
            }
            {
                var sp = new SPFA(v);
                foreach (var (from, to, cost) in edges) sp.AddEdge(from, to, cost);
                Assert.Equal(new long[] {3, 0, 2, SP.Infinity}, sp.GetDistances(s));
            }
        }

        [Fact]
        void ExistNegativeEdges()
        {
            //Test Case
            //AOJ GRL_1_B Shortest Path - Single Source Shortest Path (Negative Edges)
            //http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=GRL_1_B&lang=jp

            var v = 4;
            var s = 0;
            var edges = new (int from, int to, int cost)[]
            {
                (0, 1, 2), (0, 2, 3),
                (1, 2, -5), (1, 3, 1),
                (2, 3, 2),
            };

            {
                var sp = new BellmanFord(v);
                foreach (var (from, to, cost) in edges) sp.AddEdge(from, to, cost);
                Assert.Equal(new long[] {0, 2, -3, -1}, sp.GetDistances(s));
            }
            {
                var sp = new SPFA(v);
                foreach (var (from, to, cost) in edges) sp.AddEdge(from, to, cost);
                Assert.Equal(new long[] {0, 2, -3, -1}, sp.GetDistances(s));
            }
        }

        [Fact]
        void ExistNegativeCycle()
        {
            //Test Case
            //AOJ GRL_1_B Shortest Path - Single Source Shortest Path (Negative Edges)
            //http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=GRL_1_B&lang=jp

            var v = 4;
            var s = 0;
            var edges = new (int from, int to, int cost)[]
            {
                (0, 1, 2), (0, 2, 3),
                (1, 2, -5), (1, 3, 1),
                (2, 3, 2),
                (3, 1, 0),
            };

            {
                var sp = new BellmanFord(v);
                foreach (var (from, to, cost) in edges) sp.AddEdge(from, to, cost);
                Assert.Equal(SP.NegativeCycle, sp.GetDistances(s));
            }
            {
                var sp = new SPFA(v);
                foreach (var (from, to, cost) in edges) sp.AddEdge(from, to, cost);
                Assert.Equal(SP.NegativeCycle, sp.GetDistances(s));
            }
        }
    }
}