using System.Text;

class Solution
{
    public static void Main(string[] args)
    {
        int[][] grid = [[18, 70], [61, 1], [25, 85], [14, 40], [11, 96], [97, 96], [63, 45]];
        int threshold = 40184;

        Console.WriteLine(MaxSideLength(grid, threshold));
    }

    public static int MaxSideLength(int[][] mat, int threshold)
    {
        int rows = mat.Length, cols = mat[0].Length;
        int[,] preSum = new int[rows + 1, cols + 1];

        //Cal prefix sum of each rows and cols
        for (int i = 1; i <= rows; i++)
        {
            for (int j = 1; j <= cols; j++)
            {
                preSum[i, j] = preSum[i - 1, j] + preSum[i, j - 1] -
                              preSum[i - 1, j - 1] + mat[i - 1][j - 1];
            }
        }

        int ans = 0;
        int maxLength = Math.Min(rows, cols);
        int sum = 0;
        for (int i = 1; i <= rows; i++)
        {
            for (int j = 1; j <= cols; j++)
            {
                for (int side = ans + 1; side <= maxLength; side++)
                {
                    if (i + side - 1 > rows || j + side - 1 > cols)
                        break;

                    sum = preSum[i + side - 1, j + side - 1] - preSum[i - 1, j + side - 1] -
                          preSum[i + side - 1, j - 1] + preSum[i - 1, j - 1];
                    if (sum <= threshold)
                    {
                        ans++;
                    }
                    else
                        break;
                }
            }
        }
        return ans;
    }
}