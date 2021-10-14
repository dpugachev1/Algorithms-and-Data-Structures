using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_and_Data_Structures.Google
{
    public class TimeBasedKeyValueStorage
    {
        public class TimeStampValue
        {
            public TimeStampValue(int time, string val)
            {
                this.TimeStamp = time;
                this.Value = val;
            }
            public int TimeStamp { get; set; }
            public string Value { get; set; }
        }

        private Dictionary<string, List<TimeStampValue>> dictTimeMaps;

        public TimeBasedKeyValueStorage()
        {
            dictTimeMaps = new Dictionary<string, List<TimeStampValue>>();
        }

        public void Set(string key, string value, int timestamp)
        {

            if (!dictTimeMaps.ContainsKey(key))
                dictTimeMaps.Add(key, new List<TimeStampValue>());

            dictTimeMaps[key].Add(new TimeStampValue(timestamp, value));


        }

        public string Get(string key, int timestamp)
        {

            if (!dictTimeMaps.ContainsKey(key)) return "";
            /* binary search */
            int mid = 0;
            int left = 0;
            int right = dictTimeMaps[key].Count - 1;
            List<TimeStampValue> timeStamps = dictTimeMaps[key];
            if (timeStamps[left].TimeStamp == timestamp) return timeStamps[left].Value;

            while (left < right)
            {
                /*border cases */
                if (timeStamps[left].TimeStamp == timestamp) return timeStamps[left].Value;
                if (timestamp < timeStamps[left].TimeStamp) return "";
                if (timestamp >= timeStamps[right].TimeStamp) return timeStamps[right].Value;

                mid = (int)((right - left) / 2);

                if (timeStamps[mid].TimeStamp == timestamp) return timeStamps[mid].Value;

                if (timestamp > timeStamps[mid].TimeStamp)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            if (left - 1 < 0)
                return timeStamps[0].Value;
            return timeStamps[left - 1].Value;
        }
    }
}
