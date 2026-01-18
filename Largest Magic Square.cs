using System.Text;

class Solution
{
    public static void Main(string[] args)
    {
        int[][] grid = [[7, 1, 4, 5, 6], [2, 5, 1, 6, 4], [1, 5, 4, 3, 2], [1, 2, 7, 3, 4]];

        Console.WriteLine(LargestMagicSquare(grid));
    }

    public static int LargestMagicSquare(int[][] grid)
    {
        int rows = grid.Length, cols = grid[0].Length;
        int[,] rowPrefix = new int[rows, cols];
        int[,] colPrefix = new int[cols, rows];

        //Calculate rows and cols prefix sum
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (j != 0)
                    rowPrefix[i, j] += rowPrefix[i, j - 1];
                rowPrefix[i, j] += grid[i][j];

                if (i != 0)
                    colPrefix[j, i] += colPrefix[j, i - 1];
                colPrefix[j, i] += grid[i][j];
            }
        }

        int res = 1;
        int diagonal = 0, antiDiagonal = 0;
        bool isChecked = true;
        int rowSum = 0, colSum = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                for (int side = 2; side <= Math.Min(rows - i, cols - j); side++)
                {
                    int sideSum = rowPrefix[i, j + side - 1] - (j > 0 ? rowPrefix[i, j - 1] : 0);
                    diagonal = 0;
                    antiDiagonal = 0;
                    isChecked = true;

                    //Check row and col sum; Cal diag and anti-diag
                    for (int k = 0; k < side; k++)
                    {
                        rowSum = rowPrefix[i + k, j + side - 1] - (j > 0 ? rowPrefix[i + k, j - 1] : 0);
                        if (rowSum != sideSum)
                        {
                            isChecked = false;
                            break;
                        }

                        colSum = colPrefix[j + k, i + side - 1] - (i > 0 ? colPrefix[j + k, i - 1] : 0);
                        if (colSum != sideSum)
                        {
                            isChecked = false;
                            break;
                        }

                        diagonal += grid[i + k][j + k];
                        antiDiagonal += grid[i + k][j + side - k - 1];
                    }

                    if (isChecked && diagonal == sideSum && antiDiagonal == sideSum)
                        res = Math.Max(res, side);
                }
            }
        }

        return res;
    }
}