using System.Text;

class Solution
{
    public static void Main(string[] args)
    {
        int[] k = [1, 2, 3];
        Console.WriteLine(PlusOne(k));
    }

    public static int[] PlusOne(int[] digits)
    {
        int add = 1;
        List<int> res = new List<int>();

        for (int i = digits.Length - 1; i >= 0; i--)
        {
            res.Insert(0, (digits[i] + add) % 10);

            if (digits[i] + add >= 10)
            {
                add = 1;
            }
            else
            {
                add = 0;
            }
        }

        if (add == 1)
            res.Insert(0, add);

        return res.ToArray();
    }
}