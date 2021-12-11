using System;
using System.Collections.Generic;

namespace Problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            CSVReader csvReader = new CSVReader();
            List<string> inputs = csvReader.ReadCSVFile(@"C:\Users\prest\Desktop\Dev\Credera\AdventOfCode\2021\Day 10\Problem 2\Problem2\Problem2\Inputs.csv");
            SyntaxChecker syntaxChecker = new SyntaxChecker();
            long score = syntaxChecker.CalculateScore(inputs.ToArray());
            Console.WriteLine("Hello World!");
        }
    }
}
