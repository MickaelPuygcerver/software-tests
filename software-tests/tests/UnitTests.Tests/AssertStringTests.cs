using Xunit;
using UnitTests.Lib;

namespace UnitTests.Tests
{
    public class AssertStringTests
    {
        [Fact]
        [Trait("Category", "String Tests")]
        public void StringsTools_JoinNomes_ReturnFullNameS()
        {
            // Arrange
            var sut = new StringsTools();

            // Act
            var fullName = sut.JoinName("Mickael", "Puygcerver");

            // Assert
            Assert.Equal("Mickael Puygcerver", fullName);

        }



        [Fact]
        [Trait("Category", "String Tests")]
        public void StringsTools_JoinNames_MustIgnoreCase()
        {
            // Arrange
            var sut = new StringsTools();

            // Act
            var fullName = sut.JoinName("Mickael", "Puygcerver");

            // Assert
            Assert.Equal("MICKAEL PUYGCERVER", fullName, ignoreCase: true);
        }



        [Fact]
        [Trait("Category", "String Tests")]
        public void StringsTools_JoinName_MustContains()
        {
            // Arrange
            var sut = new StringsTools();

            // Act
            var fullName = sut.JoinName("Mickael", "Puygcerver");

            // Assert
            Assert.Contains("ckael", fullName);
        }


        [Fact]
        [Trait("Category", "String Tests")]
        public void StringsTools_JoinName_MustStartsWith()
        {
            // Arrange
            var sut = new StringsTools();

            // Act
            var fullName = sut.JoinName("Mickael", "Puygcerver");

            // Assert
            Assert.StartsWith("Micka", fullName);
        }


        [Fact]
        [Trait("Category", "String Tests")]
        public void StringsTools_JoinName_MustEndsWith()
        {
            // Arrange
            var sut = new StringsTools();

            // Act
            var fullName = sut.JoinName("Mickael", "Puygcerver");

            // Assert
            Assert.EndsWith("ver", fullName);
        }


        [Fact]
        [Trait("Category", "String Tests")]
        public void StringsTools_UnirNomes_ValidarExpressaoRegular()
        {
            // Arrange
            var sut = new StringsTools();

            // Act
            var fullName = sut.JoinName("Mickael", "Puygcerver");

            // Assert
            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", fullName);
        }
    }
}
