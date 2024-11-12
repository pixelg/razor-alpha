namespace JsonLib;

public interface IParseStrategy<T>
{
    public List<T> Parse();
}