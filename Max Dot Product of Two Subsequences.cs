using System.Text;

class Solution
{
    public static void Main(string[] args)
    {
        int[] nums1 = [2, 1, -2, 5];
        int[] nums2 = [3, 0, -6];

        Console.WriteLine(MaxDotProduct(nums1, nums2));
    }

    public static int MaxDotProduct(int[] nums1, int[] nums2)
    {
        //Calculate max and min of each nums1 and nums2
        int max1 = nums1[0], min1 = nums1[0];
        int max2 = nums2[0], min2 = nums2[0];

        for (int i = 1; i < nums1.Length; i++)
        {
            max1 = Math.Max(max1, nums1[i]);
            min1 = Math.Min(min1, nums1[i]);
        }

        for (int i = 1; i < nums2.Length; i++)
        {
            max2 = Math.Max(max2, nums2[i]);
            min2 = Math.Min(min2, nums2[i]);
        }

        //Check max, min
        if (max1 < 0 && min2 > 0)
            return max1 * min2;
        if (max2 < 0 && min1 > 0)
            return max2 * min1;

        int use = 0;
        //Calculate dp array
        int[,] dp = new int[nums1.Length + 1, nums2.Length + 1];
        for (int i = nums1.Length - 1; i >= 0; i--)
        {
            for (int j = nums2.Length - 1; j >= 0; j--)
            {
                use = nums1[i] * nums2[j] + dp[i + 1, j + 1];
                dp[i, j] = Math.Max(use, Math.Max(dp[i + 1, j], dp[i, j + 1]));
            }
        }

        return dp[0, 0];
    }
}