using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_and_Data_Structures.Microsoft
{
    public class TicTacToe
    {
        private int size;
        private int[] rowPoints;
        private int[] colPoints;
        private int lDiagPoints;
        private int rDiagPoints;

        public TicTacToe(int n)
        {
            size = n;
            rowPoints = new int[size]; //check number of points in each row
            colPoints = new int[size]; //check number of points in each column
        }

        public int Move(int row, int col, int player)
        {
            //use +1 point for player 1 and -1 for player 2
            int point = (player == 1) ? 1 : -1;
            //check row
            if (CheckMove(rowPoints, row, point)) return player;
            //check column
            if (CheckMove(colPoints, col, point)) return player;
            //check left diagonal
            if (row == col)
            {
                lDiagPoints += point;
                if (lDiagPoints * point == size) return player;
            }
            //check right diagonal
            if (row == size - col - 1)
            {
                rDiagPoints += point;
                if (rDiagPoints * point == size) return player;
            }
            return 0;
        }

        private bool CheckMove(int[] arr, int position, int point)
        {
            arr[position] += point; //increment a point
            //if size is reached - it is a win
            //only reachable if only one players is constantly putting points to this row/column
            if (arr[position] * point == size) return true;
            return false;
        }
    }
}
