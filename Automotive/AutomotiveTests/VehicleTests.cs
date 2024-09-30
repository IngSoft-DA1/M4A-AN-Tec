
namespace AutomotiveTests;

[TestClass]
public class VehicleTests
{
    private double Depreciation;
    private float PricePerDoor;
    private Manufacturer _toyota;
    
    [TestInitialize]
    public void InitializeAttributes()
    {
        this.Depreciation = 0.1;
        this.PricePerDoor = 10;
        this._toyota = new Manufacturer(1, "Toyota", "Japan");
    }
    [TestMethod]
    public void DoorQuantitySet_ValidDoors()
    {
        // arrange
        Vehicle v;
        // act
        v = new Vehicle(5, "red", _toyota);
        //assert
        Assert.AreEqual(5,v.DoorQuanitity);

    }
    
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void DoorQuantitySet_Invalid0Doors()
    {
        // arrange
        Vehicle v;
        // act
        v = new Vehicle(0, "red", _toyota);

    }

    [TestMethod]
    public void CarInfo_Correct()
    {
        // arrange
        Car v;
        // act 
        v = new Car(5, "red",_toyota);
        //
        Assert.AreEqual($"This car is of color {v.Color} and has {v.DoorQuanitity} doors", v.InformationColorQuantity());
    }

    [TestMethod]
    public void CalculatePrice_Successfully()
    {
        // arrange
        Vehicle v = new Vehicle(5, "red", _toyota);
        
        //act
        var price = v.CalculatePrice(PricePerDoor, Depreciation);
        //assert
        Assert.AreEqual(50, price);
    }
    [TestMethod]
    public void CalculatePrice_Base_Price()
    {
        // arrange
        Vehicle v = new Vehicle(5, "red", _toyota, 1980);
        //act
        var price = v.CalculatePrice(PricePerDoor, Depreciation);
        //assert
        Assert.AreEqual(5, price);
    }
}