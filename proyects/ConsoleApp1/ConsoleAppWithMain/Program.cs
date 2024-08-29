using Domain;

namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        /*
         * 1. Crear solución (Console App)
         * 2. Crear proyecto de Domain (u otro)
         * 3. Agregar una clase, via proyecto, o via mismo proyecto de progam.
         * 4. Instanciar Clase creada en Program.cs
         */
        
        // Ejemplo de instancia
        User user = new User();
        
        string message = "Hello, World!";

        
        
        Console.WriteLine(message);
    }
}