using JsonLib;
using JetBrains.Annotations;
using Xunit.Abstractions;

namespace RazorAlphaxUnit.Tests;

[TestSubject(typeof(JsonParser))]
public class JsonParserTests(ITestOutputHelper testOutputHelper)
{
    [Fact]
    public void ParseJson_ShouldParseNameCorrectly()
    {
        const string jsonString = "{ \"name\": \"John Doe\", \"age\": 42 }";
        var parser = new JsonParser();
        var actual = parser.ParseJson(jsonString, "name");
        testOutputHelper.WriteLine(actual);
        Assert.Equal("John Doe", actual);
    }

    [Fact]
    public void ParseJson_ShouldDeserializeToPersonObject()
    {
        const string jsonString = "{ \"name\": \"John Doe\", \"age\": 42}";
        var parser = new JsonParser();
        
        var result = parser.ParseJson(jsonString);
        Assert.Single(result);
        foreach (var personObject in result)
        {
            testOutputHelper.WriteLine(personObject.ToString());   
        }
        Assert.NotNull(result);
    }
}