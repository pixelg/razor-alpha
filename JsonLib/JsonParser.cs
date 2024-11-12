using System.Diagnostics;
using System.Text.Json;
using DataTypes;

namespace JsonLib;

public class JsonParser : IJsonParser
{
    public List<Person> ParseJson(string json)
    {
        var people = new List<Person>();

        try
        {
            var person = JsonSerializer.Deserialize<Person>(json);
            if (person != null) people.Add(person);
            return people;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return people;
    }

    public string? ParseJson(string json, string jsonPropertyName)
    {
        using var doc = JsonDocument.Parse(json);
        var root = doc.RootElement;

        // Example: Access a property named "name"
        if (!root.TryGetProperty($"{jsonPropertyName}", out var nameElement)) return null;
        var name = nameElement.GetString();
        Console.WriteLine($"Name: {name}");
        return name;
    }
}