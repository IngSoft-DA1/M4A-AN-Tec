using Automotive;

namespace AutomotiveLogic;

public class VehicleService
{
    public List<Vehicle> Vehicles { get; }
    
    public VehicleService()
    {
        
        Vehicles = new List<Vehicle>
        {
          new Car(4, "red", new Manufacturer(1, "Toyota", "Japan"))
          {
              Year = 2020
          },  
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
    
    public void UpdateVehicleById(int vehicleToUpdate, Vehicle updatedVehicle)
    {
        foreach (Vehicle vehicleOnTheList in Vehicles)
        {
            if (vehicleOnTheList.Id == vehicleToUpdate)
            {
                vehicleOnTheList.DoorQuanitity = updatedVehicle.DoorQuanitity;
                vehicleOnTheList.Color = updatedVehicle.Color;
                vehicleOnTheList.Year = updatedVehicle.Year;
                break; // Encontramos el vehículo
            }
        }
    }
}