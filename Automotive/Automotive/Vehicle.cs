namespace Automotive;

public class Vehicle
{
    private int _doorQuantity;
    private int _id;
    
    public int Id {
        get => _id;
        set => _id = value;
    }
    
    public int Year {
        get;
        set;
    }

    public int DoorQuanitity
    {
        get => _doorQuantity;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("We cant have a car with less than 1 door");
            }

            _doorQuantity = value;

        }
    }

    public string Color { get; set; }

    public Vehicle(int doorQuanitity, string color, int year = 2024)
    {
        DoorQuanitity = doorQuanitity;
        Color = color;
        Year = year;
    }

    public virtual void TurnOn()
    {
        Console.WriteLine("Remember to override this method to print the correct information");
        
    }

    public double CalculatePrice(double pricerPerDoor, double depreciationPerYear)
    {
        var totalPrice = pricerPerDoor * DoorQuanitity;
        var actualYear = DateTime.Now.Year;
        var discountPrice = depreciationPerYear * (actualYear - Year) * totalPrice;
        if (totalPrice-discountPrice <= 0)
        {
            return totalPrice * 0.1;
        }
        return totalPrice - discountPrice;
    }
}