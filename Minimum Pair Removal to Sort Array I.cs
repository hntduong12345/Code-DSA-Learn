using System.Text;

class Solution
{
    public static void Main(string[] args)
    {
        int[] nums = [1, 2, 3, 4, 5, 6];

        Console.WriteLine(MinimumPairRemoval(nums));
    }

    public static int MinimumPairRemoval(int[] nums)
    {
        int ans = 0;
        List<int> numList = nums.ToList();

        List<int> pairSums = new List<int>();
        int minPairSum = 0, minPairIndex = -1;

        while (!IsSorted(numList))
        {
            for (int i = 0; i < numList.Count - 1; i++)
            {
                pairSums.Add(numList[i] + numList[i + 1]);
            }

            minPairSum = pairSums[0];
            minPairIndex = 0;
            for (int i = 1; i < pairSums.Count; i++)
            {
                if (pairSums[i] < minPairSum)
                {
                    minPairSum = pairSums[i];
                    minPairIndex = i;
                }
            }

            numList[minPairIndex] = minPairSum;
            numList.RemoveAt(minPairIndex + 1);

            ans++;
            pairSums.Clear();
        }
        return ans;
    }

    public static bool IsSorted(List<int> nums)
    {
        for (int i = 0; i < nums.Count - 1; i++)
        {
            if (nums[i + 1] < nums[i])
                return false;
        }
        return true;
    }
}