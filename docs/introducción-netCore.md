# Principales Características:
- Imperativo 
- Fuertemente tipado
- Manejo de memoria automático, Garbage Collector
- Orientado a objetos (soporta encapsulación, herencia, polimorfismo). 
- Multiplataforma
- Sintaxis similar
- 
## Ejemplo de Tipado fuerte:
1. Creamos una variable `string name` y una variable `int age`
2. Creamos un `if` y los comparamos, nos daría saltar la excepción siguiente. 
<img width="654" alt="image" src="https://github.com/user-attachments/assets/7fd1fc3c-859d-4f3d-b856-39b2deddfef5">

	

## Estructura de un Programa tipo: 
## Antes de .net 6 
Antes de .net 6 las clases que corrían por consola, se veían:  
```cs
using System; // Namespace de la BCL que permite utilizar la clase Console 
  
namespace BuisnessLogic; // Namespace actual
  
class  Program {  // Clase Program, la cual tiene metodo statico Main
    static void Main(string[] args)  // metodo que se corre cuando ejecutamos
    {        
	    Console.WriteLine("Hola Mundo");  
        Console.ReadLine();  
    }    
}
```

- Después de la versión .net 6 se introdujeron el `global using`, el cual los proyectos ya por defecto trae él  `System` importado.
- También ya no es necesario especificar el `namespace` del archivo inicial.
- Y No es necesario especificar la `class Program` ni el método estático `main`
### Después de .net 6:

![[Pasted image 20240901160005.png]]
### Tipos de datos

```cs
void CommonTypes()
{
    bool boolean = true;
    decimal decimalNumber = 123.45m;
    byte byteValue = 255;
    string text = "Hola Mundo";
    object object = new object();
    int integerValue = 42;
    float floatValue = 3.14f;
	List<string> otherTypes = new List<string> { "sbyte", "uint", "ulong", "char", "double", "long", "short", "ushort" };
} ```

## Clases
- Una clase es un plano o template la cual define la estructura y comportamiento de un objeto, estas se utilizan en OOP para definir nuestras entidades, agrupar lógica, comportamientos similares, entre otras cosas.
### Definición de una clase
```cs
public class Vehicle
{
}
```
###  Instancia de una clase
- Es un objeto especifico de una clase, por ejemplo un auto en particular:
```cs
Vehicle aCar = new Vehicle()
```
#### Constructor
- Cuando creamos una instancia de una clase (`new Vehicle()`), podemos definir un `constructor` dentro de la clase para que se ejecute, y corra el código de dentro.
- Puede haber más de un `constructor` por clase, con distintos parámetros. Pero **todos** tendrán el nombre igual que la `clase`. (polimorfismo)
![[Pasted image 20240901161419.png]]
- Tener múltiple constructor nos permite, tener más de 1 manera de instancia la clase y que cada manera tenga sus propios comportamientos.

```cs
Vehicle aCar = new Vehicle() //Imprime "this is the first constructor"
Vehicle aSecondCar = new Vehicle("test") //Imprime "this is the second constructor and it will print the test"
```

#### Constructor por defecto:
- Es el constructor vacío, es decir no ejecuta lógica, y todas las variables serán vacías. 
	- Tener cuidado con los constructores vacíos ya que deja a los atributos sin instanicar, y si referenciamos a la property no tendrá valor y podria causar una excepción
- Lo podemos modificar creando un constructor que no reciba parámetros
```cs
class Vehicle
{
	public List<string> properties;

	public Vehicle()
	{
		properties= new List<string>();// generamos la clase vacia
	}
}
```

## Destructores:
- Una clase solo puede tener un destructor.​ 
- Los destructores no se pueden heredar ni sobrecargar.​ 
- Los destructores no se pueden llamar directamente. ​Se invocan de forma automática.​
- Los destructores no reciben parámetros.
```cs
class Vehicle
{
	public ~Vehicle()
	{
	}
}
```
## Atributos: 
- Son la información o datos que se quiere tener del objeto o de la instancia. 
- Existen dos tipos principales:
	- **De instancia**: particular de cada objeto
	- **De clase**: La clase en si tiene esa propiedad (como el `Main` de `Program`), tienen el prefijo `static`, ya que es un atributo estático y no cambia por cada instancia.
