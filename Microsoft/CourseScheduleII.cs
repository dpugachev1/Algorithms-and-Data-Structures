using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_and_Data_Structures.Microsoft
{
    public class CourseScheduleII
    {
        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            /*
            //[[1,0],[2,0],[3,1],[3,2],[0,4]]
            //Create dictionary of destinations
            0 => 1, 2
            1 => 3
            2 => 3
            3 =>
            4 => 0
            Use number of inputs for each node
            [1, 1, 1, 2, 0]
            Push everything with 0 to queue 
            Queue => 4
            While queue is not empty
            Dequeue => decrease destinations in inputs array by one and push everything with 0 to the queue
            */
            Dictionary<int, List<int>> dictPrereq = new Dictionary<int, List<int>>(); //store all destinations for every node here
            int[] incoming = new int[numCourses]; //store number of incoming nodes for each node
            Queue<int> processingQueue = new Queue<int>(); //processing queue, only nodes with 0 incomings are here
            List<int> result = new List<int>();

            foreach (int[] prereq in prerequisites)
            {
                int dest = prereq[0];
                int src = prereq[1];

                if (!dictPrereq.ContainsKey(src))
                    dictPrereq.Add(src, new List<int>()); //add node to the list
                dictPrereq[src].Add(dest); //add destination to that node

                incoming[dest]++; //increment number of inc nodes for that destination
            }
            for (int i = 0; i < incoming.Length; i++) //add first candidates to processing queue
                if (incoming[i] == 0)
                    processingQueue.Enqueue(i);

            while (processingQueue.Count > 0)
            {
                //dequeue and add to the list
                int node = processingQueue.Dequeue();
                result.Add(node);

                if (!dictPrereq.ContainsKey(node)) //doesn't have any destinations
                    continue;

                foreach (int adjNode in dictPrereq[node])
                {
                    incoming[adjNode]--; //decrement incoming by 1 of adj node
                    if (incoming[adjNode] == 0)
                        processingQueue.Enqueue(adjNode); //if no more incomings add to the processing queue
                }
            }
            int[] iresult = result.ToArray();
            return iresult.Length < numCourses ? new int[0] : iresult;
        }
    }
}
