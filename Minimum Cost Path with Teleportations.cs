using System.Text;

class Solution
{
    public static void Main(string[] args)
    {
        int[][] grid = [[0, 1, 3], [3, 1, 1], [2, 3, 4], [0, 2, 2]];
        int n = 4;

        Console.WriteLine(MinCost(grid, n));
    }

    public static int MinCost(int[][] grid, int k)
    {
        int m = grid.Length;
        int n = grid[0].Length;

        // Flatten the grid into a list of points (row, col)
        var points = new List<(int r, int c)>();
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                points.Add((i, j));
            }
        }

        // Sort points based on the value in the grid
        points = points.OrderBy(p => grid[p.r][p.c]).ToList();

        // Initialize costs with a large value (equivalent to float("inf"))
        int[][] costs = new int[m][];
        for (int i = 0; i < m; i++)
        {
            costs[i] = new int[n];
            Array.Fill(costs[i], int.MaxValue / 2); // Avoid overflow during additions
        }

        for (int t = 0; t <= k; t++)
        {
            int minCostVal = int.MaxValue / 2;
            int j = 0;

            for (int i = 0; i < points.Count; i++)
            {
                minCostVal = Math.Min(minCostVal, costs[points[i].r][points[i].c]);

                // Check if the next point has the same grid value
                if (i + 1 < points.Count && grid[points[i].r][points[i].c] == grid[points[i + 1].r][points[i + 1].c])
                {
                    continue;
                }

                // Update costs for the current group of identical grid values
                for (int r = j; r <= i; r++)
                {
                    costs[points[r].r][points[r].c] = minCostVal;
                }

                j = i + 1;
                // Reset minCostVal for the next group of values if needed
                // Note: The Python code doesn't reset it inside this loop, 
                // carrying the minimum forward.
            }

            // Standard DP traversal from bottom-right to top-left
            for (int i = m - 1; i >= 0; i--)
            {
                for (int l = n - 1; l >= 0; l--)
                {
                    if (i == m - 1 && l == n - 1)
                    {
                        costs[i][l] = 0;
                        continue;
                    }

                    if (i + 1 < m)
                    {
                        costs[i][l] = Math.Min(costs[i][l], costs[i + 1][l] + grid[i + 1][l]);
                    }

                    if (l + 1 < n)
                    {
                        costs[i][l] = Math.Min(costs[i][l], costs[i][l + 1] + grid[i][l + 1]);
                    }
                }
            }
        }

        return costs[0][0];
    }
}