```cs
namespace Domain;    
public class Vehicle  
{  
    private int _tires; // Propiedad de cada instanica de la clase
    private static int _tires; // Propiedad de la clase en si (static)
}
```

### Properties
Los attributos, no proveen ningun mecanismo para agregar comportamiento en las operaciones de get y set, entonces, si queremos hacer algun comportamiento deberiamos de hacer: 
```cs
namespace Domain;  
  
public class Vehicle  
{  
    private int _tires;  
  
    public void SetTires(int tires)  
    {        
		Console.WriteLine($"setting tires to {tires}");
	    _tires = tires;  
    }    
    public int GetTires()  
    {        
		Console.WriteLine($"getting tires");
	    return _tires;  
    }
}
```
- Y luego llamar a la instancia del `vehicle` y llamar al metodo `SetTires` o `GetTires`. 

Sin embargo, las **Properites** provén este comportamiento por defecto:
```cs
namespace Domain;  
  
public class Vehicle  
{  
    private int _tires;  
    public int Tires  
    {  
        get  
        {  
            return _tires;  
        }  
        set  
        {  
            Console.WriteLine($"setting tires with value {value}");  
            _tires = value;  
        }    
    }
}
```

- Por lo que el resto del código, no tiene que estar pendiente de si deben llamar al `vechile._tires` o `vechile.GetTires()`, sino que llamando al `vehicle.Tires` ejecutara el `get` o el `set` automáticamente.
- Algunos de los beneficios son: 
	- El resto del código no tiene que saber la implementación de la `properite`
	- Permite crear validaciones en el momento de set, asegurándose que no se agreguen valores no válidos.
	- Permite mayor control sobre los atributos
	- Permite tener distintos nivel de accesibilidad, para el get y set: 
	```cs
	public class Vehicle  
	{  
	   public int Tires { get; private set; }  
	}	
	```
	- Acá el get es público es decir, cualquiera lo puede acceder, pero el set es privado, es decir solo dentro de la instancia o de la clase se puede manipular.

### Properties Calculadas
- son propiedades ficticias, es decir que no existen y son calculadas en el momento 
```cs 
public class Vehicle
{
	public string Brand;
	public string Model;
	public string GeneralInfo{get {return $"{Brand} {Model}"}}
}
```

#### Ejemplo de validación:
```cs
namespace Domain;  
  
public class Vehicle  
{  
    private int _tires;  
    public int Tires  
    {  
        get => _tires;  
        set  
        {  
            if (value <= 1)  
            {
	            throw new ArgumentException("The tires should be more than 2");  
            }
	        _tires = value;  
        }    
    }
}
```

## Herencia
Permite tener una clase padre la cual define el comportamiento en común de sus clases, y luego sus clases hijas heredan de ella, permitiendo utilizar la logica del padre, como sus metodos y atributos.

```cs    
public class Vehicle  
{  
    public int Tires;  
    public string Color;  
  
    public void TurnOn()  
    {        
	    Console.WriteLine("turning on car");  
    }  
    public virtual void TurnOf()  
    {        
	    Console.WriteLine("turning of car");  
    }
}

public class Car : Vehicle  
{  
    public override void TurnOf()  
    {        
	    Console.WriteLine("turning of radio first");  
        base.TurnOf();  
    }
}  
  
public class Truck : Vehicle  
{  
    public bool Is4X4;  
  
    public Truck(bool Is4X4)  
    {        
	    Is4X4 = this.Is4X4;  
    }    
    public override void TurnOf()  
    {        
	    if(Is4X4)  
            Console.WriteLine("turning of 4x4");  
        base.TurnOf();  
    }
}
```
## Ejercicio:
1. Crear una aplicación de Consola en Visual Studio. Nómbrelo DA1​
2. Agregar un proyecto para el dominio​
3. Agregar una clase Vehículo al proyecto​
4. La clase deberá tener 
	1. Dos Properties; ​  
		1. tires : int
		2. color : string​
	2.  Un método Encender que no tendrá comportamiento​
