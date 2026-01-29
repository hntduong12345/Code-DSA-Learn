using System.Text;

class Solution
{
    public static void Main(string[] args)
    {
        string source = "aaaa";
        string target = "bbbb";
        char[] original = ['a', 'c'];
        char[] changed = ['c', 'b'];
        int[] cost = [1, 2];

        Console.WriteLine(MinimumCost(source, target, original, changed, cost));
    }

    public static long MinimumCost(string source, string target, char[] original, char[] changed, int[] cost)
    {
        long[][] graph = new long[26][];
        for (int i = 0; i < 26; i++)
        {
            graph[i] = new long[26];
            Array.Fill(graph[i], 0);
        }

        //Set cost value and graph weight
        for (int i = 0; i < original.Length; i++)
        {
            if (graph[original[i] - 'a'][changed[i] - 'a'] == 0 ||
               graph[original[i] - 'a'][changed[i] - 'a'] > cost[i])
                graph[original[i] - 'a'][changed[i] - 'a'] = cost[i];
        }

        //Get min cost to change a char using floyds
        for (int k = 0; k < 26; k++)
        {
            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (graph[i][k] * graph[k][j] > 0 && i != j)
                    {
                        //Check is new cost less than current or a valid cost if current is not valid
                        if (graph[i][k] + graph[k][j] < graph[i][j] || graph[i][j] == 0)
                            graph[i][j] = graph[i][k] + graph[k][j];
                    }
                }
            }
        }

        //Get the min cost
        long res = 0;
        for (int i = 0; i < source.Length; i++)
        {
            if (source[i] != target[i])
            {
                if (graph[source[i] - 'a'][target[i] - 'a'] != 0)
                    res += graph[source[i] - 'a'][target[i] - 'a'];
                else
                    return -1;
            }
        }
        return res;
    }
}