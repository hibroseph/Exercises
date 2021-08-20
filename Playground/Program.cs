using System;
using System.Collections.Generic;
using Exercises.ShortestPath;
using NUnit.Framework;

namespace Playground
{
    /*
     * This file is meant to be a driver for any other libraries created in this solution
     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running your code");

            // insert calls to your library code here

            ShortestPath shortestPath = new ShortestPath();

            /*
            var possibleMoves = new List<Position> { new Position { X = 0, Y = 0 }, new Position { X = 1, Y = 0 } };
            var historicalMoves = new List<Position> { new Position { X = 1, Y = 0 }, };
            
            shortestPath.FilterHistoricalMoves(possibleMoves, historicalMoves);
            */

            Console.WriteLine(shortestPath.Find(new List<List<int>> {
            new List<int> {2, 0, 1, 1, 1, 1, 1, 1},
            new List<int> {1, 0, 1, 0, 1, 0, 1, 1},
            new List<int> {1, 1, 1, 0, 1, 0, 0, 0},
            new List<int> {0, 0, 0, 0, 1, 0, 1, 0},
            new List<int> {1, 1, 1, 1, 1, 0, 1, 0},
            new List<int> {1, 0, 0, 0, 0, 1, 1, 1},
            new List<int> {1, 1, 0, 1, 0, 1, 0, 1},
            new List<int> {0, 1, 1, 1, 1, 1, 0, 3}
            }, 0, 0));

            Console.WriteLine("Ending your code");
        }

        private static void PrintPossibleMoves(List<Position> moves)
        {
            Console.WriteLine("Your possible moves are:");
            if (moves != null)
            {
                foreach (Position move in moves)
                {
                    Console.WriteLine($"({move.X}, {move.Y})");
                }
            }
        }
    }
}
