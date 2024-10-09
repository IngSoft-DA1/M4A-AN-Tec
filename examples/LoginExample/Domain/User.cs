namespace Domain;

public class User
{
    public int Id { get; set; }

    private string name;
    public string Name
    {
        get => name;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("El nombre es requerido");
            }

            if (value.Length > 50)
            {
                throw new ArgumentException("El nombre no puede tener más de 50 caracteres");
            }

            name = value;
        }
    }

    private string password;
    public string Password
    {
        get => password;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("La contraseña es requerida");
            }

            if (value.Length < 8)
            {
                throw new ArgumentException("La contraseña debe tener al menos 8 caracteres");
            }

            if (value.Length > 50)
            {
                throw new ArgumentException("La contraseña no puede tener más de 50 caracteres");
            }

            password = value;
        }
    }
}