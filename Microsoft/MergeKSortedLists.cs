using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_and_Data_Structures.Microsoft
{
    public class MergeKSortedLists
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public ListNode MergeKLists(ListNode[] lists)
        {
            //use sorted dictionary, its insertion time is O(logn), so total time complexity is kn * O(logn) + O(kn)
            //also additional memory is O(kn)
            SortedDictionary<int, int> sortedValues = new SortedDictionary<int, int>();
            ListNode currentNode = null;
            for (int i = 0; i < lists.Length; i++)
            {
                currentNode = lists[i];
                while (currentNode != null)
                {
                    AddItemToDictionary(sortedValues, currentNode.val); //just add it to dictionary
                    currentNode = currentNode.next;
                }
            }
            ListNode resultNode = null;
            currentNode = null;
            //then loop thru every element and add it to the result
            foreach (var kvp in sortedValues)
            {
                for (int i = 0; i < kvp.Value; i++)
                {
                    if (currentNode == null)
                    {
                        currentNode = new ListNode(kvp.Key, null);
                        resultNode = currentNode;
                    }
                    else
                    {
                        currentNode.next = new ListNode(kvp.Key, null);
                        currentNode = currentNode.next;
                    }
                }
            }
            return resultNode;
        }

        //O(logn) to insert an new value
        private void AddItemToDictionary(SortedDictionary<int, int> dict, int val)
        {
            if (!dict.ContainsKey(val))
                dict.Add(val, 0);
            dict[val]++;
        }


        public ListNode MergeKListsCompareOneByOne(ListNode[] lists)
        {
            int min_index = 0;
            ListNode head = new ListNode(0);
            ListNode currentNode = head;
            while (true)
            {
                bool isBreak = true;
                int min = int.MaxValue;
                for (int i = 0; i < lists.Length; i++)
                {
                    if (lists[i] != null)
                    {
                        if (lists[i].val < min) //finding min value of all nodes
                        {
                            min_index = i;
                            min = lists[i].val;
                        }
                        isBreak = false;
                    }

                }
                if (isBreak)
                    break;
                /* not in place solution
                ListNode a = new ListNode(lists[min_index].val);
                currentNode.next = a;
                */
                currentNode.next = lists[min_index]; //in place
                currentNode = currentNode.next; //currentNode is recently added one
                lists[min_index] = lists[min_index].next; //moving min node to next node
            }
            currentNode.next = null; //do not forget to unlink the last node
            return head.next; //return head.next because it is a pointer to a first node in our list
        }
    }
}