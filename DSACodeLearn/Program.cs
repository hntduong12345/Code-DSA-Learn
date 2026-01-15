using System.Text;

class Solution
{
    public static void Main(string[] args)
    {
        int[] hBars = [6, 12, 13, 19, 2, 10, 17, 14, 11, 4, 15];
        int[] vBars = [8, 5, 10, 9, 3, 2, 6, 7, 4];

        int m = 9, n = 20;

        Console.WriteLine(MaximizeSquareHoleArea(n,m,hBars,vBars));
    }

    public static int MaximizeSquareHoleArea(int n, int m, int[] hBars, int[] vBars)
    {
        Array.Sort(hBars);
        Array.Sort(vBars);

        int hStart = hBars[0], hEnd = hBars[0], hConLength = 1;
        int vStart = vBars[0], vEnd = vBars[0], vConLength = 1;
        //Find longest sequence of consecutive value in horizontal bars
        for (int i = 1; i < hBars.Length; i++)
        {
            if (hBars[i] - 1 != hBars[i - 1] || hBars[i] == n + 2)
            {
                hConLength = Math.Max(hEnd - hStart + 1, hConLength);
                hStart = hBars[i];
                hEnd = hBars[i];
            }
            else
            {
                hEnd = hBars[i];
            }
        }
        hConLength = Math.Max(hEnd - hStart + 1, hConLength);

        //Find longest sequence of consecutive value in vertical bars
        for (int i = 1; i < vBars.Length; i++)
        {
            if (vBars[i] - 1 != vBars[i - 1] || vBars[i] == m + 2)
            {
                vConLength = Math.Max(vEnd - vStart + 1, vConLength);
                vStart = vBars[i];
                vEnd = vBars[i];
            }
            else
            {
                vEnd = vBars[i];
            }
        }
        vConLength = Math.Max(vEnd - vStart + 1, vConLength);

        int sideLength = Math.Min(vConLength + 1, hConLength + 1);
        return sideLength * sideLength;
    }
}