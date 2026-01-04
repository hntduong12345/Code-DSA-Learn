using System.Text;

class Solution
{
    public static void Main(string[] args)
    {
        string test = "zadavyayobbgqsexaabk";
        Console.WriteLine(CalculateScore(test));
    }

    public static long CalculateScore(string s)
    {
        Dictionary<int, Stack<int>> count = new Dictionary<int, Stack<int>>();
        int charNum = 0;
        long res = 0;
        for (int i = 0; i < s.Length; i++)
        {
            charNum = s[i] - 97;
            if (!count.ContainsKey(25 - charNum))
            {
                if (!count.ContainsKey(charNum))
                    count[charNum] = new Stack<int>();
                count[charNum].Push(i);
            }
            else
            {
                res += i - count[25 - charNum].Pop();
                if (count[25 - charNum].Count == 0)
                    count.Remove(25 - charNum);
            }
        }

        return res;
    }
}