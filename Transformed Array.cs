public class Solution
{
    public int[] ConstructTransformedArray(int[] nums)
    {
        int n = nums.Length;
        int[] res = new int[n];
        int targetIndex = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > 0)
            {
                targetIndex = (i + nums[i]) % n;
                res[i] = nums[targetIndex];
            }
            else if (nums[i] < 0)
            {
                targetIndex = (i + nums[i] + n) % n;
                while (targetIndex < 0)
                {
                    targetIndex = (targetIndex + n) % n;
                }
                res[i] = nums[targetIndex];
            }
        }

        return res;
    }
}