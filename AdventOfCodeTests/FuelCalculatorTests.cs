using AdventOfCode2019;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTests
{
    [TestClass]
    public class FuelCalculatorTests
    {
        [TestMethod]
        public void Creation()
        {
            var sut = new FuelCalculator();
        }

        [DataTestMethod]
        [DataRow(12, 2)]
        [DataRow(14, 2)]
        [DataRow(1969, 654)]
        [DataRow(100756, 33583)]
        public void Calculate_KnownValues(int input, int expected)
        {
            var calc = new FuelCalculator();
            Assert.AreEqual(expected, calc.Calculate(input));
        }
        
        [DataTestMethod]
        [DataRow(14, 2)]
        [DataRow(1969, 966)]
        [DataRow(100756, 50346)]
        public void CalculateIncludingFuel(int input, int expected)
        {
            var calc = new FuelCalculator();
            Assert.AreEqual(expected, calc.CalculateIncludingFuel(input));
        }
    }
}