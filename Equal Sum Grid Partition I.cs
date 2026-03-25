public class Solution
{
    public bool CanPartitionGrid(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;

        long[] horizontal = new long[m];
        long[] vertical = new long[n];

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                horizontal[i] += grid[i][j];
                vertical[j] += grid[i][j];
            }
        }

        for (int i = 1; i < m; i++)
        {
            horizontal[i] += horizontal[i - 1];
        }

        for (int i = 1; i < n; i++)
        {
            vertical[i] += vertical[i - 1];
        }

        for (int i = 0; i < m - 1; i++)
        {
            if (horizontal[i] * 2 == horizontal[m - 1])
                return true;
        }

        for (int i = 0; i < n - 1; i++)
        {
            if (vertical[i] * 2 == vertical[n - 1])
                return true;
        }

        return false;
    }
}