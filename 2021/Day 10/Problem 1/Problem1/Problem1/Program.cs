using System;
using System.Collections.Generic;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            CSVReader csvReader = new CSVReader();
            List<string> inputs = csvReader.ReadCSVFile(@"C:\Users\prest\Desktop\Dev\Credera\AdventOfCode\2021\Day 10\Problem 1\Problem1\Problem1\Inputs.csv");
            SyntaxChecker syntaxChecker = new SyntaxChecker();
            int score = syntaxChecker.ScoreCorruptCharacters(inputs.ToArray());
            Console.WriteLine("Hello World!");
        }
    }
}
