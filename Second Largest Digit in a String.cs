using System.Text;

class Solution
{
    public static void Main(string[] args)
    {
        string s = "aab3bcc45cd1dde";

        Console.WriteLine(SecondHighest(s));
    }

    public static int SecondHighest(string s)
    {
        HashSet<int> nums = new HashSet<int>();
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] >= '0' && s[i] <= '9')
            {
                nums.Add(s[i] - '0');
            }
        }

        int largest = -1, secondLargest = -1;
        foreach (int num in nums)
        {
            if (largest < num)
            {
                secondLargest = largest;
                largest = num;
            }
            else if (secondLargest < num)
            {
                secondLargest = num;
            }
        }

        return secondLargest;
    }
}