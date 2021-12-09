using Problem1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem1
{
    public class TraverseOperations
    {
        public List<Height> TraverseCoordinates(List<Height> heightsToTraverse)
        {
            List<Height> lowPoints = new List<Height>();
            int maxRow = heightsToTraverse.Max(x => x.Row);
            int maxCol = heightsToTraverse.Max(x => x.Column);
            for (int i = 0; i < heightsToTraverse.Count; i++)
            {
                bool isCol0 = heightsToTraverse[i].Column == 0;
                bool isRow0 = heightsToTraverse[i].Row == 0;
                bool isMaxCol = heightsToTraverse[i].Column == maxCol;
                bool isMaxRow = heightsToTraverse[i].Row == maxRow;


                int row = heightsToTraverse[i].Row;
                int col = heightsToTraverse[i].Column;
                int height = heightsToTraverse[i].PositionalHeight;

                //Take care of edges
                if (isCol0)
                {
                    if (isRow0) 
                    {
                        if (height < heightsToTraverse.First(x => x.Column == col+1 && x.Row == row).PositionalHeight && height < heightsToTraverse.First(x => x.Column == col && x.Row == row+1).PositionalHeight)
                        {
                            lowPoints.Add(heightsToTraverse[i]);
                        }
                    } else if (isMaxRow)
                    {
                        if (height < heightsToTraverse.First(x => x.Column == col + 1 && x.Row == row).PositionalHeight && height < heightsToTraverse.First(x => x.Column == col && x.Row == row - 1).PositionalHeight)
                        {
                            lowPoints.Add(heightsToTraverse[i]);
                        }
                    } else
                    {
                        if (height < heightsToTraverse.First(x => x.Column == col + 1 && x.Row == row).PositionalHeight && height < heightsToTraverse.First(x => x.Column == col && x.Row == row - 1).PositionalHeight && height < heightsToTraverse.First(x => x.Column == col && x.Row == row + 1).PositionalHeight)
                        {
                            lowPoints.Add(heightsToTraverse[i]);
                        }
                    }
                } else if (isMaxCol)
                {
                    if (isRow0)
                    {
                        if (height < heightsToTraverse.First(x => x.Column == col - 1 && x.Row == row).PositionalHeight && height < heightsToTraverse.First(x => x.Column == col && x.Row == row + 1).PositionalHeight)
                        {
                            lowPoints.Add(heightsToTraverse[i]);
                        }
                    }
                    else if (isMaxRow)
                    {
                        if (height < heightsToTraverse.First(x => x.Column == col - 1 && x.Row == row).PositionalHeight && height < heightsToTraverse.First(x => x.Column == col && x.Row == row - 1).PositionalHeight)
                        {
                            lowPoints.Add(heightsToTraverse[i]);
                        }
                    }
                    else
                    {
                        if (height < heightsToTraverse.First(x => x.Column == col - 1 && x.Row == row).PositionalHeight && height < heightsToTraverse.First(x => x.Column == col && x.Row == row - 1).PositionalHeight && height < heightsToTraverse.First(x => x.Column == col && x.Row == row + 1).PositionalHeight)
                        {
                            lowPoints.Add(heightsToTraverse[i]);
                        }
                    }
                } else if (isRow0)
                {
                    if (height < heightsToTraverse.First(x => x.Column == col - 1 && x.Row == row).PositionalHeight && height < heightsToTraverse.First(x => x.Column == col && x.Row == row + 1).PositionalHeight && height < heightsToTraverse.First(x => x.Column == col + 1 && x.Row == row).PositionalHeight)
                    {
                        lowPoints.Add(heightsToTraverse[i]);
                    }
                } else if (isMaxRow)
                {
                    if (height < heightsToTraverse.First(x => x.Column == col - 1 && x.Row == row).PositionalHeight && height < heightsToTraverse.First(x => x.Column == col && x.Row == row - 1).PositionalHeight && height < heightsToTraverse.First(x => x.Column == col + 1 && x.Row == row).PositionalHeight)
                    {
                        lowPoints.Add(heightsToTraverse[i]);
                    }
                } else
                {
                    if (height < heightsToTraverse.First(x => x.Column == col - 1 && x.Row == row).PositionalHeight && height < heightsToTraverse.First(x => x.Column == col + 1 && x.Row == row).PositionalHeight && height < heightsToTraverse.First(x => x.Column == col && x.Row == row-1).PositionalHeight && height < heightsToTraverse.First(x => x.Column == col && x.Row == row + 1).PositionalHeight)
                    {
                        lowPoints.Add(heightsToTraverse[i]);
                    }
                }
            }
            return lowPoints;
        }

        public int SumRiskScore(List<Height> lowPoints)
        {
            int totalRiskScore = 0;
            lowPoints.ForEach(x => x.PositionalHeight += 1);
            return lowPoints.Sum(x => x.PositionalHeight);
        }
    }
}
