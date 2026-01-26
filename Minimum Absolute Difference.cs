using System.Text;

class Solution
{
    public static void Main(string[] args)
    {
        int[] nums = [1, 2, 3, 4, 5, 6];

        Console.WriteLine(MinimumAbsDifference(nums));
    }

    public static IList<IList<int>> MinimumAbsDifference(int[] arr)
    {
        int minDiff = int.MaxValue;
        Array.Sort(arr);

        for (int i = 1; i < arr.Length; i++)
        {
            minDiff = Math.Min(minDiff, Math.Abs(arr[i] - arr[i - 1]));
        }

        IList<IList<int>> ans = new List<IList<int>>();
        for (int i = 1; i < arr.Length; i++)
        {
            if (Math.Abs(arr[i] - arr[i - 1]) == minDiff)
            {
                ans.Add(new int[] { arr[i - 1], arr[i] });
            }
        }
        return ans;
    }
}