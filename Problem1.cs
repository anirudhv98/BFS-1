// Time Complexity : O(n)
// Space Complexity : O(Width of tree) = Maximum size of elements that can be present in the queue
// Did this code successfully run on Leetcode : Yes
// Any problem you faced while coding this : No


// Your code here along with comments explaining your approach

/*
    If root is null I return the resultant list of integer lists as it is. If not, I enqueue the root node to a queue. I iterate through the tree nodes while the queue is not empty for i = size of 
    queue times. This allows me to distinguish between levels of the tree. For each node in the queue, I dequeue it and add it's value to the temp list. If it has any left or right child, I add them
    to the queue. At the end of the inner for loop, I add the temporary list to the final resultant list.
*/

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution
{
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        List<IList<int>> result = new();

        if (root == null)
        {
            return result;
        }

        Queue<TreeNode> q = new();

        q.Enqueue(root);

        while (q.Count > 0)
        {
            int size = q.Count;

            List<int> tempList = new();

            for (int i = 0; i < size; i++)
            {
                TreeNode temp = q.Dequeue();
                tempList.Add(temp.val);

                if (temp.left != null)
                {
                    q.Enqueue(temp.left);
                }

                if (temp.right != null)
                {
                    q.Enqueue(temp.right);
                }
            }

            result.Add(tempList);
        }

        return result;
    }
}