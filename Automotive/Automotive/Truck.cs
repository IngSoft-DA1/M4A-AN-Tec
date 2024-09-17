
namespace Automotive;

public class Truck: Vehicle
{
    public Truck(int doorQuanitity, string color) : base(doorQuanitity, color)
    {
    }
    
    public override void TurnOn()
    {
        Console.WriteLine($"This truck is of color {Color} and has {DoorQuanitity} doors");
    }
}