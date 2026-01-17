using System.Text;

class Solution
{
    public static void Main(string[] args)
    {
        int[][] botLeft = [[1, 1], [2, 2], [3, 1]];
        int[][] topRight = [[3, 3], [4, 4], [6, 6]];

        Console.WriteLine(LargestSquareArea(botLeft, topRight));
    }

    public static long LargestSquareArea(int[][] bottomLeft, int[][] topRight)
    {
        long maxSideLength = 0;
        int n = bottomLeft.Length;
        long width = 0, height = 0;

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                width = Math.Min(topRight[i][0], topRight[j][0]) - Math.Max(bottomLeft[i][0], bottomLeft[j][0]);
                height = Math.Min(topRight[i][1], topRight[j][1]) - Math.Max(bottomLeft[i][1], bottomLeft[j][1]);

                if (width > 0 && height > 0)
                {
                    maxSideLength = Math.Max(maxSideLength, Math.Min(width, height));
                }
            }
        }

        return maxSideLength * maxSideLength;
    }
}