using Problem1.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Problem1
{
    public class BingoOperations
    {
        public List<BingoBoard> MarkNumbersOff(List<BingoBoard> bingoBoards, decimal numberToBeMarked)
        {
            for (int i = 0; i < bingoBoards.Count-1; i++)
            {
                if (bingoBoards[i].BingoNumbers.Any(x => x.Value == numberToBeMarked))
                {
                    bingoBoards[i].BingoNumbers.FirstOrDefault(x => x.Value == numberToBeMarked).hasBeenCalled = true;
                }
            }
            return bingoBoards;
        }

        public int CheckBingoBoards(List<BingoBoard> bingoBoards)
        {
            int idToReturn = -1;
            foreach (BingoBoard bingoBoard in bingoBoards)
            {
                var colCheck = bingoBoard.BingoNumbers.Where(x => x.hasBeenCalled == true).GroupBy(y => y.Column).Select(n => new
                {
                    GroupName = n.Key,
                    ColumnCount = n.Count()
                }).Where(x => x.ColumnCount == 5).Select(x=> x.ColumnCount);
                var rowCheck = bingoBoard.BingoNumbers.Where(x => x.hasBeenCalled == true).GroupBy(y => y.Row).Select(n => new
                {
                    GroupName = n.Key,
                    RowCount = n.Count()
                }).Where(x => x.RowCount == 5).Select(x => x.RowCount);
                if (colCheck.Any() && colCheck.First() == 5)
                {
                    return bingoBoard.Id;
                } else if (rowCheck.Any() && rowCheck.First() == 5)
                {
                    return bingoBoard.Id;
                }
            }
            return idToReturn;
        }

        public decimal GetSumOfUnmarkedNumbers(BingoBoard bingoBoard)
        {
            decimal returnValue = bingoBoard.BingoNumbers.Where(x => x.hasBeenCalled == false).Sum(y => y.Value);
            return returnValue;
        }
    }
}
