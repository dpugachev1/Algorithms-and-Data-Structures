using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_and_Data_Structures.Microsoft
{
    public class MeetringRoomsII
    {
        public int MinMeetingRooms(int[][] intervals)
        {
            //split start and end dates to two different arrays
            int[] startDates = new int[intervals.Length];
            int[] endDates = new int[intervals.Length];
            for (int i = 0; i < intervals.Length; i++)
            {
                startDates[i] = intervals[i][0];
                endDates[i] = intervals[i][1];
            }
            //and sort them ascending
            Array.Sort(startDates);
            Array.Sort(endDates);

            int result = 0; //global number of rooms needed
            int iMinMeetingRooms = 0; //local number of rooms needed

            for (int i = 0, j = 0; i < startDates.Length; i++) //check each interval
            {
                //start incrementing number of rooms until any of room becomes vacant
                if (startDates[i] < endDates[j])
                {
                    iMinMeetingRooms++;
                }
                else//once room is vacant, end time is more than start time of next meeting
                {
                    //store result in global maximum
                    result = Math.Max(iMinMeetingRooms, result);
                    do
                    {
                        j++; //skip end times
                        iMinMeetingRooms--; //and decrease number of rooms
                    }
                    while (endDates[j] < startDates[i]); //until next meeting starts again
                    iMinMeetingRooms++; //do not forget to add a current room
                }
            }
            //always return either local or global maximum
            //because we can leave the loop once every start date is counted
            return Math.Max(iMinMeetingRooms, result);
        }
    }
}
