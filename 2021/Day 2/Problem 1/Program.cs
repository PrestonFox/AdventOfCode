using System;
using System.Collections;

namespace Problem_1
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList csvResults = new ArrayList();
            int xCoordinate = 0;
            int yCoordinate = 0;
            CSVReader csvReader = new CSVReader();
            csvResults = csvReader.ReadCSVFile("C:\\Users\\prest\\Desktop\\Dev\\Credera\\AdventOfCode\\2021\\Day 2\\Problem 1\\AdventOfCodeDay2Input.csv");
            for (int i = 0; i < csvResults.Count; i++)
            {
                string result = (string)csvResults[i];
                string[] splitResult = result.Split(' ');
                string direction = splitResult[0];
                int value = int.Parse(splitResult[1]);
                switch (direction.ToUpper())
                {
                    case "FORWARD":
                        xCoordinate = xCoordinate + value;
                        break;
                    case "DOWN":
                        yCoordinate = yCoordinate + value;
                        break;
                    case "UP":
                        yCoordinate = yCoordinate - value;
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine("xCoordinate Is: "+ xCoordinate);
            Console.WriteLine("yCoordinate Is: "+ yCoordinate);
            Console.WriteLine("Multiplied together: "+ xCoordinate*yCoordinate);
            Console.ReadLine();
        }
    }
}
