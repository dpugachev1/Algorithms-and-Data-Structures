using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_and_Data_Structures.Google
{
    public class OptimalAccountBalancing
    {
        public int MinTransfers(int[][] transactions)
        {

            int[] debts = new int[21];
            //calculating final balances 
            for (int i = 0; i < transactions.Length; i++)
            {
                debts[transactions[i][0]] += transactions[i][2] * -1;
                debts[transactions[i][1]] += transactions[i][2] * 1;
            }
            //sort the results -> negative to the left, positive to the right
            Array.Sort(debts);

            debts = new int[] { -100, -100, -50, -10, 50, 60, 150 };
            int minTransfers = helper(debts, debts.Length - 1);
            return minTransfers == int.MaxValue ? 0 : minTransfers;
        }

        private int helper(int[] balance, int index)
        {
            // we stop when we know that there is no positive balance sleft in the array, array is sorted so if last element is 0 then calculation is complete
            if (balance[index] == 0)
            {
                return 0;
            }

            int min = int.MaxValue;
            int prevBalanceAtI;
            int prevBalanceAtIndex;
            //backtracking to get global minimum number of transactions
            for (int i = 0; i < index; i++) //check all possible negative combination
                //index is a current person we are trying to settle
                //with mininum number of transactions
            {
                //One concern is, what if the optimal solution is not for a person returning all his debt to another person,
                //but returning his debt to multiple people?
                if (balance[i] < 0)
                {
                    prevBalanceAtI = balance[i];
                    prevBalanceAtIndex = balance[index];
                    if (Math.Abs(balance[i]) >= balance[index])
                    {
                        balance[i] += balance[index];
                        balance[index] = 0;
                    }
                    else
                    {
                        balance[index] += balance[i];
                        balance[i] = 0;
                    }
                    if (balance[index] == 0)
                    {
                        min = Math.Min(min, 1 + helper(balance, index - 1));
                    }
                    else
                    {
                        min = Math.Min(min, 1 + helper(balance, index));
                    }
                    balance[index] = prevBalanceAtIndex;
                    balance[i] = prevBalanceAtI;
                }

            }
            return min;
        }
    }
}
