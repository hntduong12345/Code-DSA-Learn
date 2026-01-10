using System.Text;

class Solution
{
    public static void Main(string[] args)
    {
        string text1 = "abcde";
        string text2 = "ace";

        Console.WriteLine(LongestCommonSubsequence(text1, text2));
    }

    public static int LongestCommonSubsequence(string text1, string text2)
    {
        int[,] dp = new int[text1.Length + 1, text2.Length + 1];

        for (int i = text1.Length - 1; i >= 0; i--)
        {
            for (int j = text2.Length - 1; j >= 0; j--)
            {
                if (text1[i] == text2[j])
                {
                    dp[i, j] = 1 + dp[i + 1, j + 1];
                }
                else
                {
                    dp[i, j] = Math.Max(dp[i + 1, j], dp[i, j + 1]);
                }
            }
        }

        return dp[0, 0];
    }
}