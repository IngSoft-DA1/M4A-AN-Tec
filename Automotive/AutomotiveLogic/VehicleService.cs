using Automotive;

namespace AutomotiveLogic;

public class VehicleService
{
    public List<Vehicle> Vehicles { get; }
    public List<Manufacturer> Manufacturers  { get; }
    
    public VehicleService()
    {
        Manufacturers = new List<Manufacturer>
        {
            new Manufacturer(1, "Toyota", "Japan"),
            new Manufacturer(2, "Ford", "USA"),
            new Manufacturer(3, "Volkswagen", "Germany")
        };
        
        Vehicles = new List<Vehicle>
        {
            new Car(4, "red", Manufacturers[0]) { Year = 2020 },  
        };
    }
    
    public void AddVehicle(Vehicle vehicle)
    {
        Vehicles.Add(vehicle);
    }
    
    public void RemoveVehicle(Vehicle vehicle)
    {
        Vehicles.Remove(vehicle);
    }
    
    public void RemoveVehicleById(int id)
    {
        var vehicle = Vehicles.FirstOrDefault(v => v.Id == id);
        if (vehicle != null)
        {
            Vehicles.Remove(vehicle);
        }
    }
    
    public void UpdateVehicleById(int vehicleToUpdate, Vehicle updatedVehicle)
    {
        var vehicle = Vehicles.FirstOrDefault(v => v.Id == vehicleToUpdate);
        if (vehicle != null)
        {
            vehicle.DoorQuanitity = updatedVehicle.DoorQuanitity;
            vehicle.Color = updatedVehicle.Color;
            vehicle.Year = updatedVehicle.Year;
            vehicle.Manufacturer = updatedVehicle.Manufacturer;
        }
    }
}