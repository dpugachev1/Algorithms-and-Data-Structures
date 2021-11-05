using System.Collections.Generic;

namespace Algorithms_and_Data_Structures.Microsoft
{
    public class LRUCache
    {

        //we keep max capacity to check if we need to remove the first element after we put()
        private int maxCapacity = 0;
        //we store here the list of keys and pointers to nodes in our "queue" list
        private Dictionary<int, LinkedListNode<int[]>> dictNodes;
        //queue "list", first element is least used, int[] is because we need to store both key to the dictionary and value of element
        private LinkedList<int[]> lruCache;

        public LRUCache(int capacity)
        {
            maxCapacity = capacity;
            dictNodes = new Dictionary<int, LinkedListNode<int[]>>(capacity);
            lruCache = new LinkedList<int[]>();
        }

            public int Get(int key)
        {
            if (!dictNodes.ContainsKey(key)) return -1;
            //if already exists - get node
            LinkedListNode<int[]> node = dictNodes[key];
            lruCache.Remove(node); //remove from whatever location in our queue
            lruCache.AddLast(node); //and add it to the end
            return node.Value[1]; //second is it's value
        }

        public void Put(int key, int value)
        {
            if (!dictNodes.ContainsKey(key)) //if value does not exist in LRU
            {
                if (lruCache.Count == maxCapacity) //if we reached max capacity remove least used element
                {
                    LinkedListNode<int[]> firstnode = lruCache.First;
                    dictNodes.Remove(firstnode.Value[0]); //first is key
                    lruCache.RemoveFirst();
                }
                //add node both to the dictionary and to the list
                LinkedListNode<int[]> node = new LinkedListNode<int[]>(new int[] { key, value });
                lruCache.AddLast(node);
                dictNodes.Add(key, node);
            }
            else //if value does exist in LRU just push it to the end
            {
                LinkedListNode<int[]> foundNode = dictNodes[key];
                foundNode.Value[1] = value; //update its value
                lruCache.Remove(foundNode);
                lruCache.AddLast(foundNode); //add last will change a pointer, do not need to remove node first
            }
        }
    }
}
