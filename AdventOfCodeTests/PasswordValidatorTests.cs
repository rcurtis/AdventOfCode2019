using System;
using System.Collections.Generic;
using System.Text;
using AdventOfCode2019;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTests
{
    [TestClass]
    public class PasswordValidatorTests
    {
        [TestMethod]
        public void Creation()
        {
            var validator = new PasswordValidator();
        }

        [DataTestMethod]
        [DataRow(123345)]
        [DataRow(123349)]
        [DataRow(111122)]
        [DataRow(123499)]
        [DataRow(112233)]
        public void ShouldBeValid(int input)
        {
            var validator = new PasswordValidator();
            Assert.IsTrue(validator.IsValid(input));
        }

        [DataTestMethod]
        [DataRow(223450)]
        [DataRow(221111)]
        [DataRow(123789)]
        [DataRow(1)]
        [DataRow(273222)]
        [DataRow(123444)]
        public void ShouldNotBeValid(int input)
        {
            var validator = new PasswordValidator();
            Assert.IsFalse(validator.IsValid(input));
        }
    }
}
