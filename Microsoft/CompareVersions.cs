using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_and_Data_Structures.Microsoft
{
    public class CompareVersions
    {
        public int CompareVersion(string version1, string version2)
        {
            string[] ver1 = version1.Split(new char[] { '.' });
            string[] ver2 = version2.Split(new char[] { '.' });
            int n = Math.Max(ver1.Length, ver2.Length);
            int subVer1 = 0;
            int subVer2 = 0;
            for (int i = 0; i < n; i++)
            {
                //if level not exists then it is 0
                subVer1 = (i < ver1.Length) ? int.Parse(ver1[i]) : 0;
                subVer2 = (i < ver2.Length) ? int.Parse(ver2[i]) : 0;
                if (subVer1 == subVer2)
                    continue; //check the next version level
                return (subVer1 > subVer2) ? 1 : -1;
            }
            return 0;
        }
    }
}
