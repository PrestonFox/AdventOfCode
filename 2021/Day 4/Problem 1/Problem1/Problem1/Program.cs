using Problem1.Models;
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
            List<string> numbersCalledString = csvReader.ReadCSVFile(@"C:\Users\prest\Desktop\Dev\Credera\AdventOfCode\2021\Day 4\Problem 1\Problem1\Problem1\BingoNumbersOrder.csv");
            List<string> bingoBoardsString = csvReader.ReadCSVFile(@"C:\Users\prest\Desktop\Dev\Credera\AdventOfCode\2021\Day 4\Problem 1\Problem1\Problem1\BingoBoards.csv");
            List<decimal> numbersCalled = numbersCalledString.Select(decimal.Parse).ToList();

            List<BingoBoard> bingoBoards = new List<BingoBoard>();
            for (int i = 0; i < bingoBoardsString.Count/5; i++)
            {
                BingoBoard bingoBoardToBeAdded = new BingoBoard { Id = i};
                for (int x = 0; x < 5; x++)
                {
                    string[] bingoBoardRowValues = bingoBoardsString[i * 5 + x].Split(" ",StringSplitOptions.RemoveEmptyEntries);
                    RowNumber rowNumber = (RowNumber)Enum.ToObject(typeof(RowNumber), x);
                    List<BingoNumber> rowOfNumbers = bingoBoardRowValues.Select((value, index) => new BingoNumber { Row = rowNumber, hasBeenCalled = false, Value = decimal.Parse(value), Column = (ColumnNumber)Enum.ToObject(typeof(ColumnNumber), index)}).ToList();
                    bingoBoardToBeAdded.BingoNumbers.AddRange(rowOfNumbers);
                } 
                bingoBoards.Add(bingoBoardToBeAdded);
            }

            BingoOperations bingoOperations = new BingoOperations();
            int bingoBoardId = -1;
            decimal lastNumberCalled = -1;

            foreach (decimal numberCalled in numbersCalled)
            {
                bingoOperations.MarkNumbersOff(bingoBoards,numberCalled);
                lastNumberCalled = numberCalled;
                bingoBoardId = bingoOperations.CheckBingoBoards(bingoBoards);
                if (bingoBoardId > -1)
                {
                    break;
                }
            }

            decimal sumValueOfUnmarked = bingoOperations.GetSumOfUnmarkedNumbers(bingoBoards.FirstOrDefault(x => x.Id == bingoBoardId));
            Console.WriteLine(sumValueOfUnmarked*lastNumberCalled);

            Console.ReadLine();
        }
    }
}
