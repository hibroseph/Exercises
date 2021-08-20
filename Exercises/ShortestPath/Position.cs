using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Exercises.ShortestPath
{
    public class Position : IEquatable<Position>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public bool Equals([AllowNull] Position other)
        {
            return X == other.X && Y == other.Y;
        }
    }
}
