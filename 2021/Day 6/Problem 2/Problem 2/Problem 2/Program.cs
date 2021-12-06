using System;
using System.Collections.Generic;

namespace Problem_2
{
    class Program
    {
        static void Main(string[] args)
        {
            CSVReader csvReader = new CSVReader();
            List<string> inputs = csvReader.ReadCSVFile(@"C:\Users\prest\Desktop\Dev\Credera\AdventOfCode\2021\Day 6\Problem 2\Problem 2\Problem 2\Problem1Input.csv");
            var fishCountByDaysToSpawn = new long[9];
            foreach (var ch in inputs)
            {
                fishCountByDaysToSpawn[int.Parse(ch)]++;
            }

            for (int i = 0; i < 256; i++)
            {
                fishCountByDaysToSpawn[(i + 7) % 9] += fishCountByDaysToSpawn[i % 9];
            }

            long numberOfLanternFish = new long();
            foreach (long numberOfFishByDaysToSpawn in fishCountByDaysToSpawn)
            {
                numberOfLanternFish += numberOfFishByDaysToSpawn;
            }

            Console.WriteLine(numberOfLanternFish);
            Console.ReadLine();
        }
    }
}
