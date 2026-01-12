using System.Text;

class Solution
{
    public static void Main(string[] args)
    {
        int[][] grid = [[1, 0], [0, 2]];

        Console.WriteLine(ProjectionArea(grid));
    }

    public static int ProjectionArea(int[][] grid)
    {
        int totalArea = 0;
        int[] rowsMax = new int[grid.Length]; //Get max num of each row.
        int[] colsMax = new int[grid[0].Length]; //Get max num of each col.
        int cubeCount = 0;

        //setup max each rows and each cols
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if (grid[i][j] != 0)
                {
                    cubeCount++;
                    rowsMax[i] = Math.Max(rowsMax[i], grid[i][j]);
                    colsMax[j] = Math.Max(colsMax[j], grid[i][j]);
                }
            }
        }

        //Calculate zy
        for (int i = 0; i < rowsMax.Length; i++)
        {
            totalArea += rowsMax[i];
        }

        //Calculate zx
        for (int i = 0; i < colsMax.Length; i++)
        {
            totalArea += colsMax[i];
        }

        return totalArea + cubeCount;
    }
}