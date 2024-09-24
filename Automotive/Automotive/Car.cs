

namespace Automotive;

public class Car : Vehicle
{
    public Car(int doorQuantity, string color, Manufacturer manufacturer) : base(doorQuantity, color, manufacturer)
    {
    }

    public override void TurnOn()
    {
        Console.WriteLine($"This car is of color {Color} and has {DoorQuanitity} doors");
    }
    
    public string InformationColorQuantity()
    {
        return $"This car is of color {Color} and has {DoorQuanitity} doors";
    }
}