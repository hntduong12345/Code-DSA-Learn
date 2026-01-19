using System.Text;

class Solution
{
    public static void Main(string[] args)
    {
        int[][] logs = [[0, 3], [2, 5], [0, 9], [1, 15]];
        int n = 10;

        Console.WriteLine(HardestWorker(n, logs));
    }

    public static int HardestWorker(int n, int[][] logs)
    {
        int curDur = 0, maxDur = 0, curTime = 0;
        int targetEmp = n;
        for (int i = 0; i < logs.Length; i++)
        {
            curDur = logs[i][1] - curTime;
            curTime = logs[i][1];
            if (maxDur < curDur)
            {
                maxDur = curDur;
                targetEmp = logs[i][0];
            }
            else if (maxDur == curDur && targetEmp > logs[i][0])
            {
                targetEmp = logs[i][0];
            }
        }

        return targetEmp;
    }
}