5. Agregar dos clases Auto y Camioneta (que son Vehiculo) ​ 
6. Definirles aquí el método Encender que imprime en consola:​
	1. "Encendiendo auto con cantidad de puertas x y color de chasis y" ​
7. Crear un proyecto para la lógica de negocio BusinessLogic​ 
8. Crear una lista de Vehículos (que será nuestro catálogo), asignarle los valores a los campos y encenderlos​
# Asignación de Tipos:
- Son equivalentes: 
 ```cs
// Antes
 int myInt = 0
// Despues
 vat myInt = 0
//ambas son equivalentes

var myData; //variable sin asignar
myData = 1 // pasa a estar asignada y de tipo int no se puede cambiar el tipo
```
## Modificaciones de acceso
- public (+)​  El acceso no está restringido​
- protected (#)​  El acceso está limitado a la clase contenedora o a los tipos derivados de la clase contenedora.​
- private (-)​  El acceso está limitado al tipo contenedor. Propia clase.​
- internal (.NET)​ El acceso está limitado al ensamblado actual.​
*Por defecto las clases tienen visibilidad internal y los métodos private​*

# Enums
- Un tipo de enumeración o enumerado es un tipo de valor definido por un conjunto de constantes con nombre del tipo numérico integral.​
- De forma predeterminada, los valores de constante asociados de miembros de enumeración son del tipo int; comienzan con cero y aumentan en uno después del orden del texto de la definición.​
- Nos ayuda a evitar los magic strings o magic values, 

```cs
enum Brand  
{  
    Mercedes,  
    Toyota,  
    Ford,  
    Honda,  
    Chevrolet,  
    Nissan  
}
​```

## Iteradores
- Como en cualquier lenguaje *csharp* tiene iteradores alguno de estos son.
```cs
int[] numbers = { 1, 2, 3, 4, 5 };  
  
for (int i = 0; i < numbers.Length; i++)  
{  
    Console.WriteLine(numbers[i]);  
}  
  
string[] cars = { "Toyota", "Ford", "Honda" };  
  
foreach (string car in cars)  
{  
    Console.WriteLine(car);  
}  
  
int count = 0;  
while (count < 5)  
{  
    Console.WriteLine($"Count is {count}");  
    count++;
}
```

 - Pero existen muchos otros iteradores.
### Colecciones
- Es una forma de agrupar objetos relacionados​
- Matrices de Objetos ó Colecciones de objetos​
- Matrices son de tamaño fijo mientras que las Collecciones tienen tamaño dinámico​
```cs 
  
using Domain;  
  
Vehicle v = new Vehicle();  
Vehicle v1 = new Vehicle();  
Vehicle v2 = new Vehicle();  
Vehicle v3 = new Vehicle();  
  
List<Vehicle> vehicles = new List<Vehicle>() { v, v1, v2, v3 };

Vehicle v4 = new Vehicle();    
// Operaciones  
vehicles.Add(v4);  
vehicles.Remove(v1);  
vehicles.Contains(v2);  
vehicles.Clear();  
vehicles.Count();
```
## Modificadores de parametros
- Mediante el uso de la palabra clave `params`, puede especificar un parámetro de método que toma un número variable de argumentos.​  
- El tipo de parámetro debe ser una matriz unidimensional.​

## Ref y Out

```cs

// REF
int number = 5;  
  
ChangeNumber(ref number);  
void ChangeNumber(ref int number){
	number *= 2; // ahora el number sera el valor previo * 2   
}  
Console.WriteLine(number); // 10  

// OUT
int result;  
int numbera = 1;  
int numberb=2;    

AddNumbers(numbera,numberb, out result);  
Console.WriteLine(result);  

void AddNumbers(int number, int numberb, out int result)  
{ 
result = number + numberb;
}
```

