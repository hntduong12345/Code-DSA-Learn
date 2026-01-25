using System.Text;

class Solution
{
    public static void Main(string[] args)
    {
        int[] nums = [1, 2, 3, 4, 5, 6];
        int k = 2;

        Console.WriteLine(MinimumDifference(nums, k));
    }

    public static int MinimumDifference(int[] nums, int k)
    {
        int res = int.MaxValue;
        int n = nums.Length;
        Array.Sort(nums);

        if (nums.Length <= 1)
            return 0;

        for (int i = 0; i <= n - k; i++)
        {
            res = Math.Min(res, nums[i + k - 1] - nums[i]);
        }

        return res;
    }
}