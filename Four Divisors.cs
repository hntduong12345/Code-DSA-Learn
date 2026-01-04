using System.Text;

class Solution
{
    public static void Main(string[] args)
    {
        int[] test = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
        Console.WriteLine(SumFourDivisors(test));
    }

    public static int SumFourDivisors(int[] nums)
    {
        int divisors = 2;
        int divSum = 0;
        int totalDivSum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = 2; j <= Math.Sqrt(nums[i]); j++)
            {
                if (nums[i] % j == 0)
                {
                    if (nums[i] == j * j)
                    {
                        divisors++;
                        divSum += j;
                    }
                    else
                    {
                        divisors += 2;
                        divSum += j + nums[i] / j;
                    }
                }
            }

            if (divisors == 4)
            {
                totalDivSum += divSum + 1 + nums[i];
            }
            divSum = 0;
            divisors = 2;
        }

        return totalDivSum;
    }
}