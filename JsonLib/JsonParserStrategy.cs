namespace JsonLib;

public class JsonParserStrategy<T>
{
    public List<T> ParsedData { get; } = [];

    public JsonParserStrategy(IParseStrategy<T> parseStrategy)
    {
        ArgumentNullException.ThrowIfNull(parseStrategy);

        try
        {
            ParsedData = parseStrategy.Parse();
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e);
        }
    }
}