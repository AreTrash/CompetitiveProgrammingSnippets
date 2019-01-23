namespace Algorithm.BasicDataStructure
{
    //$uf
    public class UnionFind
    {
        readonly int[] p;

        public UnionFind(int n)
        {
            p = new int[n];
            for (var i = 0; i < n; i++) p[i] = -1;
        }

        public int Root(int x)
        {
            return p[x] < 0 ? x : (p[x] = Root(p[x]));
        }

        public bool IsSameSet(int x, int y)
        {
            return Root(x) == Root(y);
        }

        public bool Unite(int x, int y)
        {
            x = Root(x);
            y = Root(y);
            if (x == y) return false;

            if (p[x] > p[y])
            {
                var t = x;
                x = y;
                y = t;
            }

            p[x] += p[y];
            p[y] = x;
            return true;
        }

        public int Size(int x)
        {
            return -p[Root(x)];
        }
    }
    //$uf
}