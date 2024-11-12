using Xunit;
using JsonLib;
using DataTypes;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace RazorAlphaxUnit.Tests
{
    public class PersonStrategyTest
    {
        [Fact]
        public void TestParse_WithValidPerson_ReturnsListOfPerson()
        {
            // Arrange
            var jsonString = "{\"name\": \"John\", \"age\": 25}";
            var personStrategy = new PersonStrategy(jsonString);

            // Act
            var result = personStrategy.Parse();

            // Assert
            Assert.Single(result);
            Assert.Equal("John", result[0].Name);
            Assert.Equal(25, result[0].Age);
        }

        [Fact]
        public void TestParse_WithInvalidPerson_ReturnsEmptyList()
        {
            // Arrange
            var jsonString = "{}";
            var personStrategy = new PersonStrategy(jsonString);

            // Act
            var result = personStrategy.Parse();

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void TestParse_WithInvalidJson_ThrowsJsonException()
        {
            // Arrange
            var jsonString = "{";
            var personStrategy = new PersonStrategy(jsonString);

            // Act and assert
            Exception ex = Assert.Throws<JsonException>(() => personStrategy.Parse());
            Assert.Contains("incomplete JSON at the end", ex.Message);
        }

        [Fact]
        public void TestGetPeople_WithParsedData_ReturnsListOfPeople()
        {
            // Arrange
            var jsonString = "{\"name\": \"John\", \"age\": 25}";
            var personStrategy = new PersonStrategy(jsonString);
            personStrategy.Parse();

            // Act
            var result = personStrategy.GetPeople();

            // Assert
            Assert.Single(result);
            Assert.Equal("John", result[0].Name);
            Assert.Equal(25, result[0].Age);
        }

        [Fact]
        public void TestGetPeople_WithoutParsingData_ReturnsEmptyList()
        {
            // Arrange
            var personStrategy = new PersonStrategy(string.Empty);

            // Act
            var result = personStrategy.GetPeople();

            // Assert
            Assert.Empty(result);
        }
    }
}