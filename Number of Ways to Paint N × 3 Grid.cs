using System.Text;

class Solution
{
    public static void Main(string[] args)
    {
        int n = 6;
        Console.WriteLine(NumOfWays(n));
    }

    public static int NumOfWays(int n)
    {
        long mod = 1000000007;
        //Color Pattern of matrix nx3 is XYX or XYZ (Each char represents for 1 color)
        long xyx = 6; //the number of XYX in 1x3 matrix
        long xyz = 6; //the number of XYZ in 1x3 matrix

        long nextXYX = 0;
        long nextXYZ = 0;
        //For XYX pattern the below 1x3 matrix will have 3 other XYX and 2 XYZ
        //For XYZ pattern the below 1x3 matrix will have 2 other XYZ and 2 XYX
        for (int i = 1; i < n; i++)
        {
            nextXYX = (3 * xyx + 2 * xyz) % mod;
            nextXYZ = (2 * xyx + 2 * xyz) % mod;

            xyx = nextXYX;
            xyz = nextXYZ;
        }

        return (int)((xyx + xyz) % mod);
    }
}