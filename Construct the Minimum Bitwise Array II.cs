using System.Text;

class Solution
{
    public static void Main(string[] args)
    {
        IList<int> nums = new List<int>() { 23 };

        Console.WriteLine(MinBitwiseArray(nums));
    }

    public static int[] MinBitwiseArray(IList<int> nums)
    {
        for (int i = 0; i < nums.Count; i++)
        {
            int x = nums[i];
            int res = -1;
            int checkNum = 1;
            while ((x & checkNum) != 0)
            {
                res = x - checkNum;
                checkNum <<= 1;
            }
            nums[i] = res;
        }
        return nums.ToArray();
    }
}