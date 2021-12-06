using System;
using System.Collections;
using System.IO;

namespace Problem_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bitCounter = new int[12];
            int[] gammaRateBitString = new int[12];
            int[] epsilonRateBitString = new int[12];

            CSVReader csvReader = new CSVReader();
            ArrayList results = csvReader.ReadCSVFile(@"/Users/pfox/Desktop/Dev/Credera/AdventOfCode/2021/Day 3/Problem 1/Day3Inputs.csv");

            foreach (var item in results)
            {
                string bitString = item.ToString();
                for (int i = 0; i < 12; i++)
                {
                     if(bitString.Substring(i,1) == "1"){
                         bitCounter[i] += 1;
                     }
                }
            }
            for (int i = 0; i < 12; i++)
            {
                if(bitCounter[i] > (results.Count/2)){
                    gammaRateBitString[i] = 1;
                } else {
                    epsilonRateBitString[i] = 1;
                }
            }
            string gammaRateString = string.Join("", gammaRateBitString);
            string epsilonRateString = string.Join("", epsilonRateBitString);
            int gammaRate = Convert.ToInt32(gammaRateString,2);
            int epsilonRate = Convert.ToInt32(epsilonRateString,2);
            decimal finalResult = gammaRate*epsilonRate;
            Console.WriteLine(finalResult);
            Console.ReadLine();
        }
    }
}
