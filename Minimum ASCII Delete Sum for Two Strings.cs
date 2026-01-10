using System.Text;

class Solution
{
    public static void Main(string[] args)
    {
        string text1 = "delete";
        string text2 = "leet";

        Console.WriteLine(MinimumDeleteSum(text1, text2));
    }

    public static int MinimumDeleteSum(string s1, string s2)
    {
        int[,] dp = new int[s1.Length + 1, s2.Length + 1];

        for (int i = 1; i <= s1.Length; i++)
        {
            dp[i, 0] = dp[i - 1, 0] + (s1[i - 1] - 0);
        }

        for (int i = 1; i <= s2.Length; i++)
        {
            dp[0, i] = dp[0, i - 1] + (s2[i - 1] - 0);
        }

        for (int i = 1; i <= s1.Length; i++)
        {
            for (int j = 1; j <= s2.Length; j++)
            {
                if (s1[i - 1] == s2[j - 1])
                {
                    dp[i, j] = dp[i - 1, j - 1];
                }
                else
                {
                    dp[i, j] = Math.Min(
                        dp[i, j - 1] + (s2[j - 1] - 0),
                        dp[i - 1, j] + (s1[i - 1] - 0)
                    );
                }
            }
        }

        return dp[s1.Length, s2.Length];
    }
}