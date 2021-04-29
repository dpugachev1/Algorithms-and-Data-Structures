using System.Collections.Generic;

namespace Algorithms_and_Data_Structures.LeetCode
{
    public static class AddTwoNumbersClass
	{
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            Queue<int> sResult = new Queue<int>();
            int iRemainder = 0;
            int num1 = 0;
            int num2 = 0;
            int sum = 0;

            while (true)
            {
                if (l1 == null && l2 == null) break;
                //trying to get first one
                if (l1 != null)
                {
                    num1 = l1.val;
                    l1 = l1.next;
                }
                else
                    num1 = 0;

                if (l2 != null)
                {
                    num2 = l2.val;
                    l2 = l2.next;
                }
                else
                    num2 = 0;

                sum = num1 + num2;

                int iResult = sum + iRemainder;

                sResult.Enqueue(iResult % 10);


                iRemainder = 0;
                if (iResult >= 10)
                {
                    iRemainder = 1;
                }
            }
            if (iRemainder == 1)
            {
                sResult.Enqueue(iRemainder); 
            }


            ListNode header = new ListNode(sResult.Dequeue());

            ListNode a = AddListNode(sResult, header);

            return a;
        }

        public static ListNode AddListNode(Queue<int> stack, ListNode node)
        {
            if (stack.Count == 0) return node;
            if (node.next == null) node.next = new ListNode(stack.Dequeue());
            AddListNode(stack, node.next);
            return node;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;


            public ListNode(int x) { val = x; }
        }

    }
}
