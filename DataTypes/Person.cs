using System.Text.Json.Serialization;

namespace DataTypes;

public class Person
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }
    [JsonPropertyName("age")]
    public int? Age { get; init; }

    public override string ToString()
    {
        return $"{Name} {Age}";
    }
}