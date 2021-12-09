using System;
using System.Collections.Generic;
using Problem1.Models;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            CSVReader csvReader = new CSVReader();
            TraverseOperations traverseOperations = new TraverseOperations();
            List<string> inputs = csvReader.ReadCSVFile(@"C:\Users\prest\Desktop\Dev\Credera\AdventOfCode\2021\Day 9\Problem 1\Problem1\Problem1\Inputs.csv");
            List<Height> heights = new List<Height>();
            List<Height> lowPoints = new List<Height>();
            for (int x = 0; x < inputs.Count; x++)
            {
                char[] inputHeights = inputs[x].ToCharArray();
                for (int i = 0; i < inputHeights.Length; i++)
                {
                    string value = inputHeights[i].ToString();
                    heights.Add(new Height { Column = i, Row = x, PositionalHeight = int.Parse(value)});
                }
            }
            lowPoints = traverseOperations.TraverseCoordinates(heights);
            int riskScore = traverseOperations.SumRiskScore(lowPoints);
            Console.WriteLine("Hello World!");
        }
    }
}
