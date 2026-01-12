using System.Text;

class Solution
{
    public static void Main(string[] args)
    {
        int[][] points = [[1, 1], [3, 4], [-1, 0]];

        Console.WriteLine(MinTimeToVisitAllPoints(points));
    }

    public static int MinTimeToVisitAllPoints(int[][] points)
    {
        int moves = 0;
        for (int i = 1; i < points.Length; i++)
        {
            moves += Math.Max(
                Math.Abs(points[i - 1][0] - points[i][0]),
                Math.Abs(points[i - 1][1] - points[i][1])
            );
        }

        return moves;
    }
}