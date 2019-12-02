using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019
{
    public class FuelCalculator
    {
        public int Calculate(int mass)
        {
            var fuel = (int) Math.Floor((decimal) mass / 3) - 2;
            return fuel < 0 ? 0 : fuel;
        }

        public int CalculateIncludingFuel(int mass)
        {
            var total = 0;
            var fuel = Calculate(mass);
            total += fuel;
            
            while (fuel >= 2)
            {
                fuel = Calculate(fuel);
                total += fuel;
            }

            return total;
        }
    }
}