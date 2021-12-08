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
            List<string> inputs = csvReader.ReadCSVFile(@"C:\Users\prest\Desktop\Dev\Credera\AdventOfCode\2021\Day 8\Problem 2\Problem2\Problem2\Inputs.csv");
            long sumOfTotalNumbers = 0;
            foreach (var input in inputs)
            {
                string[] twoPartInput = input.Split("|");
                List<string> uniqueInput = twoPartInput[0].Trim().Split(' ').OrderBy(x => x.Length).ToList();
                string[] outputLine = twoPartInput[1].Trim().Split(' ');
                string one = uniqueInput.Single(x => x.Length == 2);
                string four = uniqueInput.Single(x => x.Length == 4);
                string seven = uniqueInput.Single(x => x.Length == 3);
                string eight = uniqueInput.Single(x => x.Length == 7);
                string six = uniqueInput.Where(x => x.Length == 6).Single(x => x.Intersect(one).Count() == 1);
                char top = seven.Except(one).ToList()[0];
                char bottomRight = one.Intersect(six).Single();
                char topRight = one.Single(x => x != bottomRight);
                string two = uniqueInput.Where(x => x.Length == 5).Single(x => x.Contains(topRight) && !x.Contains(bottomRight));
                string five = uniqueInput.Where(x => x.Length == 5).Single(x => !x.Contains(topRight) && x.Contains(bottomRight));
                string three = uniqueInput.Where(x => x.Length == 5).Single(x => x.Contains(topRight) && x.Contains(bottomRight));
                char bottomLeft = two.Except(five).Single(x => x != topRight);
                string zero = uniqueInput.Where(x => x.Length == 6 && x != six).Single(x => x.Contains(bottomLeft));
                string nine = uniqueInput.Single(x => x.Length == 6 && x != six && x != zero);
                int line = 0;
                foreach (string digit in outputLine.Where(x => x != null))
                {
                    int value = 0;

                    if (zero.Length == digit.Length && zero.Intersect(digit).Count() == digit.Length)
                        value = 0;
                    if (one.Length == digit.Length && one.Intersect(digit).Count() == digit.Length)
                        value = 1;
                    if (two.Length == digit.Length && two.Intersect(digit).Count() == digit.Length)
                        value = 2;
                    if (three.Length == digit.Length && three.Intersect(digit).Count() == digit.Length)
                        value = 3;
                    if (four.Length == digit.Length && four.Intersect(digit).Count() == digit.Length)
                        value = 4;
                    if (five.Length == digit.Length && five.Intersect(digit).Count() == digit.Length)
                        value = 5;
                    if (six.Length == digit.Length && six.Intersect(digit).Count() == digit.Length)
                        value = 6;
                    if (seven.Length == digit.Length && seven.Intersect(digit).Count() == digit.Length)
                        value = 7;
                    if (eight.Length == digit.Length && eight.Intersect(digit).Count() == digit.Length)
                        value = 8;
                    if (nine.Length == digit.Length && nine.Intersect(digit).Count() == digit.Length)
                        value = 9;
                    line = (line * 10) + value;
                }
                sumOfTotalNumbers += line;
            }
            Console.WriteLine(sumOfTotalNumbers);
            Console.WriteLine("Hello World!");
        }
    }
}
