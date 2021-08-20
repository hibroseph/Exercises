using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Exercises.ShortestPath
{
    public class ShortestPath
    {
        public int Find(List<List<int>> map, int startPositionX, int startPositionY)
        {
            TryValidate(map, startPositionX, startPositionY);

            Position startPosition = new Position { X = startPositionX, Y = startPositionY };


            return FindShortestPath(map, startPosition);

        }

        private int FindShortestPath(List<List<int>> map, Position startPosition)
        {
            List<List<Position>> successfulPaths = new List<List<Position>>();

            foreach (Position firstMove in FindPossibleMoves(map, startPosition, new List<Position> { startPosition }))
            {
                successfulPaths.Add(Move(map, firstMove, new List<Position>(), 1));
            }

            RemoveInvalidPaths(successfulPaths);

            return FindShortestPath(successfulPaths);

        }

        public void RemoveInvalidPaths(List<List<Position>> paths)
        {
            paths.RemoveAll(p => p == null);
        }

        private int FindShortestPath(List<List<Position>> paths)
        {

            int shortestPath = paths?.FirstOrDefault()?.Count ?? 0;

            foreach (List<Position> path in paths)
            {
                if (path.Count < shortestPath)
                {
                    shortestPath = path.Count;
                }

            }

            return shortestPath;
        }

        private List<Position> Move(List<List<int>> map, Position currentPosition, List<Position> pathHistory, int currentStep)
        {
            pathHistory.Add(currentPosition);

            List<Position> possibleMoves = FindPossibleMoves(map, currentPosition, pathHistory);

            if (FoundExit(map, possibleMoves, pathHistory))
            {
                return pathHistory;
            }

            if (possibleMoves.Count == 1)
            {
                return Move(map, possibleMoves.First(), pathHistory, currentStep + 1);
            }
            else
            {
                foreach (Position nextMove in possibleMoves)
                {
                    return Move(map, nextMove, new List<Position>(pathHistory), currentStep + 1);
                }
            }

            return null;
        }

        public List<Position> FindPossibleMoves(List<List<int>> map, Position currentPosition, List<Position> historicalPositions)
        {
            List<Position> possibleMoves = new List<Position>();

            // RIGHT
            if (currentPosition.X + 1 <= map[currentPosition.Y].Count - 1)
            {
                // TODO: Figure out why this statement cannot be combined in the statement above.
                if (map[currentPosition.Y][currentPosition.X + 1] == 1 || map[currentPosition.Y][currentPosition.X + 1] == 3)
                {
                    possibleMoves.Add(new Position { X = currentPosition.X + 1, Y = currentPosition.Y });
                }
            }

            // DOWN
            if (currentPosition.Y + 1 <= map.Count - 1)
            {
                if (map[currentPosition.Y + 1][currentPosition.X] == 1 || map[currentPosition.Y + 1][currentPosition.X] == 3)
                {
                    possibleMoves.Add(new Position { X = currentPosition.X, Y = currentPosition.Y + 1 });
                }
            }

            // LEFT
            if (currentPosition.X - 1 >= 0)
            {
                if (map[currentPosition.Y][currentPosition.X - 1] == 1 || map[currentPosition.Y][currentPosition.X - 1] == 3)
                {
                    possibleMoves.Add(new Position { X = currentPosition.X - 1, Y = currentPosition.Y });
                }
            }

            // UP
            if (currentPosition.Y - 1 >= 0)
            {
                if (map[currentPosition.Y - 1][currentPosition.X] == 1 || map[currentPosition.Y - 1][currentPosition.X] == 3)
                {
                    possibleMoves.Add(new Position { X = currentPosition.X, Y = currentPosition.Y - 1 });
                }
            }

            FilterHistoricalMoves(possibleMoves, historicalPositions);

            return possibleMoves;
        }

        public void FilterHistoricalMoves(List<Position> possibleMoves, List<Position> historicalPositions)
        {
            foreach (var historicalPosition in historicalPositions)
            {
                possibleMoves.Remove(historicalPosition);
            }
        }

        private bool FoundExit(List<List<int>> map, List<Position> possibleExits, List<Position> pathHistory)
        {
            foreach (Position possibleExit in possibleExits)
            {
                if (map[possibleExit.Y][possibleExit.X] == 3)
                {
                    pathHistory.Add(possibleExit);
                    return true;
                }
            }

            return false;
        }

        private void TryValidate(List<List<int>> map, int startX, int startY)
        {
            if (map[startY][startX] != 2)
            {
                throw new Exception("The start position was not in the position that was indicated");
            }
        }
    }
}
