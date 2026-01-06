using System.Text;

class Solution
{
    public static void Main(string[] args)
    {
        char[] chars = ['a'];
        Console.WriteLine(Compress(chars));
    }

    public static int Compress(char[] chars)
    {
        int compressLength = 1;
        char curChar = chars[0];
        int charCount = 1;
        string charStr = $"{chars[0]}";

        if (chars.Length == 1)
            return 1;

        for (int i = 1; i < chars.Length; i++)
        {
            if (chars[i] == curChar)
            {
                charCount++;
            }
            else
            {
                if (charCount != 1)
                {
                    compressLength += CountNumLength(charCount) + 1;
                    charStr += $"{charCount}";
                }
                else
                    compressLength += 1;

                curChar = chars[i];
                charStr += curChar;
                charCount = 1;
            }
        }

        if (charCount != 1)
        {
            compressLength += CountNumLength(charCount);
            charStr += $"{charCount}";
        }

        for (int i = 1; i < charStr.Length; i++)
        {
            chars[i] = charStr[i];
        }

        return compressLength;
    }

    public static int CountNumLength(int num)
    {
        int count = 0;
        while (num > 0)
        {
            count++;
            num /= 10;
        }

        return count;
    }
}using System.Text;

class Solution
{
    public static void Main(string[] args)
    {
        char[] chars = ['a'];
        Console.WriteLine(Compress(chars));
    }

    public static int Compress(char[] chars)
    {
        int compressLength = 1;
        char curChar = chars[0];
        int charCount = 1;
        string charStr = $"{chars[0]}";

        if (chars.Length == 1)
            return 1;

        for (int i = 1; i < chars.Length; i++)
        {
            if (chars[i] == curChar)
            {
                charCount++;
            }
            else
            {
                if (charCount != 1)
                {
                    compressLength += CountNumLength(charCount) + 1;
                    charStr += $"{charCount}";
                }
                else
                    compressLength += 1;

                curChar = chars[i];
                charStr += curChar;
                charCount = 1;
            }
        }

        if (charCount != 1)
        {
            compressLength += CountNumLength(charCount);
            charStr += $"{charCount}";
        }

        for (int i = 1; i < charStr.Length; i++)
        {
            chars[i] = charStr[i];
        }

        return compressLength;
    }

    public static int CountNumLength(int num)
    {
        int count = 0;
        while (num > 0)
        {
            count++;
            num /= 10;
        }

        return count;
    }
}