using System.Text;

namespace Algorithms_and_Data_Structures.Microsoft
{


    public class TreeNode {
          public int val;
          public TreeNode left;
          public TreeNode right;
          public TreeNode(int x) { val = x; }
      }
     
    public class SerializeDeserializeBinaryTree
    {

        private StringBuilder serializer;
        private int index;

        public SerializeDeserializeBinaryTree()
        {
            serializer = new StringBuilder();
        }

        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            TraverseTree(root);
            string result = serializer.ToString();
            serializer.Clear();
            return result;
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            if (string.IsNullOrEmpty(data) || data == "x;") return null; //avoid empty values
            string[] split = data.Split(new char[] { ';' }); //we use ; as a deliveter
            TreeNode result = UntraverseTree(split);
            index = 0;
            return result;
        }

        public void TraverseTree(TreeNode node)
        {
            //use DFS for serialization to avoid multiple nulls in the result if tree is unbalanced
            if (node == null)
            {
                serializer.Append("x");
                serializer.Append(";");
                return;
            }
            serializer.Append(node.val);
            serializer.Append(";");
            TraverseTree(node.left);
            TraverseTree(node.right);
        }

        public TreeNode UntraverseTree(string[] data)
        {
            if (data.Length == index) return null; //end reached
                                                   //create current node
            TreeNode node = new TreeNode(int.Parse(data[index]));
            //incrementing index by one will check left node in the array
            if (data[++index] == "x")
                node.left = null;
            else
                node.left = UntraverseTree(data);
            //incrementing index by one more (+2 total) will check right node in the array
            if (data[++index] == "x")
                node.right = null;
            else
                node.right = UntraverseTree(data);
            return node;
        }
    }

}
