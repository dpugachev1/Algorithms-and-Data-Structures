using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_and_Data_Structures.Microsoft
{
    public class Max_Stack
    {
        class Node //use double-linked list for storage
        {
            public Node(int val, Node prev, Node next)
            {
                this.val = val;
                this.prev = prev;
                this.next = next;
            }
            public int val { get; set; }
            public Node prev { get; set; }
            public Node next { get; set; }
        }

        private Node head, max, top;

        public Max_Stack()
        {
            //initialize a head and start with it
            head = new Node(int.MinValue, null, null);
            max = head;
            top = head;
        }

        public void Push(int x)
        {
            Node node = new Node(x, top, null);
            top.next = node;
            top = node; //create node and change top pointer to it
            if (max.val <= x)
                max = node; //change max pointer in case node is greater than max
        }

        public int Pop()
        {
            bool isMax = (max == top); //if top element is max element
            int result = top.val;
            top.prev.next = null; //release pointer to current top
            top = top.prev; //move top one level down
            if (isMax)
                LocateMax(); //update max in case top was a max element
            return result;
        }

        public int Top()
        {
            return top.val;
        }

        public int PeekMax()
        {
            return max.val;
        }

        public int PopMax()
        {
            if (max == top)
                return Pop(); //pop top if it is max
            int result = max.val;
            max.prev.next = max.next;
            if (max.next != null)
                max.next.prev = max.prev;
            LocateMax(); //refresh max
            return result;
        }

        private void LocateMax()
        {
            Node h = head;
            max = h;
            while (h != null)
            {
                if (h.val >= max.val)
                    max = h;
                h = h.next;
            }
        }
    }
}
