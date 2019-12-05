using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AdventOfCode2019
{
    public class WireIntersector
    {
        public class Wire
        {
            public List<Point> Points { get; set; } = new List<Point>();

            public Wire(string wireDescription)
            {
                var tokens = wireDescription.Split(',');
                var x = 0;
                var y = 0;
                foreach (var token in tokens)
                {
                    var dir = token.First();
                    var steps = int.Parse(token.Substring(1));

                    foreach (var _ in Enumerable.Range(0, steps))
                    {
                        if (dir == 'L')
                            x -= 1;
                        if (dir == 'R')
                            x += 1;
                        if (dir == 'U')
                            y += 1;
                        if (dir == 'D')
                            y -= 1;
                        Points.Add(new Point(x, y));
                    }
                }
            }
        }

        public List<Point> FindIntersections(Wire wireA, Wire wireB)
        {
            return wireA.Points.Intersect(wireB.Points).ToList();
        }

        public Point MinimumIntersection(Wire wireA, Wire wireB)
        {
            return FindIntersections(wireA, wireB)
                .OrderBy(it => Math.Abs(it.X) + Math.Abs(it.Y))
                .First();
        }
    }
}
