using System.Text;

class Solution
{
    public static void Main(string[] args)
    {
        int[] nums = [42, 11, 1, 97];
        Console.WriteLine(CountNicePairs(nums));
    }

    static int mod = 1000000007;
    public static int CountNicePairs(int[] nums)
    {
        Dictionary<int, List<int>> count = new Dictionary<int, List<int>>();
        List<int> cals = new List<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            cals.Add(nums[i] - ReverseNum(nums[i]));
            if (!count.ContainsKey(cals[i]))
            {
                count[cals[i]] = new List<int>();
            }
            count[cals[i]].Add(nums[i]);
        }

        int res = 0;
        for (int i = 0; i < cals.Count(); i++)
        {
            if (count[cals[i]].Count() == 1)
            {
                count.Remove(cals[i]);
                continue;
            }

            res = (res + count[cals[i]].Count() - 1) % mod;
            count[cals[i]].Remove(nums[i]);
        }

        return res;
    }

    public static int ReverseNum(int num)
    {
        int res = 0;
        while (num > 0)
        {
            res = (res * 10 + num % 10) % mod;
            num /= 10;
        }

        return res;
    }
}