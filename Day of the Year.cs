using System.Text;

class Solution
{
    public static void Main(string[] args)
    {
        string s = "2022-01-22";

        Console.WriteLine(DayOfYear(s));
    }

    public static int DayOfYear(string date)
    {
        string[] dateParts = date.Split('-');

        int year = int.Parse(dateParts[0]);
        int month = int.Parse(dateParts[1]);
        int day = int.Parse(dateParts[2]);

        bool isLeapYear = CheckLeapYear(year);

        int res = 0;
        for (int i = month - 1; i > 0; i--)
        {
            if (i == 1 || i == 3 || i == 5 ||
               i == 7 || i == 8 || i == 10 || i == 12)
                res += 31;
            else if (i == 4 || i == 6 || i == 9 || i == 11)
                res += 30;
            else if (isLeapYear)
                res += 29;
            else
                res += 28;
        }

        return res + day;
    }

    public static bool CheckLeapYear(int year)
    {
        if ((year % 4 == 0 && year % 100 != 0) ||
           (year % 400 == 0))
            return true;
        return false;
    }
}