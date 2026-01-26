using System.Text;

class Solution
{
    public static void Main(string[] args)
    {
        int[] nums = [1, 2, 3, 4, 5, 6];

        Console.WriteLine(MinimumCost(nums));
    }

    public static int MinimumCost(int[] cost)
    {
        Array.Sort(cost);
        int total = 0;
        int buyCount = 0;

        for (int i = cost.Length - 1; i >= 0; i--)
        {
            if (buyCount < 2)
            {
                total += cost[i];
                buyCount++;
            }
            else
            {
                buyCount = 0;
            }

        }

        return total;
    }
}