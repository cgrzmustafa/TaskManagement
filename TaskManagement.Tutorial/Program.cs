class Program
{
    public static void Main(string[] args)
    {
        List<Person> people = new List<Person>();

        //people.GetirZeynep();

        people.Add(new Person { Id = 1, Name = "Yavuz Selim" });
        people.Add(new Person { Id = 2, Name = "Zeynep" });
        people.Add(new Person { Id = 3, Name = "Çağdaş" });
        people.Add(new Person { Id = 4, Name = "Kaan" });

        var zeynepII = people.GetirZeynep();
        var zeynep = people.SingleOrDefault(x => x.Name == "Zeynep");

        Console.WriteLine($"gelen kayıt {zeynep.Id} - {zeynep.Name}");
    }
}

class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
}

static class ListOfPersonExtensions
{
    public static Person? GetirZeynep(this List<Person> people)
    {
        return people.SingleOrDefault(x => x.Name == "Zeynep");
    }
}

