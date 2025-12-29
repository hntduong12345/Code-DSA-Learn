using System.Text;

class Solution
{
    static Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();

    public static void Main(string[] args)
    {
        string bottom = "BCD";
        IList<string> allowed = ["BCC", "CDE", "CEA", "FFF"];
        Console.Write(PyramidTransition(bottom, allowed));
    }

    public static bool PyramidTransition(string bottom, IList<string> allowed)
    {
        int key = 0;
        for (int i = 0; i < allowed.Count(); i++)
        {
            key = (allowed[i][0] - 'A') * 6 + (allowed[i][1] - 'A');

            if (!map.ContainsKey(key))
                map[key] = new List<int>();

            map[key].Add(allowed[i][2] - 'A');
        }

        //Check can create pyramid
        return CheckPyramid(bottom);
    }

    private static bool CheckPyramid(string row)
    {
        // Be able to have the top block ==> return true
        if (row.Length == 1)
            return true;

        //Check can upper row built up.
        return CheckRowBuiltUp(row, 0, new StringBuilder());
    }

    private static bool CheckRowBuiltUp(string row, int index, StringBuilder nextRow)
    {
        //Check if meet end of next row
        if (index == row.Length - 1)
            return CheckPyramid(nextRow.ToString());

        //Get key code
        int key = (row[index] - 'A') * 6 + (row[index + 1] - 'A');

        //Check is there possible triagular pattern pyramid
        if (!map.ContainsKey(key))
            return false;

        //Build top block in the next row
        foreach (var val in map[key])
        {
            nextRow.Append((char)(val + 'A'));

            if (CheckRowBuiltUp(row, index + 1, nextRow))
                return true;

            //Truncate the last character of the StringBuilder.
            nextRow.Length--;
        }

        return false;
    }
}