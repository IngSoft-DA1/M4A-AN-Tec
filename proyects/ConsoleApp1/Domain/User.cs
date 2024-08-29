namespace Domain;

public class User
{
    private string _name;
    private DateTime _birthDate;
    
    private string Name
    {
        get => this._name;
        set
        {
            // Validaciones
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Name must not be null.");
            }
            _name = value;
        }
    }

    public DateTime BirthDate
    {
        get => _birthDate;
        set => _birthDate = value;
    }
    
    public int Age
    {
        get
        {
            var today = DateTime.Today;
            var age = today.Year - _birthDate.Year;
            if (_birthDate.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
    
    private string Ci { get; }
}