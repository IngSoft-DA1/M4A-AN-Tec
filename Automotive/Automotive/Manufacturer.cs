namespace Automotive;

public class Manufacturer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }

    public Manufacturer(int id, string name, string country)
    {
        Id = id;
        Name = name;
        Country = country;
    }
}