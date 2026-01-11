using System.Text;

class Solution
{
    public static void Main(string[] args)
    {
        char[][] matrix = [['1', '0', '1', '0', '0'], ['1', '0', '1', '1', '1'], ['1', '1', '1', '1', '1'], ['1', '0', '0', '1', '0']];

        Console.WriteLine(MaximalSquare(matrix));
    }

    public static int MaximalSquare(char[][] matrix)
    {
        int rows = matrix.Length;
        int cols = matrix[0].Length;
        int[,] dp = new int[rows + 1, cols + 1];

        int maxSquareSide = 0;

        for (int i = rows - 1; i >= 0; i--)
        {
            for (int j = cols - 1; j >= 0; j--)
            {
                if (matrix[i][j] == '1')
                {
                    dp[i, j] = 1 + Math.Min(dp[i + 1, j + 1], Math.Min(dp[i + 1, j], dp[i, j + 1]));
                }
                else
                {
                    dp[i, j] = 0;
                }

                maxSquareSide = Math.Max(maxSquareSide, dp[i, j]);
            }
        }

        return maxSquareSide * maxSquareSide;
    }
}