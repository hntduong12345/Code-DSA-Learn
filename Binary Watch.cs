public class Solution
{
    public IList<string> ReadBinaryWatch(int turnedOn)
    {
        IList<string> res = new List<string>();
        string hour = "", min = "";
        if (turnedOn < 9)
        {
            for (int h = 0; h < 12; h++)
            {
                for (int m = 0; m < 60; m++)
                {
                    if (Count(h) + Count(m) == turnedOn)
                    {
                        hour = $"{h}";
                        if (m / 10 > 0)
                        {
                            min = $"{m}";
                        }
                        else
                        {
                            min = $"0{m}";
                        }
                        res.Add($"{hour}:{min}");
                    }
                }
            }
        }

        return res;
    }

    public int Count(int num)
    {
        int res = 0;
        while (num > 0)
        {
            res += num & 1;
            num >>= 1;
        }

        return res;
    }
}