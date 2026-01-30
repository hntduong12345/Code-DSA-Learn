public class Solution
{
    public int[][] FlipAndInvertImage(int[][] image)
    {
        int n = image.Length;
        int temp = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j <= n / 2; j++)
            {
                if (j <= n - 1 - j)
                {
                    temp = image[i][j];
                    image[i][j] = image[i][n - 1 - j] == 1 ? 0 : 1;
                    image[i][n - 1 - j] = temp == 1 ? 0 : 1;
                }
            }
        }

        return image;
    }
}