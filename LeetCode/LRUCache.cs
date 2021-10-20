using System.Collections.Generic;

namespace Algorithms_and_Data_Structures.LeetCode
{
    /**
     * Your LRUCache object will be instantiated and called as such:
     * LRUCache obj = new LRUCache(capacity);
     * int param_1 = obj.Get(key);
     * obj.Put(key,value);
     */
    public class LRUCache
	{
        LinkedList<int[]> _usage;
        Dictionary<int, LinkedListNode<int[]>> _cache;
        int iCapacity = 0;

        public LRUCache(int capacity)
        {
            iCapacity = capacity;
            _cache = new Dictionary<int, LinkedListNode<int[]>>(iCapacity);
            _usage = new LinkedList<int[]>();
        }

        public int Get(int key)
        {
            if (!_cache.ContainsKey(key)) return -1; //does not exist


            LinkedListNode<int[]> node = _cache[key]; //get node
            PutNodeToTheEnd(node, false); //put it to the end
            return node.Value[1]; //return its value
        }

        public void Put(int key, int value)
        {
            if (_cache.ContainsKey(key))
            {
                LinkedListNode<int[]> node = _cache[key]; //get node
                node.Value[1] = value; //update value
                PutNodeToTheEnd(node, false); //put it to the end
            }
            else
            {
                

                if (_cache.Count == iCapacity) //if capacity is reached
                {
                    LinkedListNode<int[]> firstNode = _usage.First; //lowest priority key
                    _cache.Remove(firstNode.Value[0]);//remove key
                    _usage.RemoveFirst(); //remove from usage


                }

                LinkedListNode<int[]> newnode = new LinkedListNode<int[]>(new int[] {key,value});
                PutNodeToTheEnd(newnode, true);
                _cache.Add(key, newnode);

            }
        }

        private void PutNodeToTheEnd(LinkedListNode<int[]> node, bool newOne)
        {
            if (!newOne)
                _usage.Remove(node); //remove it
            _usage.AddLast(node); //add it to the end
        }
    }
}
