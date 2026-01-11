using System.Text;

class Solution
{
    public static void Main(string[] args)
    {
        char[][] matrix = [["1", "0", "1", "0", "0"], ["1", "0", "1", "1", "1"], ["1", "1", "1", "1", "1"], ["1", "0", "0", "1", "0"]];

        Console.WriteLine(MaximalRectangle(matrix));
    }

    public static int MaximalRectangle(char[][] matrix)
    {
        int rows = matrix.Length;
        int cols = matrix[0].Length;
        if (rows == 0)
            return 0;

        int maxArea = 0;
        int curArea = 0;
        int[] histogram = new int[cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i][j] == '1')
                    histogram[j]++;
                else
                    histogram[j] = 0;
            }

            curArea = CalLargestRectangleArea(histogram);
            maxArea = Math.Max(maxArea, curArea);
        }

        return maxArea;
    }

    //Calculate rectangle area from histogram (Can use in general cases)
    public static int CalLargestRectangleArea(int[] histogram)
    {
        Stack<int> stack = new Stack<int>();
        int curMaxArea = 0;
        int n = histogram.Length;

        for (int i = 0; i <= n; i++)
        {
            int curHeight = (i == n) ? 0 : histogram[i];

            while (stack.Count > 0 && curHeight < histogram[stack.Peek()])
            {
                int height = histogram[stack.Pop()];
                int width = 0;

                if (stack.Count == 0)
                {
                    width = i;
                }
                else
                {
                    width = i - stack.Peek() - 1;
                }

                curMaxArea = Math.Max(curMaxArea, height * width);
            }

            stack.Push(i);
        }

        return curMaxArea;
    }
}