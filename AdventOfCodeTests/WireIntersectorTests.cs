using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using AdventOfCode2019;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static AdventOfCode2019.WireIntersector;

namespace AdventOfCodeTests
{
    [TestClass]
    public class WireIntersectorTests
    {
        [TestMethod]
        public void Creation()
        {
            var intersector = new WireIntersector();
        }

        [DataTestMethod]
        [DataRow(0,1)]
        [DataRow(0,2)]
        [DataRow(0,3)]
        [DataRow(0,4)]
        [DataRow(0,5)]
        [DataRow(0,6)]
        [DataRow(0,7)]
        public void WireGoesUp(int x , int y)
        {
            var wire = new Wire("U7");
            CollectionAssert.Contains(wire.Points, new Point(x,y));
        }

        [DataTestMethod]
        [DataRow(0, 7)]
        [DataRow(1, 7)]
        [DataRow(2, 7)]
        [DataRow(3, 7)]
        [DataRow(4, 7)]
        [DataRow(5, 7)]
        [DataRow(6, 7)]
        public void WireGoesUpThenRight(int x, int y)
        {
            var wire = new Wire("U7,R6");
            CollectionAssert.Contains(wire.Points, new Point(x, y));
        }

        [DataTestMethod]
        [DataRow(6, 7)]
        [DataRow(6, 6)]
        [DataRow(6, 5)]
        [DataRow(6, 4)]
        [DataRow(6, 3)]
        public void WireGoesUpThenRightThenDown(int x, int y)
        {
            var wire = new Wire("U7,R6,D4");
            CollectionAssert.Contains(wire.Points, new Point(x, y));
        }

        [DataTestMethod]
        [DataRow(6, 3)]
        [DataRow(5, 3)]
        [DataRow(4, 3)]
        [DataRow(3, 3)]
        public void WireGoesUpThenRightThenDownThenLeft(int x, int y)
        {
            var wire = new Wire("U7,R6,D4,L4");
            CollectionAssert.Contains(wire.Points, new Point(x, y));
        }

        [DataTestMethod]
        [DataRow(100, 22)]
        [DataRow(-5, 22)]
        [DataRow(-5, -22)]
        public void WireDoesNotContainPoints(int x, int y)
        {
            var wire = new Wire("U7,R6,D4,L4");
            CollectionAssert.DoesNotContain(wire.Points, new Point(x, y));
        }

        [TestMethod]
        public void FindIntersections()
        {
            var wireA = new Wire("R8,U5,L5,D3");
            var wireB = new Wire("U7,R6,D4,L4");
            var intersector = new WireIntersector();
            var intersections = intersector.FindIntersections(wireA, wireB);
            var expected = new List<Point> {new Point(6, 5), new Point(3, 3)};
            CollectionAssert.AreEquivalent(expected, intersections);
        }

        [TestMethod]
        public void FindMinimumIntersection()
        {
            var wireA = new Wire("R8,U5,L5,D3");
            var wireB = new Wire("U7,R6,D4,L4");
            var intersector = new WireIntersector();
            var min = intersector.MinimumIntersection(wireA, wireB);
            Assert.AreEqual(new Point(3,3), min);
        }

        [DataTestMethod]
        [DataRow("R75,D30,R83,U83,L12,D49,R71,U7,L72", "U62,R66,U55,R34,D71,R55,D58,R83", 159)]
        [DataRow("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7", 135)]
        public void FindManyMinimums(string a , string b, int minDistance)
        {
            var wireA = new Wire(a);
            var wireB = new Wire(b);
            var intersector = new WireIntersector();
            var min = intersector.MinimumDistanceFromOrigin(wireA, wireB);
            Assert.AreEqual(minDistance, min);
        }

        [DataTestMethod]
        [DataRow("R8,U5,L5,D3", "U7,R6,D4,L4", 30)]
        [DataRow("R75,D30,R83,U83,L12,D49,R71,U7,L72", "U62,R66,U55,R34,D71,R55,D58,R83", 610)]
        [DataRow("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7", 410)]
        public void FindMinimumSteps(string a, string b, int minDistance)
        {
            var wireA = new Wire(a);
            var wireB = new Wire(b);
            var intersector = new WireIntersector();
            var min = intersector.IntersectionWithFewestSteps(wireA, wireB);
            Assert.AreEqual(minDistance, min);
        }
    }
}
