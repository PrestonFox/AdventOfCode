using ConsoleApp1;
using Problem1.Models;
using System;
using System.Collections.Generic;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            CSVReader csvReader = new CSVReader();
            List<string> results = csvReader.ReadCSVFile(@"C:\Users\prest\Desktop\Dev\Credera\AdventOfCode\2021\Day 6\Problem 1\Problem1\Problem1\Problem1Input.csv");
            List<LanternFish> lanternFishSchool = new List<LanternFish>();
            SpawningOperations spawningOperations = new SpawningOperations();
            for (int i = 0; i < results.Count; i++)
            {
                lanternFishSchool.Add(new LanternFish { DaysToSpawn = int.Parse(results[i])});
            }
            //Start the lanternfish spawning event for 80 days!
            for (int i = 0; i < 80; i++)
            {
                spawningOperations.DayEndOperation(lanternFishSchool);
            }

            int numberOfLanternFishAfter80Days = lanternFishSchool.Count;
            Console.WriteLine(numberOfLanternFishAfter80Days);
            Console.ReadLine();

            Console.WriteLine("Hello World!");
        }
    }
}
