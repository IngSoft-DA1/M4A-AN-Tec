

namespace Automotive;

public class Car : Vehicle
{
    public Car(int doorQuanitity, string color) : base(doorQuanitity, color)
    {
    }

    public override void TurnOn()
    {
        Console.WriteLine($"This car is of color {Color} and has {DoorQuanitity} doors");
    }
}