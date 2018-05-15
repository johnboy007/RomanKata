using System;
using System.Collections.Generic;
using System.Web.Http.Results;
using NUnit.Framework;
using RomanNumeralConverter.Controllers;
using RomanNumeralConverter.Models;

namespace RomanNumeralConverter.Tests.Controllers
{
    [TestFixture]
    public class RomanControllerTest
    {
        private int _min;
        private int _max;
    

        [SetUp]
        public void SetUp()
        {
            _min = 1;
            _max = 3999;
        }

        /// <summary>
        /// Test will compare number against the returned Roman Numeral
        /// </summary>
        [Test]
        public void CompareValues()
        {
            var numbers = new Dictionary<int, string>
            {
                [1] = "I",
                [5] = "V",
                [10] = "X",
                [20] = "XX",
                [3999] = "MMMCMXCIX"
            };

            // Arrange
            var objController = new RomanNumeralController();

            foreach (var objKeyPair in numbers)
            {
                // Act
                var result = objController.GetRomanNumeral(objKeyPair.Key) as OkNegotiatedContentResult<RomanNumeral>;

                // Assert
                Assert.IsNotNull(result);
                Assert.IsNotNull(result.Content.numeral);
                Assert.AreEqual(result.Content.numeral, objKeyPair.Value);
            }
        }

        /// <summary>
        /// Test will return null is number is below range
        /// </summary>
        [Test]
        public void FailIfNumberIsBelowRange()
        {
            // Arrange
            var objController = new RomanNumeralController();

            // Act
            var result = objController.GetRomanNumeral(_min-1) as OkNegotiatedContentResult<RomanNumeral>;
            
            // Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Content.numeral);
            Console.WriteLine(result.Content.errorMessage);
        }

        /// <summary>
        /// Test will return null is number is above range
        /// </summary>
        [Test]
        public void FailIfNumberIsAboveRange()
        {
            // Arrange
            var objController = new RomanNumeralController();

            // Act
            var result = objController.GetRomanNumeral(_max+1) as OkNegotiatedContentResult<RomanNumeral>;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Content.numeral);
            Console.WriteLine(result.Content.errorMessage);
        }

        /// <summary>
        /// Tests if the Min number can be processed
        /// </summary>
        [Test]
        public void PassIfMin()
        {
            // Arrange
            var objController = new RomanNumeralController();

            // Act
            var result = objController.GetRomanNumeral(_min) as OkNegotiatedContentResult<RomanNumeral>;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content.numeral, result.Content.errorMessage);
            Console.WriteLine($"{result.Content.numeral} = {result.Content.number}");
        }

        /// <summary>
        /// Tests if the Max number can be processed
        /// </summary>
        [Test]
        public void PassIfMax()
        {
            // Arrange
            var objController = new RomanNumeralController();

            // Act
            var result = objController.GetRomanNumeral(_max) as OkNegotiatedContentResult<RomanNumeral>;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content.numeral, result.Content.errorMessage);
            Console.WriteLine($"{result.Content.numeral} = {result.Content.number}");
        }

        [Test]
        public void RunFullRange()
        {
            // Arrange
            var objController = new RomanNumeralController();
            for (var i = _min; i <= _max; i++)
            {
                // Act
                var result = objController.GetRomanNumeral(i) as OkNegotiatedContentResult<RomanNumeral>;

                // Assert
                Assert.IsNotNull(result);
                Assert.IsNotNull(result.Content.numeral, result.Content.errorMessage);
                Console.WriteLine($"{result.Content.numeral} = {result.Content.number}");
            }
        }
    }
}
