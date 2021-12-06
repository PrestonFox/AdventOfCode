using Problem1.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Problem1
{
    public class SpawningOperations
    {
        public List<LanternFish> DayEndOperation(List<LanternFish> lanternFishSchool)
        {
            lanternFishSchool.ForEach(c => c.DaysToSpawn -=1);
            long numberOfLanternFishToAdd = lanternFishSchool.Where(x => x.DaysToSpawn == -1).Count();
            //Update all Lanternfish that are about to spawn
            foreach (LanternFish lanternFishToBeUpdated in lanternFishSchool.Where(x => x.DaysToSpawn == -1))
            {
                lanternFishToBeUpdated.DaysToSpawn = 6;
            }
            //Add Lanternfish that have just spawned
            for (long i = 0; i < numberOfLanternFishToAdd; i++)
            {
                lanternFishSchool.Add(new LanternFish());
            }
            return lanternFishSchool;
        }
    }
}
