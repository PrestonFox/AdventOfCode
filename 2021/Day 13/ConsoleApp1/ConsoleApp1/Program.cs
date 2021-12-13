using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadLines(@"C:\Users\prest\Desktop\Dev\Credera\AdventOfCode\2021\Day 13\ConsoleApp1\ConsoleApp1\Input.csv").ToList();
            List<Coordinate> coordinates = new List<Coordinate>();
            List<Tuple<string, double>> foldLines = new List<Tuple<string, double>>();
            foreach (string line in input)
            {
                if (line.Contains(","))
                {
                    //Coordinates
                    var splitCoords = line.Split(",");
                    coordinates.Add(new Coordinate { x = double.Parse(splitCoords[0]), y = double.Parse(splitCoords[1]) });
                } else if (line.Length > 0) 
                {
                    //Fold lines
                    string foldInstructions = line.Substring(11);
                    foldLines.Add(new Tuple<string, double>(foldInstructions.Substring(0, 1), double.Parse(foldInstructions.Substring(2))));
                }
            }

            //PART 1
            if (foldLines[0].Item1.ToUpper() == "X")
            {
                //Fold Left
                double lineValue = foldLines[0].Item2;
                var secondHalfOfCoordinates = coordinates.Where(x => x.x > lineValue).ToList();
                var firstHalfOfCoordinates = coordinates.Where(x => x.x < lineValue).ToList();

                secondHalfOfCoordinates.All(x => { x.x = lineValue - (x.x - lineValue); return true; });
                coordinates = new List<Coordinate>();
                coordinates.AddRange(firstHalfOfCoordinates);
                foreach (Coordinate item in secondHalfOfCoordinates)
                {
                    if (coordinates.FirstOrDefault(x => x.x == item.x && x.y == item.y) == null)
                    {
                        coordinates.Add(item);
                    }
                }
            } else
            {
                //Fold Up
                double lineValue = foldLines[0].Item2;
                var secondHalfOfCoordinates = coordinates.Where(x => x.y > lineValue).ToList();
                var firstHalfOfCoordinates = coordinates.Where(x => x.y < lineValue).ToList();

                secondHalfOfCoordinates.All(x => { x.y = lineValue - (x.y - lineValue); return true; });
                coordinates = new List<Coordinate>();
                coordinates.AddRange(firstHalfOfCoordinates);

                foreach (Coordinate item in secondHalfOfCoordinates)
                {
                    if (coordinates.FirstOrDefault(x => x.x == item.x && x.y == item.y) == null)
                    {
                        coordinates.Add(item);
                    }
                }
            }
            //Console.WriteLine(coordinates.Count());

            //PART 2
            foreach (var foldLine in foldLines)
            {
                Console.Clear();
                if (foldLine.Item1.ToUpper() == "X")
                {
                    //Fold Left
                    double lineValue = foldLine.Item2;
                    var secondHalfOfCoordinates = coordinates.Where(x => x.x > lineValue).ToList();
                    var firstHalfOfCoordinates = coordinates.Where(x => x.x < lineValue).ToList();

                    secondHalfOfCoordinates.All(x => { x.x = lineValue - (x.x - lineValue); return true; });
                    coordinates = new List<Coordinate>();
                    coordinates.AddRange(firstHalfOfCoordinates);
                    foreach (Coordinate item in secondHalfOfCoordinates)
                    {
                        if (coordinates.FirstOrDefault(x => x.x == item.x && x.y == item.y) == null)
                        {
                            coordinates.Add(item);
                        }
                    }
                }
                else
                {
                    //Fold Up
                    double lineValue = foldLine.Item2;
                    var secondHalfOfCoordinates = coordinates.Where(x => x.y > lineValue).ToList();
                    var firstHalfOfCoordinates = coordinates.Where(x => x.y < lineValue).ToList();

                    secondHalfOfCoordinates.All(x => { x.y = lineValue - (x.y - lineValue); return true; });
                    coordinates = new List<Coordinate>();
                    coordinates.AddRange(firstHalfOfCoordinates);

                    foreach (Coordinate item in secondHalfOfCoordinates)
                    {
                        if (coordinates.FirstOrDefault(x => x.x == item.x && x.y == item.y) == null)
                        {
                            coordinates.Add(item);
                        }
                    }
                }

                Console.BufferHeight = 10000;
                Console.BufferWidth = 10000;

                //Draw In Console
                foreach (Coordinate coord in coordinates)
                {
                    
                    Console.SetCursorPosition((int)(coord.x), (int)(coord.y));
                    Console.Write("X");
                }
            }

        }
    }
}
