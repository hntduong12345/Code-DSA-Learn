using System.Text;

class Solution
{
    public static void Main(string[] args)
    {
        string sequence = "ababcd";
        string word = "ab";

        Console.WriteLine(MaxRepeating(sequence, word));
    }

    public static int MaxRepeating(string sequence, string word)
    {
        StringBuilder sb = new StringBuilder(word);
        int res = 0;
        while (sequence.Contains(sb.ToString()))
        {
            res++;
            sb.Append(word);
        }

        return res;
    }
}