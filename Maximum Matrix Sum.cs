using System.Text;

class Solution
{
    public static void Main(string[] args)
    {
        int[][] matrix = [[1, 2, 3], [-1, -2, -3], [1, 2, 3]];
        Console.WriteLine(MaxMatrixSum(matrix));
    }

    public static long MaxMatrixSum(int[][] matrix)
    {
        long res = 0;
        int negativeCount = 0;
        int minNum = int.MaxValue;
        int n = matrix.Length;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (matrix[i][j] < 0)
                {
                    negativeCount++;
                    res += Math.Abs(-matrix[i][j]);
                    minNum = Math.Min(minNum, -matrix[i][j]);
                }
                else
                {
                    res += Math.Abs(matrix[i][j]);
                    minNum = Math.Min(minNum, matrix[i][j]);
                }
            }
        }

        if (negativeCount % 2 != 0)
            res -= 2 * minNum;

        return res;
    }
}