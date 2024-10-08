namespace Validations.Domain;

public class Movie
{
    private string _title;
    private int _year;

    public string Title
    {
        get => _title;
        set
        {
            ValidateTitle(value);
            _title = value;
        }
    }

    public int Year
    {
        get => _year;
        set
        {
            ValidateYear(value);
            _year = value;
        }
    }

    private void ValidateTitle(string titleToValidate)
    {
        if (string.IsNullOrEmpty(titleToValidate))
            throw new Exception("El título no puede estar vacío.");
    }

    private void ValidateYear(int yearToValidate)
    {
        if (yearToValidate <= 0)
            throw new Exception("El año de publicación debe ser mayor a 0.");
        if (yearToValidate > DateTime.Now.Year)
            throw new Exception("El año de publicación no puede ser en el futuro.");
    }
}