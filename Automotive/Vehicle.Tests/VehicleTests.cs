namespace Vehicle.Tests;
using Automotive;

[TestClass]
public class VehicleTests
{
    private double Depreciation;
    private double PricePerDoor;
    [TestInitialize]
    public void On_Initialise()
    {
        Depreciation = 0.1;
        PricePerDoor = 5;

    }
    [TestMethod]
    public void Test_DoorQuantity_FIVE()
    {
        // arrange
        Vehicle vehicle;
        //act
        vehicle = new Vehicle(5, "red");
        //assert
        Assert.AreEqual(5, vehicle.DoorQuanitity);
    }
    
    [TestMethod]
    public void Test_DoorQuantity_ZERO()
    {
        // arrange
        Vehicle vehicle;
        //act
        vehicle = new Vehicle(5, "red");
    }

    [TestMethod]
    public void Test_CalculatePrice_Valid()
    {
       //arrange 
        Vehicle vehicle = new Vehicle(5, "red");
        // act 
        var res = vehicle.CalculatePrice(PricePerDoor, Depreciation);
        
        //assert
        Assert.AreEqual(50,res);

    }
    [TestMethod]
    public void Test_CalculatePrice_TOP()
    {
       //arrange 
        Vehicle vehicle = new Vehicle(5, "red", 1980);
        // act 
        var res = vehicle.CalculatePrice(PricePerDoor, Depreciation);
        
        //assert
        Assert.AreEqual(5,res);

    }
}