class Solution
{
    private static void Main(string[] args)
    {
        string s = "abc";
        int k = 2;
        Console.WriteLine(MinDeletion(s, k));
    }

    public static int MinDeletion(string s, int k)
    {
        int[] count = new int[26];
        int distintChar = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (count[s[i] - 'a']++ == 0)
                distintChar++;
        }

        Array.Sort(count);
        int result = 0;
        for (int i = 0; i < count.Length; i++)
        {
            if (count[i] != 0 && distintChar - k > 0)
            {
                result += count[i];
                k++;
            }
        }

        return result;
    }
}