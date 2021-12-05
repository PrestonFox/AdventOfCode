using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            CSVReader csvReader = new CSVReader();
            List<CoordinatePoints> coordinatePointsOnLines = new List<CoordinatePoints>();
            CoordinatesHelper coordinatesHelper = new CoordinatesHelper();
            List<string> results = csvReader.ReadCSVFile(@"C:\Users\prest\Desktop\Dev\Credera\AdventOfCode\2021\Day 5\Problem 2\ConsoleApp1\ConsoleApp1\Problem1.csv");
            List<string> resultsCaptchaTrimmedOut = results.Select(x => x.Replace(" -> ", ",")).ToList();
            List<Coordinates> coordinates = resultsCaptchaTrimmedOut.Select(x => x.Split(',')).Select(r => new Coordinates
            {
                x1 = int.Parse(r[0]),
                y1 = int.Parse(r[1]),
                x2 = int.Parse(r[2]),
                y2 = int.Parse(r[3])
            }).ToList();
            for (int i = 0; i < coordinates.Count; i++)
            {
                coordinatePointsOnLines.AddRange(coordinatesHelper.TransformCoordinatesIntoLines(coordinates[i]));
            }
            int numberOfLinesIntersecting = coordinatePointsOnLines.GroupBy(z => new { z.x, z.y }).Where(grp => grp.Count() > 1).Count();
            Console.WriteLine(numberOfLinesIntersecting);
            Console.ReadLine();
        }
    }
}
