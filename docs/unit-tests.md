# Ejemplo de clase:
En el siguiente readme repasamos lo que fue el ejericio de clase.
# Estructura de la solución
```
Automotive --> Solution 
├── Automotive --> proyecto de tipo classLibary
│   ├── Car.cs 
│   ├── Truck.cs
│   └── Vehicle.cs
└── Program --> proyecto de consola
    ├── Program.cs
    └── VehicleList.cs -->  Ejemplo de uso de generics
```

Vamos a realizar unitTests de la clase `Vehicle`  de el proyecto `Automotive`
# Proyecto Automotive
- Es un proyecto de tipo class library
## Clase Vehicle
### Properties:
- `public DoorQuantity`
	- `private int _doorQuantity` -> atributo privado que usamos para guardar el valor que le pasmaos en el setter.
	- `Setter`: lo usamos para validar que no se ponga un valor negativo.  Si se pone un valor negativo levanta una *ArgumentException*
```cs
private int _doorQuantity;  
public int DoorQuanitity  
{  
	get => _doorQuantity;  
    set  
    {  
        if (value < 0)  
        { 
        throw new ArgumentException("The value must be bigger than 0");  
        }  
        _doorQuantity = value;  
    }
}		 
```

- `public int Year {get;set;}`  Variable, para fecha del auto si no es pasada al constructor se setea automaticamente en 2024. 
- `public int Color {get;set;}`  El color del auto.
```cs 
public int Year  { get; set; }  
public int Color  { get; set; }  
``` 

### Consturctor:
- Espera que si o si le pasen `doorQuantity` , `color` y `year` como tiene `int year =2024` si no se le pasa el year se pone como `2024`
```cs

    public Vehicle(int doorQuanitity, string color,int year = 2024)  
    {        DoorQuanitity = doorQuanitity;  
        Color = color;  
        Year = year;  
    }  
```

### Metodo TurnOn
- **`TurnOn()`**: Método virtual para encender el vehículo; puede ser sobrescrito. Y es sobre escrito tanto en `Car` como en `Truck`
```cs
public virtual void TurnOn()  
{
    Console.WriteLine("Remember to override this method to print the correct information");  
}  
```

## Metodo CalculatePrice:
- metodo nuevo que calcula el precio a partir del año
- Recibe 
	- `depreciation`: % anual de depreciación
	- `valuePerDoor`: el precio que suma por puerta.
- Tiene una condición de if que chequea que el valor no sea negativo
```cs
public double calculatePrice(double depreciation, int valuePerDoor = 5)  
{  
    var actualYear = DateTime.Now.Year;  
    var totalPrice = _doorQuantity * valuePerDoor;  
    var priceValueToDiscount = totalPrice*(actualYear - Year)*depreciation ;  
    if (totalPrice - priceValueToDiscount <= totalPrice * 0.1) return totalPrice * 0.1;  
    return totalPrice - priceValueToDiscount;  
}
```


## Toda la clase 

```cs 
namespace Automotive;  
  
public class Vehicle  
{  
    private int _doorQuantity;  
    public int DoorQuanitity  
    {  
        get => _doorQuantity;  
        set  
        {  
            if (value < 0)  
            {
	            throw new ArgumentException("The value must be bigger than 0");  
            }  
            _doorQuantity = value;  
        }
    }
    public string Color { get; set; }  
    public int Year  { get; set; }  
  
    public Vehicle(int doorQuanitity, string color,int year = 2024)  
    {        DoorQuanitity = doorQuanitity;  
        Color = color;  
        Year = year;  
    }  

    public virtual void TurnOn()  
    {
    Console.WriteLine("Remember to override this method to print the correct information");  
    }    

	public double calculatePrice(double depreciation, int valuePerDoor = 5)  
	{  
	    var actualYear = DateTime.Now.Year;  
	    var totalPrice = _doorQuantity * valuePerDoor;  
	    var priceValueToDiscount = totalPrice*(actualYear - Year)*depreciation ;  
	    if (totalPrice - priceValueToDiscount <= totalPrice * 0.1) return totalPrice * 0.1;  
	    return totalPrice - priceValueToDiscount;  
	}
}
```

## Car y Truck
- Ambas clases son similares heredan de `vehicle` (`Car : Vehicle`)
- Se usa el `base(doorQuantity, color)` para llamar al consturctor de la clase `Vehicle`
- `TurnOn()`:  tiene la palabra clave  `override` par poder sobreseciribr el metodo del parent
```cs
using Automotive;  
  
public class Car : Vehicle  
{  
    public Car(int doorQuanitity, string color) : base(doorQuanitity, color)  
    { }  
    public override void TurnOn()  
    {        
	    Console.WriteLine($"This car is of color {Color} and has {DoorQuanitity} doors");  
    }
}
```

## Unit tests
- Para realizar los tests agregamos un proyecto `unitTests` de tipo `MSTEST`.
- La estructura de este proyecto siempre tiene que ser identica a el proyecto que van a testear pero poniendo `tests` alfinal del archivio, en nuestro proyecto:
```
Automotive
├── Automotive
│   ├── Car.cs
│   ├── Truck.cs
│   └── Vehicle.cs
│
├── Automotive.Tests
│   ├── Usings.cs
│   └── VehicleTests.cs
│
└── Program
    ├── Dockerfile
    ├── Program.cs
    └── VehicleList.cs
``` 


