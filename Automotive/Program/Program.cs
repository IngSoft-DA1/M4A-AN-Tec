using Automotive;

var manufacturer = new Manufacturer(1, "Toyota", "Japan");

var car = new Car(5, "red", manufacturer);
var car2 = new Car(3, "Purple", manufacturer);
var car3 = new Car(4, "green", manufacturer);
var truck = new Truck(5, "red", manufacturer);
var truck2 = new Truck(3, "Purple", manufacturer);
var truck3 = new Truck(4, "green", manufacturer);

List<Vehicle> list = new List<Vehicle>()
{
    car, car2, car3, truck, truck2, truck3
};

foreach (var v in list)
{
    v.TurnOn();
}