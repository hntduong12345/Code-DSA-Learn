class Solution
{
    private static void Main(string[] args)
    {
        int[][] grid = [[4, 3, 8, 4], [9, 5, 1, 9], [2, 7, 6, 2]];
        Console.Write(NumMagicSquaresInside(grid));
    }

    public static int NumMagicSquaresInside(int[][] grid)
    {
        //Bruce force
        int row = grid.Length;
        int col = grid[0].Length;
        int res = 0;
        for (int r = 0; r < row - 2; r++)
        {
            for (int c = 0; c < col - 2; c++)
            {
                res += CheckMatrix(grid, r, c);
            }
        }

        return res;
    }

    public static int CheckMatrix(int[][] grid, int r, int c)
    {
        HashSet<int> check = new HashSet<int>();

        //Middle validation
        if (grid[r + 1][c + 1] != 5)
            return 0;

        //Check cell value in range 1-9 and not duplicated in matrix
        for (int i = r; i < r + 3; i++)
        {
            for (int j = c; j < c + 3; j++)
            {
                if (!check.Contains(grid[i][j]) ||
                grid[i][j] < 1 || grid[i][j] > 9)
                    return 0;
                check.Add(grid[i][j]);
            }
        }

        //Rows validation
        for (int i = r; i < r + 3; i++)
        {
            if (grid[i][c] + grid[i][c + 1] + grid[i][c + 2] != 15)
                return 0;
        }

        //Cols validation
        for (int j = c; j < c + 3; j++)
        {
            if (grid[r][j] + grid[r + 1][j] + grid[r + 2][j] != 15)
                return 0;
        }

        //Diagonals validation
        if (grid[r][c] + grid[r + 1][c + 1] + grid[r + 2][c + 2] != 15)
            return 0;
        if (grid[r][c + 2] + grid[r + 1][c + 1] + grid[r + 2][c] != 15)
            return 0;

        return 1;
    }
}