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

            var opCodeInput = File.ReadAllText("OpCodeInput.txt");
            var opCodes = opCodeInput.Split(',').Select(int.Parse).ToList();
            ProcessOpCodes(new List<int>(opCodes));
            ProcessesOpCodeThatProducesKnownValue(new List<int>(opCodes));

            var wireInput = File.ReadAllLines("WireInput.txt");
            FindMinimumWireIntersection(wireInput[0], wireInput[1]);
            FindIntersectionWithFewestSteps(wireInput[0], wireInput[1]);
        }
        
        private static void ProcessesOpCodeThatProducesKnownValue(List<int> opCodes)
        {
            var reader = new OpCodeReader();
            for (int noun = 0; noun <= 99; noun++)
            {
                for (int verb = 0; verb <= 99; verb++)
                {
                    var freshOpCodes = new List<int>(opCodes);
                    freshOpCodes[1] = noun;
                    freshOpCodes[2] = verb;
                    var result = reader.Process(freshOpCodes);
                    if (result[0] == 19690720)
                    {
                        Console.WriteLine($"noun={noun}; verb={verb}; result={result[0]}");
                    }
                }
            }
        }

        private static void ProcessOpCodes(List<int> opCodes)
        {
            var reader = new OpCodeReader();
            var output = reader.Process(opCodes);
            Console.WriteLine($"Position 0 value={output[0]}");
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

        private static void FindMinimumWireIntersection(string wire1, string wire2)
        {
            var intersector = new WireIntersector();
            var wireA = new WireIntersector.Wire(wire1);
            var wireB = new WireIntersector.Wire(wire2);
            var min = intersector.MinimumDistanceFromOrigin(wireA, wireB);
            Console.WriteLine($"Minimum intersection distance: {min}");
        }

        private static void FindIntersectionWithFewestSteps(string wire1, string wire2)
        {
            var intersector = new WireIntersector();
            var wireA = new WireIntersector.Wire(wire1);
            var wireB = new WireIntersector.Wire(wire2);
            var min = intersector.IntersectionWithFewestSteps(wireA, wireB);
            Console.WriteLine($"Intersection with fewest steps: {min}");
        }
    }
}