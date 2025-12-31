using System.Text;

class Solution
{
    public static void Main(string[] args)
    {
        string s = "leetcode";
        int k = 2;
        Console.WriteLine(GetLucky(s, k));
    }

    public static int GetLucky(string s, int k)
    {
        StringBuilder num = new StringBuilder();
        //Convert s to number string
        for (int i = 0; i < s.Length; i++)
        {
            num.Append(s[i] - 'a' + 1);
        }

        while (k > 0 && num.Length > 1)
        {
            int sum = 0;
            for (int i = 0; i < num.Length; i++)
            {
                sum += num[i] - '0';
            }

            num.Clear();
            num.Append(sum);
            k--;
        }

        return int.Parse(num.ToString());
    }
}