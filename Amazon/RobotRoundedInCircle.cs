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
		public bool IsRobotBounded(string instructions)
		{
			bool isCircle = false;
			int x = 0;
			int y = 0;

			bool isXpositive = true;
			bool isYpositive = true;

			bool isVerticalMovement = true;

			for (int i = 0; i < instructions.Length; i++)
			{
				switch (instructions[i])
				{
					case 'G': //DONE
						if (isVerticalMovement) 
							x += (isXpositive ? 1 : -1);
						else
							y += (isYpositive ? 1 : -1);
						break;

					case 'L': //LEFT turn
						if (isVerticalMovement)
						{
							isVerticalMovement = !isXpositive; //horizontal
							isYpositive = !isXpositive;
						}
						
						break;
					case 'R':
						break;
				}
			}
			return isCircle;
		}

	}
}
