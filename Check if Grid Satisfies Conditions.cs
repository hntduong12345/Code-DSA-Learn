using System.Text;

class Solution
{
    public static void Main(string[] args)
    {
        int[][] grid = [[0, 1, 3], [3, 1, 1], [2, 3, 4], [0, 2, 2]];
        int n = 4;

        Console.WriteLine(SatisfiesConditions(grid));
    }

    public static bool SatisfiesConditions(int[][] grid)
    {
        int row = grid.Length, col = grid[0].Length;
        for (int i = 0; i < row - 1; i++)
        {
            for (int j = 0; j < col - 1; j++)
            {
                if (grid[i][j] != grid[i + 1][j] ||
                   grid[i][j] == grid[i][j + 1])
                    return false;
            }
        }

        for (int i = 0; i < row - 1; i++)
        {
            if (grid[i][col - 1] != grid[i + 1][col - 1])
                return false;
        }

        for (int i = 0; i < col - 1; i++)
        {
            if (grid[row - 1][i] == grid[row - 1][i + 1])
                return false;
        }

        return true;
    }
}