using System.Text;

class Solution
{
    public static void Main(string[] args)
    {
        TreeNode root = new TreeNode(
            1,
            new TreeNode(2,
                new TreeNode(4),
                new TreeNode(5)),
            new TreeNode(3,
                new TreeNode(6)));

        Console.WriteLine(MaxProduct(root));
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


    static long totalSum = 0;
    static long maxProd = 0;
    static int mod = 1000000007;

    public static int MaxProduct(TreeNode root)
    {
        //Cal total sum
        totalSum = SubTreeSum(root);

        //Re-process to calculate sub tree sum
        SubTreeSum(root);
        return (int)(maxProd % mod);
    }

    public static long SubTreeSum(TreeNode node)
    {
        if (node == null)
            return 0;
        //Cal sub of sub tree
        long subSum = node.val + SubTreeSum(node.left) + SubTreeSum(node.right);

        //Check max production.
        if (totalSum > 0)
        {
            maxProd = Math.Max(maxProd, subSum * (totalSum - subSum));
        }

        return subSum;
    }
}