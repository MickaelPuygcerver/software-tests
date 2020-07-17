using System;
using UnitTests.Lib;
using Xunit;

namespace UnitTests.Tests
{
    public class AssertNumbersTests
    {
        [Fact(DisplayName = "Sum Calculator")]
        // Different way to see tests organization in IDE by tags
        [Trait("Category", "Numbers Tests")]
        // ObjectInTest_MethodInTest_ExpectedBehavior
        public void Calculator_Sum_ReturnSumValue()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.Sum(2, 2);

            // Assert
            Assert.Equal(4, result);
        }


        [Theory]
        [Trait("Category", "Numbers Tests")]
        [InlineData(1, 1, 2)]
        [InlineData(9, 9, 18)]
        public void Calculator_Sum_ReturnSumValues(double num1, double num2, double total)
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.Sum(num1, num2);

            // Assert
            Assert.Equal(total, result);
        }


        [Fact]
        [Trait("Category", "Numbers Tests")]
        public void Calculator_Sum_NotEquals()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.Sum(3.333, 3.333);

            // Assert
            Assert.NotEqual(6.6, result, precision: 1);
        }
    }
}
