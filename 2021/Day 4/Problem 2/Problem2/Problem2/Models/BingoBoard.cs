using System;
using System.Collections.Generic;
using System.Text;

namespace Problem2.Models
{
    public class BingoBoard
    {
        public List<BingoNumber> BingoNumbers { get; set; } = new List<BingoNumber>();
        public int Id { get; set; }
        public bool IsWinningBoard { get; set; }
    }

    public class BingoNumber
    {
        public decimal Value { get; set; }
        public RowNumber Row { get; set; }
        public ColumnNumber Column { get; set; }
        public bool hasBeenCalled { get; set; }
    }

    public enum RowNumber { Row1 = 0, Row2 = 1, Row3 = 2, Row4 = 3, Row5 = 4 };
    public enum ColumnNumber { Column1 = 0, Column2 = 1, Column3 = 2, Column4 = 3, Column5 = 4 };
}