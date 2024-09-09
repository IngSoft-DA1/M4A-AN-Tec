
using Dominio;

List<Vehiculo> listaVehiculos = new List<Vehiculo>();

Auto auto = new Auto(4, "rojo");
Camioneta camioneta = new Camioneta(5, "verde");

listaVehiculos.Add(auto);
listaVehiculos.Add(camioneta);

foreach (var vehiculo in listaVehiculos)
{
    vehiculo.Encender();
}