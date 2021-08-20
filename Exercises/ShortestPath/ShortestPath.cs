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
            List<List<Position>> lengthOfSuccessfulPaths = new List<List<Position>>();
            // initial quick off and returning the shortest path found
            foreach (Position firstMove in FindPossibleMoves(map, startPosition))
            {
                lengthOfSuccessfulPaths.Add(Move(map, firstMove, new List<Position>(), 1));
            }

            PrintAllPaths(lengthOfSuccessfulPaths);
            /*
            if (lengthOfSuccessfulPaths.Count > 0)
            {
                lengthOfSuccessfulPaths.Sort();

                return lengthOfSuccessfulPaths.First().Count;
            }
            else
            {
                return 0;
            }
            */
            return 0;
        }

        private void PrintAllPaths(List<List<Position>> paths)
        {
            int pathNumber = 0;

            foreach (List<Position> path in paths)
            {
                PrintPath(pathNumber, path);
            }
        }

        private void PrintPath(int pathNumber, List<Position> path)
        {
            if (path != null)
            {
                Console.WriteLine($"Printing Path #{pathNumber}");
                Console.WriteLine("----------------------------");
                foreach (Position position in path)
                {
                    Console.WriteLine($"({position.X}, {position.Y})");
                }

                Console.WriteLine("\n");
            }
        }


        /*
        private int Move(List<List<int>> map, Position currentPosition, List<Position> pathHistory, int currentStep)
        {
            pathHistory.Add(currentPosition);

            List<Position> possibleMoves = FindPossibleMoves(map, currentPosition);

            if (FoundExit(map, possibleMoves))
            {
                return currentStep + 1;
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

            return 0;
        }
        */

        private List<Position> Move(List<List<int>> map, Position currentPosition, List<Position> pathHistory, int currentStep)
        {
            Console.WriteLine($"Moving to ({currentPosition.X}, {currentPosition.Y})");
            pathHistory.Add(currentPosition);

            List<Position> possibleMoves = FindPossibleMoves(map, currentPosition);

            if (FoundExit(map, possibleMoves))
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

        public List<Position> FindPossibleMoves(List<List<int>> map, Position currentPosition)
        {
            List<Position> possibleMoves = new List<Position>();

            // look in every valid direction for a 1 without looking over the ends of the array

            // RIGHT
            if (currentPosition.X + 1 <= map[currentPosition.Y].Count - 1 && map[currentPosition.Y][currentPosition.X + 1] == 1 || map[currentPosition.Y][currentPosition.X + 1] == 3)
            {
                Console.WriteLine("Can move right");
                possibleMoves.Add(new Position { X = currentPosition.X + 1, Y = currentPosition.Y });
            }

            // DOWN
            if (currentPosition.Y + 1 <= map.Count - 1 && map[currentPosition.Y + 1][currentPosition.X] == 1 || map[currentPosition.Y + 1][currentPosition.X] == 3)
            {

                Console.WriteLine("Can move down");
                possibleMoves.Add(new Position { X = currentPosition.X, Y = currentPosition.Y + 1 });
            }

            // LEFT

            if (currentPosition.X - 1 >= 0)
            {
                if (map[currentPosition.Y][currentPosition.X - 1] == 1 || map[currentPosition.Y][currentPosition.X - 1] == 3)
                {
                    Console.WriteLine("Can move left");
                    possibleMoves.Add(new Position { X = currentPosition.X - 1, Y = currentPosition.Y });
                }
            }

            // UP

            if (currentPosition.Y - 1 >= 0)
            {
                if (map[currentPosition.Y - 1][currentPosition.X] == 1 || map[currentPosition.Y - 1][currentPosition.X] == 3)
                {
                    Console.WriteLine("Can move up");
                    possibleMoves.Add(new Position { X = currentPosition.X, Y = currentPosition.Y - 1 });
                }
            }

            Console.WriteLine($"Here are our possible moves for position ({currentPosition.X}, {currentPosition.Y})");
            PrintPath(0, possibleMoves);

            return possibleMoves;
        }

        private bool FoundExit(List<List<int>> map, List<Position> possibleExits)
        {
            foreach (Position possibleExit in possibleExits)
            {
                if (map[possibleExit.Y][possibleExit.X] == 3)
                {
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
