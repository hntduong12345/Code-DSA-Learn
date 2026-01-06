using System.Text;

class Solution
{
    public static void Main(string[] args)
    {
        TreeNode root = new TreeNode(1,
            new TreeNode(7,
                new TreeNode(7),
                new TreeNode(-8)),
            new TreeNode(0));
        Console.WriteLine(MaxLevelSum(root));
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public static int MaxLevelSum(TreeNode root)
    {
        Queue<TreeNode> nodeQueue = new Queue<TreeNode>();
        nodeQueue.Enqueue(root);

        int childCount = 1;
        //Max sum and its level
        int maxSum = int.MinValue;
        int targetLevel = 0;
        // Current sum and level
        int curSum = 0;
        int curLevel = 1;

        int i = 0;
        TreeNode curNode = null;
        while (nodeQueue.Count > 0)
        {
            i = childCount;
            childCount = 0;
            while (i > 0)
            {
                curNode = nodeQueue.Dequeue();
                curSum += curNode.val;
                if (curNode.left != null)
                {
                    nodeQueue.Enqueue(curNode.left);
                    childCount++;
                }
                if (curNode.right != null)
                {
                    nodeQueue.Enqueue(curNode.right);
                    childCount++;
                }
                i--;
            }

            if (curSum > maxSum)
            {
                maxSum = curSum;
                targetLevel = curLevel;
            }

            curLevel++;
            curSum = 0;
        }

        return targetLevel;
    }
}