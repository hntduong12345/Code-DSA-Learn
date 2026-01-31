public class Solution
{
    public char NextGreatestLetter(char[] letters, char target)
    {
        char res = letters[0];
        int minDif = letters[0] - target > 0 ? letters[0] - target : 26;
        int dif = 0;
        for (int i = 0; i < letters.Length; i++)
        {
            dif = letters[i] - target;
            if (dif > 0 && dif < minDif)
            {
                minDif = dif;
                res = letters[i];
            }
        }

        return res;
    }
}