### Clase `VehicleTests`
- **`[TestClass]`**: Marca la clase como una clase de pruebas para el framework `MSTest`, indicando que contiene métodos que deben ejecutarse como pruebas.
- Clase que contiene los métodos de prueba para validar la funcionalidad de la clase `Vehicle`.
### Inicialización
- **`[TestInitialize]`**: Se ejecuta antes de cada método de prueba para preparar el entorno de pruebas, como inicializar variables o configurar el estado necesario.
- **`Set_Values()`**: Método de inicialización que se ejecuta antes de cada prueba.
  - Establece los valores iniciales de `Depreciation` (depreciación) y `ValuePerDoor` (valor por puerta) utilizados en varias pruebas.

```csharp
[TestInitialize]
public void Set_Values()
{
    Depreciation = 0.1;
    ValuePerDoor = 10;
}
```

### Métodos de Prueba
- **`[TestMethod]`**: Marca un método como una prueba unitaria que debe ser ejecutada por el framework de pruebas.
- **`Test_DoorQuantity_Positive_Number()`**: Verifica que se pueda asignar correctamente un número positivo a la propiedad `DoorQuantity` del vehículo.
  - **Arrange**: Declaración del objeto `Vehicle`.
  - **Act**: Inicializa el vehículo con 5 puertas y color "purple".
  - **Assert**: Verifica que `DoorQuanitity` sea igual a 5.

```csharp
[TestMethod]
public void Test_DoorQuantity_Positive_Number()
{
    // Arrange
    Vehicle vehicle;
    // Act 
    vehicle = new Vehicle(5, "purple");
    // Assert
    Assert.AreEqual(5, vehicle.DoorQuanitity);
}
```

- **`Test_DoorQuantity_Negative_Number()`**: Prueba que asignar un número negativo a `DoorQuantity` lanza una excepción.
	- - **`[ExpectedException]`**: Se usa para indicar que un método de prueba debería lanzar una excepción específica; si la excepción no se lanza, la prueba falla.
  - **Arrange**: Declaración del objeto `Vehicle`.
  - **Act**: Intenta inicializar el vehículo con -5 puertas.
  - **Assert**: Espera una excepción del tipo `ArgumentException`.

```csharp
[TestMethod]
[ExpectedException(typeof(ArgumentException))]
public void Test_DoorQuantity_Negative_Number()
{
    // Arrange
    Vehicle vehicle;
    // Act 
    vehicle = new Vehicle(-5, "purple");
}
```

- **`Test_CALCULATE_PRICE()`**: Verifica que el cálculo del precio sea correcto para un vehículo del año 2024.
  - **Arrange**: Inicializa un vehículo con 5 puertas, color "purple", y año 2024.
  - **Act**: Calcula el precio usando los valores de depreciación y valor por puerta establecidos.
  - **Assert**: Verifica que el precio calculado sea 50.

```csharp
[TestMethod]
public void Test_CALCULATE_PRICE()
{
    // Arrange 
    var vehicle = new Vehicle(5, "purple", 2024);
    // Act
    var price = vehicle.calculatePrice(Depreciation, ValuePerDoor);
    // Assert
    Assert.AreEqual(50, price);
}
```

- **`Test_CALCULATE_PRICE_2023()`**: Verifica el cálculo del precio para un vehículo del año 2023.
  - **Arrange**: Inicializa un vehículo con 5 puertas, color "purple", y año 2023.
  - **Act**: Calcula el precio.
  - **Assert**: Verifica que el precio calculado sea 45.

```csharp
[TestMethod]
public void Test_CALCULATE_PRICE_2023()
{
    // Arrange
    var vehicle = new Vehicle(5, "purple", 2023);
    // Act
    var price = vehicle.calculatePrice(Depreciation, ValuePerDoor);
    // Assert
    Assert.AreEqual(45, price);
}
```

- **`Test_CALCULATE_PRICE_TOO_OLD_TRIGGER_LIMIT()`**: Prueba que el precio mínimo del vehículo no baje del 10% del valor inicial cuando el vehículo es muy antiguo.
  - **Arrange**: Inicializa un vehículo con 5 puertas, color "purple", y año 1980.
  - **Act**: Calcula el precio.
  - **Assert**: Verifica que el precio calculado sea 5.

```csharp
[TestMethod]
public void Test_CALCULATE_PRICE_TOO_OLD_TRIGGER_LIMIT()
{
    // Arrange
    var vehicle = new Vehicle(5, "purple", 1980);
    // Act
    var price = vehicle.calculatePrice(Depreciation, ValuePerDoor);
    // Assert
    Assert.AreEqual(5, price);
}
```

## Ejercicio de clase
(La solución a este se encuentra dentro de examples)
1. Crear una class Library
	1. Agregar una clase `Person`
		1. Con **Properties**: *Name, LastName* (no pueden ser vacios)
		2.  Agregar las **computed properties FullName** 
2. Crear una test project que sea **MSTEST** 
	1. Crear tests Para Name (revisar que caiga la excepción y no)
	1. Crear tests de validación para FullName
3. Crear metodo nuevo que calcule el largo de el full name y si es mas corto que 5 letras que levante una excepción.
4. Agregar los tests correspondientes.
