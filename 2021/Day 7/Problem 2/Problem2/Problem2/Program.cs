using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            CSVReader csvReader = new CSVReader();
            List<string> inputs = csvReader.ReadCSVFile(@"C:\Users\prest\Desktop\Dev\Credera\AdventOfCode\2021\Day 7\Problem 2\Problem2\Problem2\Inputs.csv");
            List<int> inputInts = new List<int>();
            foreach (string item in inputs)
            {
                inputInts.Add(int.Parse(item));
            }
            var groups = inputInts.GroupBy(v => v).ToList();
            Dictionary<int, long> posAndGasCost = new Dictionary<int, long>();
            CrabOperations crabOperations = new CrabOperations();
            var min = groups.Min(x => x.Key);
            var max = groups.Max(x => x.Key);
            for (int i = min; i < max; i++)
            {
                posAndGasCost.Add(i, crabOperations.CostOfGasMovingToPosition(groups, i));
            }

            long leastAmountOfGasUsed = posAndGasCost.Min(x => x.Value);
            int positionOfLeastGasUsed = posAndGasCost.FirstOrDefault(x => x.Value == leastAmountOfGasUsed).Key;
            Console.WriteLine("Hello World!");
        }
    }
}
