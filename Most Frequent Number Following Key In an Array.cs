using System.Text;

class Solution
{
    public static void Main(string[] args)
    {
        int[] nums = [1, 100, 200, 1, 100];
        int n = 1;

        Console.WriteLine(MostFrequent(nums, n));
    }

    public static int MostFrequent(int[] nums, int key)
    {
        int maxCount = 0, target = 0;
        int[] count = new int[1001];

        for (int i = 0; i < nums.Length; i++)
        {
            if (i != nums.Length - 1 && nums[i] == key)
            {
                if (maxCount < ++count[nums[i + 1]])
                {
                    maxCount = count[nums[i + 1]];
                    target = nums[i + 1];
                }
            }
        }

        return target;
    }
}