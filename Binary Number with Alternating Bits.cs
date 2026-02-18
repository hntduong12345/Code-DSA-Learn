public class Solution
{
    public bool HasAlternatingBits(int n)
    {
        int bit = n % 2 == 0 ? 0 : 1;
        n /= 2;

        while (n > 0)
        {
            if (n % 2 == bit)
                return false;
            else
                bit = n % 2;
            n /= 2;
        }

        return true;
    }
}