using System.Collections.Generic;

namespace Algorithms_and_Data_Structures.Google
{
    public class MinimumNumberOfRefuelingStops
    {

        public class ObjectPosition
        {
            public ObjectPosition(int pos, int fuel, int stopsVisited, int carfuel)
            {
                CarFuelLevel = carfuel;
                Position = pos;
                FuelLevel = fuel;
                StopsVisited = stopsVisited;
            }
            public int Position { get; set; }
            public int FuelLevel { get; set; }
            public int StopsVisited { get; set; }
            public int CarFuelLevel { get; set; }

        }

        public int MinRefuelStops(int target, int startFuel, int[][] stations)
        {

            ObjectPosition currentStop;
            Queue<ObjectPosition> bfsQueue = new Queue<ObjectPosition>();

            int itotalStations = stations.Length;
            int carLevel = 0;
            int minStops = -1;
            int startFromStation = 0;

            bfsQueue.Enqueue(new ObjectPosition(0, 0, 0, startFuel));
            /*it cannot be reached without refueling*/
            while (bfsQueue.Count > 0)
            {
                currentStop = bfsQueue.Dequeue();
                //Console.WriteLine("stop position " + currentStop.Position +  " car fuel " + currentStop.CarFuelLevel +  " stops " + currentStop.StopsVisited);
                /*we reached end*/
                if (currentStop.Position + currentStop.CarFuelLevel + currentStop.FuelLevel >= target)
                {
                    // Console.WriteLine("stop position " + currentStop.Position +  " car fuel " + currentStop.CarFuelLevel +  " stops " + currentStop.StopsVisited);
                    //return currentStop.StopsVisited;
                    if (minStops > currentStop.StopsVisited || minStops == -1)
                        minStops = currentStop.StopsVisited;
                    return minStops;
                }

                for (int i = 0; i < stations.Length; i++) //go thru all available stations from that point
                {
                    if (currentStop.Position >= stations[i][0]) continue; /*skip previous TO-DO improvement*/

                    carLevel = currentStop.CarFuelLevel + currentStop.FuelLevel - (stations[i][0] - currentStop.Position);

                    if (carLevel >= 0)
                    {
                        startFromStation = i;
                        int stops = currentStop.StopsVisited + 1;
                        var position = new ObjectPosition(stations[i][0], stations[i][1], stops, carLevel);
                        bfsQueue.Enqueue(position);
                    }
                }
            }

            return minStops; /*cannot reach it*/

        }
    }
}
