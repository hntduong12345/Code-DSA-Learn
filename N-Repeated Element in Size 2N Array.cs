using System.Text;

class Solution
{
    public static void Main(string[] args)
    {
        int[] k = [1, 2, 3];
        Console.WriteLine(RepeatedNTimes(k));
    }

    public static int RepeatedNTimes(int[] nums)
    {
        HashSet<int> checkUnique = new HashSet<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (checkUnique.Contains(nums[i]))
                return nums[i];
            else
                checkUnique.Add(nums[i]);
        }

        return -1;
    }
}