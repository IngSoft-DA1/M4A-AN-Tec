
namespace Automotive;

public class Truck: Vehicle
{
    public Truck(int doorQuantity, string color, Manufacturer manufacturer) : base(doorQuantity, color, manufacturer)
    {
    }
    
    public override void TurnOn()
    {
        Console.WriteLine($"This truck is of color {Color} and has {DoorQuanitity} doors");
    }
}