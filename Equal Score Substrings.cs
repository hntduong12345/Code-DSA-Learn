public class Solution
{
    public bool ScoreBalance(string s)
    {
        int[] preSum = new int[s.Length];
        int n = s.Length;
        preSum[0] = s[0] - 'a' + 1;
        for (int i = 1; i < n; i++)
        {
            preSum[i] += preSum[i - 1] + (s[i] - 'a' + 1);
        }

        for (int i = 0; i < n; i++)
        {
            if (preSum[i] * 2 == preSum[n - 1])
                return true;
        }

        return false;
    }
}
