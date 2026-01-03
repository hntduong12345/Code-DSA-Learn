using System.Text;

class Solution
{
    public static void Main(string[] args)
    {
        string test = "AbBa";
        Console.WriteLine(LongestNiceSubstring(test));
    }

    public static string LongestNiceSubstring(string s)
    {
        if (s.Length <= 1)
            return "";

        HashSet<char> check = new HashSet<char>();
        for (int i = 0; i < s.Length; i++)
        {
            check.Add(s[i]);
        }

        char c = 'a';
        for (int i = 0; i < s.Length; i++)
        {
            c = s[i];
            if (check.Contains(char.ToLower(c)) && check.Contains(char.ToUpper(c)))
                continue;
            string pre = LongestNiceSubstring(s.Substring(0, i + 0)),
                   post = LongestNiceSubstring(s.Substring(i + 1));

            return (pre.Length >= post.Length) ? pre : post;
        }

        return s;
    }
}