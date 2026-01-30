using System;

public class Solution
{
    private Dictionary<string, List<(int cost, string target)>> adj;
    private Dictionary<(string, string), long> dijkstraCache;
    private long[] dpCache;
    private int[] lengths;
    private const long INF = long.MaxValue / 2;

    public long MinimumCost(string source, string target, string[] original, string[] changed, int[] cost)
    {
        int n = source.Length;
        adj = new Dictionary<string, List<(int, string)>>();
        dijkstraCache = new Dictionary<(string, string), long>();
        dpCache = new long[n + 1];
        Array.Fill(dpCache, -1);

        // Build Adjacency List
        for (int i = 0; i < original.Length; i++)
        {
            if (!adj.ContainsKey(original[i])) adj[original[i]] = new List<(int, string)>();
            adj[original[i]].Add((cost[i], changed[i]));
        }

        // Get unique lengths of transformable substrings
        lengths = original.Select(s => s.Length).Distinct().OrderBy(l => l).ToArray();

        long result = SolveDP(0, source, target);
        return result >= INF ? -1 : result;
    }

    private long Dijkstra(string start, string end)
    {
        if (start == end)
            return 0;
        if (dijkstraCache.ContainsKey((start, end)))
            return dijkstraCache[(start, end)];

        var dists = new Dictionary<string, long>();
        var pq = new PriorityQueue<(long cost, string node), long>();

        dists[start] = 0;
        pq.Enqueue((0, start), 0);
        while (pq.Count > 0)
        {
            var (d, u) = pq.Dequeue();

            if (d > dists.GetValueOrDefault(u, INF)) continue;
            if (u == end) break;

            if (adj.ContainsKey(u))
            {
                foreach (var (c, v) in adj[u])
                {
                    long newDist = d + c;
                    if (newDist < dists.GetValueOrDefault(v, INF))
                    {
                        dists[v] = newDist;
                        pq.Enqueue((newDist, v), newDist);
                    }
                }
            }
        }

        long finalCost = dists.GetValueOrDefault(end, INF);
        dijkstraCache[(start, end)] = finalCost;
        return finalCost;
    }

    private long SolveDP(int i, string source, string target)
    {
        if (i == source.Length)
            return 0;
        if (dpCache[i] != -1)
            return dpCache[i];

        long best = INF;

        //Charaters match, move to next one
        if (source[i] == target[i])
        {
            best = SolveDP(i + 1, source, target);
        }

        //Change substring from source to target
        foreach (int len in lengths)
        {
            if (i + len > source.Length)
                break;

            string srcSub = source.Substring(i, len);
            string tarSub = target.Substring(i, len);

            if (adj.ContainsKey(srcSub))
            {
                long cost = Dijkstra(srcSub, tarSub);
                if (cost < INF)
                {
                    best = Math.Min(best, cost + SolveDP(i + len, source, target));
                }
            }
        }

        return dpCache[i] = best;
    }
}
