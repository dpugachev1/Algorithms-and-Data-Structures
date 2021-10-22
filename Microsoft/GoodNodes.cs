using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_and_Data_Structures.Microsoft
{
    public class GoodNodes
    {
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

        public int GoodNodesCalc(TreeNode root)
        {
            //just traverse a tree
            return TreeTraverse(root, int.MinValue, 0);
        }

        public int TreeTraverse(TreeNode node, int maxValInPath, int iGoodNodes)
        {
            if (node == null) return iGoodNodes; //backtrack when end is reached

            if (node.val >= maxValInPath) //if current node is above maximum value in this path
                iGoodNodes++;
            maxValInPath = Math.Max(maxValInPath, node.val); //recalculate maximum
                                                             //recursively traverse left nodes
            iGoodNodes = TreeTraverse(node.left, maxValInPath, iGoodNodes);
            //recursively traverse right nodes
            iGoodNodes = TreeTraverse(node.right, maxValInPath, iGoodNodes);

            return iGoodNodes;
        }
    }
}
