using System.Text;

class Solution
{
    public static void Main(string[] args)
    {
        int[][] edges = [[0, 1, 3], [3, 1, 1], [2, 3, 4], [0, 2, 2]];
        int n = 4;

        Console.WriteLine(MinCost(n, edges));
    }

    public static int MinCost(int n, int[][] edges)
    {
        //Initialize node list
        List<(int neighbor, int weight)>[] node = new List<(int, int)>[n];
        for (int i = 0; i < n; i++)
        {
            node[i] = new List<(int, int)>();
        }

        //Build graph
        foreach (int[] edge in edges)
        {
            //Forward
            node[edge[0]].Add((edge[1], edge[2]));

            //Reverse
            node[edge[1]].Add((edge[0], edge[2] * 2));
        }

        //Setup distance array
        long[] dist = new long[n];
        Array.Fill(dist, long.MaxValue);
        dist[0] = 0;

        //Setup priority queue (heap)
        PriorityQueue<int, long> pq = new PriorityQueue<int, long>();
        pq.Enqueue(0, 0);

        while (pq.Count > 0)
        {
            //Get shortest distance
            pq.TryDequeue(out int u, out long d);

            //Return if reached to n-1 node
            if (u == n - 1)
                return (int)d;

            //Check distance
            if (d > dist[u]) continue;

            //Check neighbor distance
            foreach (var (v, w) in node[u])
            {
                if (dist[u] + w < dist[v])
                {
                    dist[v] = dist[u] + w;
                    pq.Enqueue(v, dist[v]);
                }
            }
        }
        return -1;
    }
}