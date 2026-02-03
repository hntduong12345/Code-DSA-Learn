public class Solution
{
    public bool IsTrionic(int[] nums)
    {
        int n = nums.Length;
        int i = 0;

        //Increase side 1
        while (i + 1 < n && nums[i] < nums[i + 1])
        {
            i++;
        }

        if (i == 0 || i == n - 1)
            return false;

        //Decrease side
        while (i + 1 < n && nums[i] > nums[i + 1])
        {
            i++;
        }

        if (i == n - 1)
            return false;

        //Increase side 2
        while (i + 1 < n && nums[i] < nums[i + 1])
        {
            i++;
        }

        return i == n - 1;
    }
}