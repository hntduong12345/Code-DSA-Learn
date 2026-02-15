public class Solution
{
    public string AddBinary(string a, string b)
    {
        int aIndex = a.Length - 1;
        int bIndex = b.Length - 1;

        int add = 0;
        int sum = 0;
        StringBuilder res = new StringBuilder();
        while (aIndex >= 0 && bIndex >= 0)
        {
            sum = a[aIndex] - '0' + b[bIndex] - '0' + add;
            if (sum >= 2)
            {
                add = 1;
                res.Insert(0, $"{sum - 2}");
            }
            else
            {
                add = 0;
                res.Insert(0, $"{sum}");
            }

            aIndex--;
            bIndex--;
        }

        while (aIndex >= 0)
        {
            sum = a[aIndex] - '0' + add;
            if (sum >= 2)
            {
                add = 1;
                res.Insert(0, $"{sum - 2}");
            }
            else
            {
                add = 0;
                res.Insert(0, $"{sum}");
            }

            aIndex--;
        }
        
        while (bIndex >= 0)
        {
            sum = b[bIndex] - '0' + add;
            if (sum >= 2)
            {
                add = 1;
                res.Insert(0, $"{sum - 2}");
            }
            else
            {
                add = 0;
                res.Insert(0, $"{sum}");
            }

            bIndex--;
        }

        if (add != 0)
        {
            res.Insert(0, "1");
        }
        return res.ToString();
    }
}