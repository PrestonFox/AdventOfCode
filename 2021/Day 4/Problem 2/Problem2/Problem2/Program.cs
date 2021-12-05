using Problem2.Models;
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
            List<string> numbersCalledString = csvReader.ReadCSVFile(@"C:\Users\prest\Desktop\Dev\Credera\AdventOfCode\2021\Day 4\Problem 2\Problem2\Problem2\BingoNumbersOrder.csv");
            List<string> bingoBoardsString = csvReader.ReadCSVFile(@"C:\Users\prest\Desktop\Dev\Credera\AdventOfCode\2021\Day 4\Problem 2\Problem2\Problem2\BingoBoards.csv");
            List<decimal> numbersCalled = numbersCalledString.Select(decimal.Parse).ToList();

            List<BingoBoard> bingoBoards = new List<BingoBoard>();
            for (int i = 0; i < bingoBoardsString.Count / 5; i++)
            {
                BingoBoard bingoBoardToBeAdded = new BingoBoard { Id = i };
                for (int x = 0; x < 5; x++)
                {
                    string[] bingoBoardRowValues = bingoBoardsString[i * 5 + x].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    RowNumber rowNumber = (RowNumber)Enum.ToObject(typeof(RowNumber), x);
                    List<BingoNumber> rowOfNumbers = bingoBoardRowValues.Select((value, index) => new BingoNumber { Row = rowNumber, hasBeenCalled = false, Value = decimal.Parse(value), Column = (ColumnNumber)Enum.ToObject(typeof(ColumnNumber), index) }).ToList();
                    bingoBoardToBeAdded.BingoNumbers.AddRange(rowOfNumbers);
                }
                bingoBoards.Add(bingoBoardToBeAdded);
            }

            BingoOperations bingoOperations = new BingoOperations();
            List<int> bingoBoardIds = new List<int>();
            bool lastBoardHasWon = false;
            decimal lastWinningBingoBoardId = -1;
            decimal lastNumberCalled = -1;

            foreach (decimal numberCalled in numbersCalled)
            {
                bingoOperations.MarkNumbersOff(bingoBoards, numberCalled);
                lastNumberCalled = numberCalled;
                bingoBoardIds = bingoOperations.CheckBingoBoards(bingoBoards);
                foreach (decimal bingoBoardId in bingoBoardIds)
                {
                    bingoBoards.FirstOrDefault(x => x.Id == bingoBoardId).IsWinningBoard = true;
                    if (lastWinningBingoBoardId == bingoBoardId)
                    {
                        lastBoardHasWon = true;
                        break;
                    }
                    lastWinningBingoBoardId = bingoOperations.GetLastWinningBoard(bingoBoards);
                    
                }
                if (lastBoardHasWon)
                {
                    break;
                }
            }

            decimal sumValueOfUnmarked = bingoOperations.GetSumOfUnmarkedNumbers(bingoBoards.FirstOrDefault(x => x.Id == lastWinningBingoBoardId));
            Console.WriteLine(sumValueOfUnmarked * lastNumberCalled);

            Console.ReadLine();
        }
    }
}
