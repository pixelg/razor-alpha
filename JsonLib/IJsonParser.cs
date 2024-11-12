using DataTypes;

namespace JsonLib;

public interface IJsonParser
{
    public List<Person> ParseJson(string json);
    public string? ParseJson(string json, string rootName);
}