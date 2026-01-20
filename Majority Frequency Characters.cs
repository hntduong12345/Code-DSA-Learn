using System.Text;

class Solution
{
    public static void Main(string[] args)
    {
        string s = "aabbcccddde";

        Console.WriteLine(MajorityFrequencyGroup(s));
    }

    public static string MajorityFrequencyGroup(string s)
    {
        Dictionary<char, int> count = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++)
        {
            if (count.ContainsKey(s[i]))
            {
                count[s[i]]++;
            }
            else
            {
                count.Add(s[i], 1);
            }
        }

        string res = "";
        int maxSize = 0;
        int maxFreq = 0;
        Dictionary<int, string> freq = new Dictionary<int, string>();
        foreach (var item in count)
        {
            if (freq.ContainsKey(item.Value))
            {
                freq[item.Value] += item.Key;
            }
            else
            {
                freq.Add(item.Value, $"{item.Key}");
            }

            if (freq[item.Value].Length > maxSize)
            {
                maxSize = freq[item.Value].Length;
                res = freq[item.Value];
                maxFreq = item.Value;
            }
            else if (freq[item.Value].Length == maxSize && maxFreq < item.Value)
            {
                res = freq[item.Value];
                maxFreq = item.Value;
            }
        }

        return res;
    }
}