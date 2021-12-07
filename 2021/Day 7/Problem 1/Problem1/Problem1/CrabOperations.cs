using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem1
{
    public class CrabOperations
    {
        public long CostOfGasMovingToPosition(List<IGrouping<int,int>> crabs,int position)
        {
            long gasUsedToMoveToPosition = new long();
            foreach (var crab in crabs)
            {
                gasUsedToMoveToPosition += (Math.Abs(crab.Key-position)*crab.Count());
            }
            return gasUsedToMoveToPosition;
        }
    }
}
