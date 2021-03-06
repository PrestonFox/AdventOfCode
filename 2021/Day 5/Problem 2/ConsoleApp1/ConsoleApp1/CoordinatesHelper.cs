using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class CoordinatesHelper
    {
        public List<CoordinatePoints> TransformCoordinatesIntoLines(Coordinates coordinates)
        {
            List<CoordinatePoints> coordinatePointsToReturn = new List<CoordinatePoints>();
            //Consider Horizontal or Vertical lines
            if (coordinates.x1 == coordinates.x2 || coordinates.y1 == coordinates.y2)
            {
                if (coordinates.y1 == coordinates.y2)
                {
                    //Horizontal Lines
                    int distanceToMove = coordinates.x2 - coordinates.x1;
                    coordinatePointsToReturn.Add(new CoordinatePoints { x = coordinates.x1, y = coordinates.y1 });
                    if (distanceToMove < 0)
                    {
                        for (int i = 1; i < (distanceToMove * -1) + 1; i++)
                        {
                            coordinatePointsToReturn.Add(new CoordinatePoints { x = coordinates.x1 - i, y = coordinates.y1 });
                        }
                    } 
                    else
                    {
                        for (int i = 1; i < distanceToMove + 1; i++)
                        {
                            coordinatePointsToReturn.Add(new CoordinatePoints { x = coordinates.x1 + i, y = coordinates.y1 });
                        }
                    }
                   
                }
                else
                {
                    //Vertical Line
                    int distanceToMove = coordinates.y2 - coordinates.y1;
                    coordinatePointsToReturn.Add(new CoordinatePoints { x = coordinates.x1, y = coordinates.y1 });
                    if (distanceToMove < 0)
                    {
                        for (int i = 1; i < (distanceToMove * -1) + 1; i++)
                        {
                            coordinatePointsToReturn.Add(new CoordinatePoints { x = coordinates.x1, y = coordinates.y1 - i });
                        }
                    } else
                    {
                        for (int i = 1; i < distanceToMove + 1; i++)
                        {
                            coordinatePointsToReturn.Add(new CoordinatePoints { x = coordinates.x1, y = coordinates.y1 + i });
                        }
                    }
                }
            }
            //Consider Diagonal Lines with 45 degree angle
            else if (coordinates.x1 != coordinates.x2 && coordinates.y1 != coordinates.y2)
            {
                //Diagonal Line
                int distanceToMoveY = coordinates.y2 - coordinates.y1;
                int distanceToMoveX = coordinates.x2 - coordinates.x1;
                coordinatePointsToReturn.Add(new CoordinatePoints { x = coordinates.x1, y = coordinates.y1 });
                if (distanceToMoveY < 0)
                {
                    for (int i = 1; i < (distanceToMoveY * -1) + 1; i++)
                    {
                        if (distanceToMoveX < 0)
                        {
                            coordinatePointsToReturn.Add(new CoordinatePoints { x = coordinates.x1 - i, y = coordinates.y1 - i });
                        } else
                        {
                            coordinatePointsToReturn.Add(new CoordinatePoints { x = coordinates.x1 + i, y = coordinates.y1 - i });
                        }
                        
                    }
                } else
                {
                    for (int i = 1; i < distanceToMoveY + 1; i++)
                    {
                        if (distanceToMoveX < 0)
                        {
                            coordinatePointsToReturn.Add(new CoordinatePoints { x = coordinates.x1 - i, y = coordinates.y1 + i });
                        }
                        else
                        {
                            coordinatePointsToReturn.Add(new CoordinatePoints { x = coordinates.x1 + i, y = coordinates.y1 + i });
                        }
                    }
                }
            }

            return coordinatePointsToReturn;
        }
    }
}
