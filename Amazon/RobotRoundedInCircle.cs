using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_and_Data_Structures.Amazon
{
	/*
	 * On an infinite plane, a robot initially stands at (0, 0) and faces north. The robot can receive one of three instructions:

		"G": go straight 1 unit;
		"L": turn 90 degrees to the left;
		"R": turn 90 degrees to the right.
		The robot performs the instructions given in order, and repeats them forever.

Return true if and only if there exists a circle in the plane such that the robot never leaves the circle.
	 */
	public class RobotRoundedInCircle
	{
		//LEFT TURN - XOR
		//going !I by X if it was Vertical before INCR
		//going !I by Y it was !Vertical before  !INCR
		//going I  by X it was vertical before   !INCR
		//going I by Y it was !Vertical before   INCR

		//IT IS XOR
		//1 => 1 / 1
		//1 => 0/ 0 
		//0 => 1 / 0 OR 
		//0 => 0 / 1 OR

		//RIGHT TURN - not XOR - opposite
		//1 => 1 / 1
		//1 => 0/ 0 
		//0 => 1 / 0 OR 
		//0 => 0 / 1 OR

		public bool IsRobotBounded(string instructions)
		{
			int x = 0;
			int y = 0;
			int totalRuns = 4; //we need at least 4 runs to determine if that is a circle

			bool goingVer = true;
			bool goingIncr = true;

			for (int run = 0; run < totalRuns; run++)
			{
				for (int i = 0; i < instructions.Length; i++)
				{
					switch (instructions[i])
					{
						case 'G': //completed
							if (goingVer)
								y += (goingIncr ? 1 : -1);
							else
								x += (goingIncr ? 1 : -1);
							break;
						case 'L':
							goingIncr = goingIncr ^ goingVer; //XOR
							goingVer = !goingVer;
							break;
						case 'R':
							goingIncr = !(goingIncr ^ goingVer); //NOT XOR
							goingVer = !goingVer;
							break;
					}
				}
				if (run == 0 && x == 0 && y == 0) return true; //made circle after one run
				if (run == 1 && x == 0 && y == 0) return true; //made circle after two runs
			}
			return x == 0 && y == 0; //made circle after all runs
		}

	}
}
