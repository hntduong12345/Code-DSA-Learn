using System.Text;

class Solution
{
    public static void Main(string[] args)
    {
        int[] nums = [1, 2, 3, 4, 5, 6];

        Console.WriteLine(MinimumPairRemoval(nums));
    }
    // Node class representing an element in the Doubly Linked List
    public class Node
    {
        public long Value;
        public int Index; // Original index, used for tie-breaking
        public Node Prev;
        public Node Next;
        public bool IsMerged; // Flag for lazy deletion

        public Node(long value, int index)
        {
            Value = value;
            Index = index;
            IsMerged = false;
        }
    }

    // Helper class for Priority Queue items
    public class PQItem : IComparable<PQItem>
    {
        public long Sum;
        public int Index; // Index of the left node in the pair
        public Node LeftNode;
        public Node RightNode;

        public PQItem(long sum, int index, Node left, Node right)
        {
            Sum = sum;
            Index = index;
            LeftNode = left;
            RightNode = right;
        }

        public int CompareTo(PQItem other)
        {
            // 1. Compare by Sum (smallest first)
            int sumCmp = Sum.CompareTo(other.Sum);
            if (sumCmp != 0) return sumCmp;

            // 2. Compare by Index (leftmost first)
            return Index.CompareTo(other.Index);
        }
    }



    public static int MinimumPairRemoval(int[] nums)
    {
        int n = nums.Length;
        if (n < 2) return 0;

        // 1. Initialize Linked List and Priority Queue
        Node head = new Node(nums[0], 0);
        Node curr = head;

        var pq = new PriorityQueue<PQItem, PQItem>();

        int decreaseCount = 0; // Tracks number of unsorted adjacent pairs (prev > curr)

        for (int i = 1; i < n; i++)
        {
            Node newNode = new Node(nums[i], i);

            // Link nodes
            curr.Next = newNode;
            newNode.Prev = curr;

            // Check if this pair breaks the sorting order
            if (curr.Value > newNode.Value)
            {
                decreaseCount++;
            }

            // Add pair to PQ
            long sum = curr.Value + newNode.Value;
            var item = new PQItem(sum, curr.Index, curr, newNode);
            pq.Enqueue(item, item);

            curr = newNode;
        }

        int operations = 0;

        // 2. Process Pairs until sorted (decreaseCount == 0)
        while (decreaseCount > 0 && pq.Count > 0)
        {
            // Get the pair with the smallest sum
            PQItem bestPair = pq.Dequeue();
            Node left = bestPair.LeftNode;
            Node right = bestPair.RightNode;

            if (left.IsMerged || right.IsMerged) continue;

            // Mark nodes as merged
            left.IsMerged = true;
            right.IsMerged = true;
            operations++;

            // Create the new merged node
            long newSum = left.Value + right.Value;
            Node newNode = new Node(newSum, left.Index);

            if (left.Value > right.Value)
            {
                decreaseCount--;
            }

            Node prev = left.Prev;
            if (prev != null)
            {
                // Did we remove a violation between Prev and Left?
                if (prev.Value > left.Value) decreaseCount--;

                // Did we create a violation between Prev and NewNode?
                if (prev.Value > newNode.Value) decreaseCount++;

                // Link Prev <-> NewNode
                prev.Next = newNode;
                newNode.Prev = prev;

                // Add new pair to heap
                long s = prev.Value + newNode.Value;
                var item = new PQItem(s, prev.Index, prev, newNode);
                pq.Enqueue(item, item);
            }

            Node next = right.Next;
            if (next != null)
            {
                // Did we remove a violation between Right and Next?
                if (right.Value > next.Value) decreaseCount--;

                // Did we create a violation between NewNode and Next?
                if (newNode.Value > next.Value) decreaseCount++;

                // Link NewNode <-> Next
                newNode.Next = next;
                next.Prev = newNode;

                // Add new pair to heap
                long s = newNode.Value + next.Value;
                var item = new PQItem(s, newNode.Index, newNode, next);
                pq.Enqueue(item, item);
            }
        }

        return operations;
    }
}