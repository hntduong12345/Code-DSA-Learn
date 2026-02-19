public class Solution
{
    public int CountBinarySubstrings(string s)
    {
        int res = 0;
        int prev = 0, cur = 1;
        for (int i = 1; i < s.Length; i++)
        {
            if (s[i] != s[i - 1])
            {
                res += Math.Min(prev, cur);
                prev = cur;
                cur = 1;
            }
            else
            {
                cur++;
            }
        }
        return res + Math.Min(prev, cur);
    }
}