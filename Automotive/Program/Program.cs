using Automotive;

var car = new Car(5, "red");
var car2 = new Car(3, "Purple");
var car3 = new Car(4, "green");
var truck = new Truck(5, "red");
var truck2 = new Truck(3, "Purple");
var truck3 = new Truck(4, "green");

List<Vehicle> list = new List<Vehicle>()
{
    car, car2, car3, truck, truck2, truck3
};

foreach (var v in list)
{
    v.TurnOn();
}