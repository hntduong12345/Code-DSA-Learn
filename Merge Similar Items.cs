public class Solution
{
    public IList<IList<int>> MergeSimilarItems(int[][] items1, int[][] items2)
    {
        IList<IList<int>> res = new List<IList<int>>();
        //Sorting 2 items arrays
        Array.Sort(items1, (a, b) => a[0].CompareTo(b[0]));
        Array.Sort(items2, (a, b) => a[0].CompareTo(b[0]));

        int i = 0, j = 0;
        while (i < items1.Length && j < items2.Length)
        {
            if (items1[i][0] < items2[j][0])
            {
                res.Add(new List<int> { items1[i][0], items1[i][1] });
                i++;
            }
            else if (items1[i][0] > items2[j][0])
            {
                res.Add(new List<int> { items2[j][0], items2[j][1] });
                j++;
            }
            else
            {
                res.Add(new List<int> { items1[i][0], items1[i][1] + items2[j][1] });
                i++;
                j++;
            }
        }

        //Add the remain value (Not scan over) of 2 items arrays
        while (i < items1.Length)
        {
            res.Add(new List<int> { items1[i][0], items1[i][1] });
            i++;
        }

        while (j < items2.Length)
        {
            res.Add(new List<int> { items2[j][0], items2[j][1] });
            j++;
        }

        return res;
    }
}