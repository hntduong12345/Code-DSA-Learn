public class Solution
{
    public double ChampagneTower(int poured, int query_row, int query_glass)
    {
        double[] prevRow = new double[] { poured };

        for (int row = 1; row <= query_row; row++)
        {
            double[] curRow = new double[row + 1];
            for (int i = 0; i < row; i++)
            {
                double extra = prevRow[i] - 1.0;
                if (extra > 0)
                {
                    curRow[i] += 0.5 * extra;
                    curRow[i + 1] += 0.5 * extra;
                }
            }

            prevRow = curRow;
        }

        return Math.Min(1.0, prevRow[query_glass]);
    }
}