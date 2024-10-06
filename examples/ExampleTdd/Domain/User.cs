namespace Domain;

public class User
{
    public string Name {
        get;
        set;
    }

     public string LastName
    {
        get;
        set;
    }

    private int _age;
     public int Age
     {
         get => _age;
         set
         {
             if (value < 10)
             {
                 throw new ArgumentException();
             }
             _age = value;
         }
    }
    public User(string name, string lastName, int age)
    {
        this.Name = name;
        this.LastName = lastName;
        this.Age = age;
    }
}