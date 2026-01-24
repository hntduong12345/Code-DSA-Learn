using System.Text;

class Solution
{
    public static void Main(string[] args)
    {
        int[] nums = [1, 2, 3, 4, 5, 6];

        Console.WriteLine(MinPairSum(nums));
    }

    public static int MinPairSum(int[] nums)
    {
        Array.Sort(nums);
        int n = nums.Length;
        int sum = nums[0] + nums[n - 1];
        for (int i = 1; i < (n / 2); i++)
        {
            sum = Math.Max(nums[i] + nums[n - i - 1], sum);
            Console.WriteLine(nums[i] + nums[n - i - 1]);
        }

        return sum;
    }
}