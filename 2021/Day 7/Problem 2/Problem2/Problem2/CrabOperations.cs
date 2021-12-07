using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem2
{
    public class CrabOperations
    {
        public long CostOfGasMovingToPosition(List<IGrouping<int,int>> crabs,int position)
        {
            long gasUsedToMoveToPosition = new long();
            foreach (var crab in crabs)
            {
                gasUsedToMoveToPosition += (GetSumOfGasUsedForSteps(1,Math.Abs(crab.Key-position))*crab.Count());
            }
            return gasUsedToMoveToPosition;
        }

        private int GetSumOfGasUsedForSteps(int firstPosition, int lastPosition)
        {
            return (lastPosition * (lastPosition + 1) - (firstPosition - 1) * firstPosition) / 2;
        }
    }
}
