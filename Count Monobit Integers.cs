public class Solution
{
    public int CountMonobit(int n)
    {
        int res = 1;
        int mul = 2;

        int num = 1;
        while (num <= n)
        {
            res++;
            num += mul;
            mul *= 2;
        }

        return res;
    }
}