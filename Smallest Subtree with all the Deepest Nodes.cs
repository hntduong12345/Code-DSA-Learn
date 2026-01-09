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
        Console.WriteLine(SubtreeWithAllDeepest(root));
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

    public static TreeNode SubtreeWithAllDeepest(TreeNode root)
    {
        return DFS(root).node;
    }

    public static Result DFS(TreeNode node)
    {
        if (node == null)
            return new Result(null, 0);

        Result leftSide = DFS(node.left);
        Result rightSide = DFS(node.right);

        if (leftSide.dist > rightSide.dist)
            return new Result(leftSide.node, leftSide.dist + 1);

        if (rightSide.dist > leftSide.dist)
            return new Result(rightSide.node, rightSide.dist + 1);

        return new Result(node, leftSide.dist + 1);
    }

    public class Result
    {
        public TreeNode node;
        public int dist;
        public Result(TreeNode n, int d)
        {
            node = n;
            dist = d;
        }
    }
}