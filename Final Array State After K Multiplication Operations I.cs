using System.Text;

class Solution
{
    public static void Main(string[] args)
    {
        int[] nums = [2, 1, 3, 5, 6];
        int k = 5;
        int mul = 2;

        Console.WriteLine(GetFinalState(nums, k, mul));
    }

    public static int[] GetFinalState(int[] nums, int k, int multiplier)
    {
        PriorityQueue<int, (int value, int index)> queue = new PriorityQueue<int, (int value, int index)>();
        for (int i = 0; i < nums.Length; i++)
        {
            queue.Enqueue(i, (nums[i], i));
        }

        int index = 0;
        while (queue.Count > 0 && k > 0)
        {
            index = queue.Dequeue();
            nums[index] *= multiplier;
            queue.Enqueue(index, (nums[index], index));
            k--;
        }

        return nums;
    }
}