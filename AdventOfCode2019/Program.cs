using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace AdventOfCode2019
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("Input.txt");
            var calculator = new FuelCalculator();
            
            CalculateBasicFuel(input, calculator);
            CalculateWithAdditionalFuelMass(input, calculator);
        }

        private static void CalculateBasicFuel(IEnumerable<string> input, FuelCalculator calculator)
        {
            var total = input.Sum(mass => calculator.Calculate(int.Parse(mass)));
            Console.WriteLine($"Total for all: {total}");
        }
        
        private static void CalculateWithAdditionalFuelMass(IEnumerable<string> input, FuelCalculator calculator)
        {
            var total = input.Sum(mass => calculator.CalculateIncludingFuel(int.Parse(mass)));
            Console.WriteLine($"Total when including mass of fuel: {total}");
        }
    }
}