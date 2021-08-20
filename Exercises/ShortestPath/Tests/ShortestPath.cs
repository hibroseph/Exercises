using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.ShortestPath.Tests
{
    [TestFixture]
    public class ShortestPath
    {
        [Test]
        public void TestMap5x5_MultiplePaths()
        {
            Exercises.ShortestPath.ShortestPath shortestPath = new Exercises.ShortestPath.ShortestPath();

            List<List<int>> map = new List<List<int>> {
            new List<int> {2, 0, 1, 1, 1},
            new List<int> {1, 0, 1, 0, 1},
            new List<int> {1, 0, 1, 0, 1},
            new List<int> {1, 0, 1, 1, 1},
            new List<int> {1, 1, 1, 0, 3}
            };

            Assert.AreEqual(10, shortestPath.Find(map, 0, 0));
        }

        [Test]
        public void TestMap5x5_SinglePath()
        {
            Exercises.ShortestPath.ShortestPath shortestPath = new Exercises.ShortestPath.ShortestPath();

            List<List<int>> map = new List<List<int>> {
            new List<int> {2, 0, 1, 1, 1},
            new List<int> {1, 1, 1, 0, 1},
            new List<int> {1, 0, 0, 0, 1},
            new List<int> {1, 0, 1, 0, 1},
            new List<int> {1, 1, 1, 0, 3}
            };

            Assert.AreEqual(10, shortestPath.Find(map, 0, 0));
        }

        [Test]
        public void TestMap5x5_AlotOfPaths()
        {
            Exercises.ShortestPath.ShortestPath shortestPath = new Exercises.ShortestPath.ShortestPath();

            List<List<int>> map = new List<List<int>> {
            new List<int> {2, 1, 1, 1, 1},
            new List<int> {1, 1, 1, 1, 1},
            new List<int> {1, 1, 1, 1, 1},
            new List<int> {1, 1, 1, 1, 1},
            new List<int> {1, 1, 1, 1, 3}
            };

            Assert.AreEqual(8, shortestPath.Find(map, 0, 0));
        }

        [Test]
        public void TestMap5x6_SinglePath()
        {
            Exercises.ShortestPath.ShortestPath shortestPath = new Exercises.ShortestPath.ShortestPath();

            List<List<int>> map = new List<List<int>> {
            new List<int> {0, 0, 1, 1, 1, 0},
            new List<int> {0, 0, 1, 0, 1, 0},
            new List<int> {0, 0, 2, 0, 1, 1},
            new List<int> {0, 0, 0, 0, 0, 1},
            new List<int> {0, 0, 0, 0, 3, 1}
            };

            Assert.AreEqual(10, shortestPath.Find(map, 2, 2));
        }

        [Test]
        public void TestMap5x6_MultiplePaths()
        {
            Exercises.ShortestPath.ShortestPath shortestPath = new Exercises.ShortestPath.ShortestPath();

            List<List<int>> map = new List<List<int>> {
            new List<int> {1, 1, 2, 1, 0, 0},
            new List<int> {1, 0, 0, 1, 1, 1},
            new List<int> {1, 0, 0, 0, 1, 0},
            new List<int> {1, 0, 0, 0, 1, 1},
            new List<int> {1, 1, 1, 1, 3, 0}
            };

            Assert.AreEqual(10, shortestPath.Find(map, 2, 0));
        }

        [Test]
        public void TestMap5x6_Impossible()
        {
            Exercises.ShortestPath.ShortestPath shortestPath = new Exercises.ShortestPath.ShortestPath();

            List<List<int>> map = new List<List<int>> {
            new List<int> {1, 1, 2, 1, 0, 0},
            new List<int> {1, 0, 0, 1, 1, 1},
            new List<int> {1, 0, 1, 0, 1, 0},
            new List<int> {1, 0, 1, 0, 0, 0},
            new List<int> {1, 1, 1, 0, 3, 0}
            };

            Assert.AreEqual(0, shortestPath.Find(map, 2, 0));
        }

        [Test]
        public void TestMap5x6_AlotOfPaths()
        {
            Exercises.ShortestPath.ShortestPath shortestPath = new Exercises.ShortestPath.ShortestPath();

            List<List<int>> map = new List<List<int>> {
            new List<int> {1, 1, 2, 1, 1, 1},
            new List<int> {1, 1, 1, 1, 1, 1},
            new List<int> {1, 1, 1, 1, 1, 1},
            new List<int> {1, 1, 1, 1, 1, 1},
            new List<int> {1, 1, 1, 1, 1, 3}
            };

            Assert.AreEqual(7, shortestPath.Find(map, 2, 0));
        }

        [Test]
        public void TestMap8x8_ComplexSinglePath()
        {
            Exercises.ShortestPath.ShortestPath shortestPath = new Exercises.ShortestPath.ShortestPath();

            List<List<int>> map = new List<List<int>> {
            new List<int> {2, 0, 1, 1, 1, 1, 1, 1},
            new List<int> {1, 0, 1, 0, 1, 0, 1, 1},
            new List<int> {1, 1, 1, 0, 1, 0, 0, 0},
            new List<int> {0, 0, 0, 0, 1, 0, 1, 0},
            new List<int> {1, 1, 1, 1, 1, 0, 1, 0},
            new List<int> {1, 0, 0, 0, 0, 1, 1, 1},
            new List<int> {1, 1, 0, 1, 0, 1, 0, 1},
            new List<int> {0, 1, 1, 1, 1, 1, 0, 3}
            };

            Assert.AreEqual(30, shortestPath.Find(map, 0, 0));
        }

        [Test]
        public void TestMap8x8_ComplexMultiplePaths()
        {
            Exercises.ShortestPath.ShortestPath shortestPath = new Exercises.ShortestPath.ShortestPath();

            List<List<int>> map = new List<List<int>> {
            new List<int> {2, 1, 1, 0, 0, 1, 1, 1},
            new List<int> {1, 0, 1, 1, 1, 1, 0, 1},
            new List<int> {1, 0, 1, 0, 0, 1, 0, 1},
            new List<int> {1, 0, 1, 0, 1, 1, 1, 1},
            new List<int> {1, 0, 1, 0, 1, 0, 0, 1},
            new List<int> {1, 0, 1, 1, 1, 1, 0, 1},
            new List<int> {1, 0, 0, 0, 1, 0, 0, 1},
            new List<int> {1, 1, 1, 1, 1, 1, 1, 3}
            };

            Assert.AreEqual(14, shortestPath.Find(map, 0, 0));
        }
    }
}
