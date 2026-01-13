using System.Text;

class Solution
{
    public static void Main(string[] args)
    {
        int[][] squares = [[0, 0, 2], [1, 1, 1]];

        Console.WriteLine(SeparateSquares(squares));
    }

    public static double SeparateSquares(int[][] squares)
    {
        var (minY, maxY) = GetMaxMinY(squares);
        double prescision = 0.00001;
        double midY = 0;

        while (maxY - minY > prescision)
        {
            midY = (maxY + minY) / 2.0;
            if (CompareLowerUpperArea(squares, midY))
            {
                maxY = midY; //Upper area < lower area
            }
            else
            {
                minY = midY; //Lower area < Upper area
            }
        }

        return midY;
    }

    public static (double min, double max) GetMaxMinY(int[][] squares)
    {
        double minY = squares[0][1];
        double maxY = squares[0][1] + squares[0][2];

        for (int i = 0; i < squares.Length; i++)
        {
            minY = Math.Min(minY, squares[i][1] * 1.0);
            maxY = Math.Max(maxY, (squares[i][1] + squares[i][2]) * 1.0);
        }

        return (minY, maxY);
    }

    public static bool CompareLowerUpperArea(int[][] squares, double midY)
    {
        double lowerArea = 0.0, upperArea = 0;
        double botY = 0.0, topY = 0.0, side = 0.0;

        foreach (var square in squares)
        {
            botY = square[1];
            side = square[2];
            topY = botY + side;

            if (topY <= midY)
            {
                lowerArea += side * side;
            }
            else if (botY >= midY)
            {
                upperArea += side * side;
            }
            else
            {
                double below = midY - botY;
                double above = topY - midY;

                lowerArea += below * below;
                upperArea += above * above;
            }
        }

        return lowerArea >= upperArea;
    }
}