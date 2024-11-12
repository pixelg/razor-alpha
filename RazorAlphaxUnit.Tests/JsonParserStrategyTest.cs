using System;
using System.Collections.Generic;
using DataTypes;
using Xunit;
using Moq;
using JsonLib;
using Xunit.Abstractions;

namespace RazorAlphaxUnit.Tests
{
    [CollectionDefinition("JsonParserStrategy tests")]
    public class JsonParserStrategyTest
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly Mock<IParseStrategy<string>> _mockStrategy;

        public JsonParserStrategyTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _mockStrategy = new Mock<IParseStrategy<string>>();
        }

        [Fact]
        public void Run_With_PersonStrategy()
        {
            // Arrange
            const string jsonString = "{\"name\": \"John\", \"age\": 25}";
            var personStrategy = new PersonStrategy(jsonString);

            // Act & Assert
            var result = new JsonParserStrategy<Person>(personStrategy).ParsedData;
            foreach (var person in result)
            {
                _testOutputHelper.WriteLine(person.ToString());    
            }
        }
        
        [Fact]
        public void Constructor_WithNullStrategy_ThrowsException()
        {
            // Arrange
            IParseStrategy<string> nullStrategy = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new JsonParserStrategy<string>(nullStrategy));
        }

        [Fact]
        public void Constructor_WithValidInput_CallsParse()
        {
            // Arrange
            _mockStrategy.Setup(s => s.Parse()).Returns(new List<string>());

            // Act
            var jsonParserStrategy = new JsonParserStrategy<string>(_mockStrategy.Object);

            // Assert
            _mockStrategy.Verify(s => s.Parse(), Times.Once());
        }

        [Fact]
        public void Constructor_WithValidInputAndParseThrowsException_HandlesException()
        {
            // Arrange
            _mockStrategy.Setup(s => s.Parse()).Throws(new Exception());

            // Act
            var jsonParserStrategy = new JsonParserStrategy<string>(_mockStrategy.Object);

            // Assert: No exception is thrown
        }

        [Fact]
        public void Constructor_WithValidInputAndParseReturnsNull_DoesNotThrowException()
        {
            // Arrange
            _mockStrategy.Setup(s => s.Parse()).Returns((List<string>)null);

            // Act
            var jsonParserStrategy = new JsonParserStrategy<string>(_mockStrategy.Object);

            // Assert: No exception is thrown
        }
    }
}