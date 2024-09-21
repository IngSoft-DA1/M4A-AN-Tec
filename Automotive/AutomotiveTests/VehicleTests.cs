
namespace AutomotiveTests;

[TestClass]
public class VehicleTests
{
    private double Depreciation;
    private float PricePerDoor;
    [TestInitialize]
    public void InitializeAttributes()
    {
        this.Depreciation = 0.1;
        this.PricePerDoor = 10;
        
    }
    [TestMethod]
    public void DoorQuantitySet_ValidDoors()
    {
        // arrange
        Vehicle v;
        // act
        v = new Vehicle(5, "red");
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
        v = new Vehicle(0, "red");

    }

    [TestMethod]
    public void CarInfo_Correct()
    {
        // arrange
        Car v;
        // act 
        v = new Car(5, "red");
        //
        Assert.AreEqual($"This car is of color {v.Color} and has {v.DoorQuanitity} doors", v.InformationColorQuantity());
    }

    [TestMethod]
    public void CalculatePrice_Successfully()
    {
        // arrange
        Vehicle v = new Vehicle(5, "red");
        
        //act
        var price = v.CalculatePrice(PricePerDoor, Depreciation);
        //assert
        Assert.AreEqual(50, price);
    }
    [TestMethod]
    public void CalculatePrice_Base_Price()
    {
        // arrange
        Vehicle v = new Vehicle(5, "red", 1980);
        //act
        var price = v.CalculatePrice(PricePerDoor, Depreciation);
        //assert
        Assert.AreEqual(5, price);
    }
}