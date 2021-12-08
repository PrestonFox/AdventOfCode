using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            CSVReader csvReader = new CSVReader();
            List<string> inputs = csvReader.ReadCSVFile(@"C:\Users\prest\Desktop\Dev\Credera\AdventOfCode\2021\Day 8\Problem1\Problem1\Problem1\Inputs.csv");
            List<string> singularInputs = new List<string>();
            for (int i = 0; i < inputs.Count; i++)
            {
                singularInputs.AddRange(inputs[i].Substring(inputs[i].LastIndexOf("|")+2).Split(" "));
            }
            var groupedInputs = singularInputs.Where(x => x.Length == 2 || x.Length == 3 || x.Length == 4 || x.Length == 7);
            long countOfUniqueNumberInputs = groupedInputs.Count();
            Console.WriteLine("Hello World!");
        }
    }
}
