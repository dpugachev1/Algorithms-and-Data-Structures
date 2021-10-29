using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_and_Data_Structures.LeetCode
{
    public class IntersecrionOfLinkedLists
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {

            HashSet<ListNode> visitedNodes = new HashSet<ListNode>();
            ListNode p = headA;
            ListNode p2 = headB;
            while (p != null) //store every node in hashset
            {
                visitedNodes.Add(p);
                p = p.next;
            }
            while (p2 != null) //check if node is in the first hashset
            {
                if (visitedNodes.Contains(p2))
                    return p2;
                p2 = p2.next;
            }
            return null;
        }

        public ListNode GetIntersectionNodeFastest(ListNode headA, ListNode headB)
        {

            ListNode pA = headA;
            ListNode pB = headB;
            while (pA != pB)
            {
                pA = pA == null ? headB : pA.next;
                pB = pB == null ? headA : pB.next;
            }
            return pA;
        }
    }
}
