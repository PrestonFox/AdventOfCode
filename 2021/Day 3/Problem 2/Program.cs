using System;
using System.IO;
using System.Collections;
using System.Linq;

namespace Problem_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bitCounterOxygen = new int[12];
            int[] bitCounterC02 = new int[12];

            CSVReader csvReader = new CSVReader();

            //Track index values in ArrayList
            ArrayList resultsCopyOxygenRating = csvReader.ReadCSVFile(@"/Users/pfox/Desktop/Dev/Credera/AdventOfCode/2021/Day 3/Problem 2/Day3Inputs.csv");;
            for (int i = 0; i < 12; i++)
            {
                ArrayList indexesToBeRemovedFromResultsList = new ArrayList();
                //Count most reoccuring digit at i index
                for (int y = 0; y < resultsCopyOxygenRating.Count; y++)
                {
                    string valueFromResultsCopy = resultsCopyOxygenRating[y].ToString().Substring(i,1);
                    if(valueFromResultsCopy == "1"){
                        bitCounterOxygen[i] += 1;
                    }
                }
                decimal halfNumber = (decimal)resultsCopyOxygenRating.Count/2;
                string mostOccuringDigit = bitCounterOxygen[i] >= halfNumber ? "1" : "0";
                for (int y = 0; y < resultsCopyOxygenRating.Count; y++)
                {
                    string valueFromResultsCopy = resultsCopyOxygenRating[y].ToString().Substring(i,1);
                    if(valueFromResultsCopy != mostOccuringDigit){
                        indexesToBeRemovedFromResultsList.Add(y);
                    }
                }
                for (int y = indexesToBeRemovedFromResultsList.Count-1; y > -1; y--)
                {
                    //Remove Items from collection
                    resultsCopyOxygenRating.RemoveAt((int)indexesToBeRemovedFromResultsList[y]);
                }
                if (resultsCopyOxygenRating.Count == 1){
                    Console.WriteLine("Oxygen Rating is:"+ resultsCopyOxygenRating[0]);
                    break;
                }
            }

            //Track index values in ArrayList
            ArrayList resultsCopyC02Rating = csvReader.ReadCSVFile(@"/Users/pfox/Desktop/Dev/Credera/AdventOfCode/2021/Day 3/Problem 2/Day3Inputs.csv");;
            for (int i = 0; i < 12; i++)
            {
                ArrayList indexesToBeRemovedFromResultsList = new ArrayList();
                //Count least reoccuring digit at i index
                for (int y = 0; y < resultsCopyC02Rating.Count; y++)
                {
                    string valueFromResultsCopy = resultsCopyC02Rating[y].ToString().Substring(i,1);
                    if(valueFromResultsCopy == "1"){
                        bitCounterC02[i] += 1;
                    }
                }
                decimal halfNumber = (decimal)resultsCopyC02Rating.Count/2;
                string leastOccuringDigit = bitCounterC02[i] < halfNumber ? "1" : "0";
                for (int y = 0; y < resultsCopyC02Rating.Count; y++)
                {
                    string valueFromResultsCopy = resultsCopyC02Rating[y].ToString().Substring(i,1);
                    if(valueFromResultsCopy != leastOccuringDigit){
                        indexesToBeRemovedFromResultsList.Add(y);
                    }
                }
                for (int y = indexesToBeRemovedFromResultsList.Count-1; y > -1; y--)
                {
                    //Remove Items from collection
                    resultsCopyC02Rating.RemoveAt((int)indexesToBeRemovedFromResultsList[y]);
                }
                if (resultsCopyC02Rating.Count == 1){
                    Console.WriteLine("C02 Rating is:"+ resultsCopyC02Rating[0]);
                    break;
                }
            }


            //Get Oxygen Rating in Decimal
            string oxygenRatingString = string.Join("", resultsCopyOxygenRating[0]);
            int oxygenRating = Convert.ToInt32(oxygenRatingString,2);

            //Get C02 Rating in Decimal
            string c02RatingString = string.Join("", resultsCopyC02Rating[0]);
            int c02Rating = Convert.ToInt32(c02RatingString,2);


            decimal lifeSupportRating = c02Rating*oxygenRating;
            Console.WriteLine(lifeSupportRating);

            Console.WriteLine("Hello World!");
        }
    }
}
