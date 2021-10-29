using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_and_Data_Structures.Microsoft
{
    public class CopyListWithRandomPointer
    {
        public class Node
        {
            public int val;
            public Node next;
            public Node random;

            public Node(int _val)
            {
                val = _val;
                next = null;
                random = null;
            }
        }
        public Node CopyRandomList(Node head)
        {

            Node origHead = head;

            Node result = new Node(0);
            Node h = result;
            Dictionary<Node, Node> dcOrigToCreatedMapping = new Dictionary<Node, Node>();

            while (head != null)
            {
                result.next = new Node(head.val);
                dcOrigToCreatedMapping.Add(head, result.next); //add nodes with index
                head = head.next;
                result = result.next;
            }
            result.next = null; //last element

            head = origHead; //back to 0 element
            result = h.next; //back to 0 element

            while (head != null) //set randoms, number of loops is the same for both lists
            {
                //pull random from mappings
                result.random = head.random == null ? null : dcOrigToCreatedMapping[head.random];

                head = head.next;
                result = result.next;
            }

            return h.next; //result head
        }
    }
}
