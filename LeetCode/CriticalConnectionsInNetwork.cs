using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_and_Data_Structures.LeetCode
{
	public class CriticalConnectionsInNetwork
	{
		private IList<IList<int>> bridges;
		Dictionary<int, List<int>> dictConnections;
		int iCurrentTime = 0;


		/// <summary>
		/// Input: n = 4, connections = [[0,1],[1,2],[2,0],[1,3]]
		/// </summary>
		/// <param name="n"></param>
		/// <param name="connections"></param>
		/// <returns></returns>
		public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections)
		{
			dictConnections = new Dictionary<int, List<int>>();
			bridges = new List<IList<int>>();

			//store all connections in hashtable to be able to access all connected vertexes based on a current one
			foreach (IList<int> connection in connections) 
			{
				if (!dictConnections.ContainsKey(connection[0]))
				{
					dictConnections.Add(connection[0], new List<int>());
				}
				dictConnections[connection[0]].Add(connection[1]);

				if (!dictConnections.ContainsKey(connection[1]))
				{
					dictConnections.Add(connection[1], new List<int>());
				}
				dictConnections[connection[1]].Add(connection[0]);
			}

			int[] Times = new int[n];
			int[] MinTimes = new int[n];
			

			DFS(connections[0][0], -1, Times, MinTimes); //first key

			return bridges;
		}

		private void DFS(int current, int parent, int[] times, int[] minTimes)
		{
			times[current] = ++iCurrentTime;  //entered unvisited vertex
			minTimes[current] = iCurrentTime;  //entered unvisited vertex, minTime is current one

			//check all vertexes except parent one
			foreach (int childVertex in dictConnections[current])
			{
				//if not visited
				if (times[childVertex] == 0 && childVertex != parent)
				{
					//visit it
					DFS(childVertex, current, times, minTimes);
				}
				//if visited and min time is less than current one
				if (times[childVertex] > 0 && childVertex != parent && minTimes[current] > minTimes[childVertex])
				{
					minTimes[current] = minTimes[childVertex];
				}
			}
			//no more children - check if this is a bridge or not

			if (parent >= 0 && minTimes[current] > times[parent])//this is a bridge
			{
				bridges.Add(new List<int>( new int[] { parent, current }));
			}

		}

	}
}
