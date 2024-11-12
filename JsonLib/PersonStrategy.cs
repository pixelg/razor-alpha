using System.Text.Json;
using DataTypes;

namespace JsonLib;

public class PersonStrategy(string jsonString) : IParseStrategy<Person>
{
   private readonly List<Person> _people = [];
   
   public List<Person> Parse()
   {
      try
      {
         var person = JsonSerializer.Deserialize<Person>(jsonString);
         if (person != null) _people.Add(person);
         return _people;
      }
      catch (Exception ex)
      {
         Console.WriteLine(ex.Message);
      }

      return _people;
   }

   public List<Person> GetPeople()
   {
      return _people ?? [];
   }
}