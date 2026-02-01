public class Solution
{
    public int MinimumCost(int[] nums)
    {
        int sum = nums[0];
        int min = int.MaxValue;
        int secondMin = int.MaxValue;

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] < min)
            {
                secondMin = min;
                min = nums[i];
            }
            else if (nums[i] < secondMin)
            {
                secondMin = nums[i];
            }
        }

        return sum + min + secondMin;
    }
}