using System.Text;

class Solution
{
    public static void Main(string[] args)
    {
        int[] hBars = [6, 12, 13, 19, 2, 10, 17, 14, 11, 4, 15];
        int[] vBars = [8, 5, 10, 9, 3, 2, 6, 7, 4];

        int m = 9, n = 20;

        Console.WriteLine(MaximizeSquareArea(m, n, hBars, vBars));
    }

    static int mod = 1000000007;
    public static int MaximizeSquareArea(int m, int n, int[] hFences, int[] vFences)
    {
        long longestSide = 0;
        List<int> hF = hFences.ToList();
        List<int> vF = vFences.ToList();
        //Add matrix boundary
        hF.Add(1);
        hF.Add(m);
        vF.Add(1);
        vF.Add(n);

        hF.Sort();
        vF.Sort();

        //Calculate the different between each fences in hFences;
        HashSet<int> hFDiff = new HashSet<int>();
        for (int i = 0; i < hF.Count - 1; i++)
        {
            for (int j = i + 1; j < hF.Count; j++)
            {
                hFDiff.Add(hF[j] - hF[i]);
            }
        }

        //Check vertical fences different have biggest common with horizontal
        for (int i = 0; i < vF.Count - 1; i++)
        {
            for (int j = i + 1; j < vF.Count; j++)
            {
                if (hFDiff.Contains(vF[j] - vF[i]))
                {
                    longestSide = Math.Max(longestSide, vF[j] - vF[i]);
                }
            }
        }

        int res = -1;
        if (longestSide != 0)
            res = (int)((longestSide * longestSide) % mod);
        return res;
    }
}