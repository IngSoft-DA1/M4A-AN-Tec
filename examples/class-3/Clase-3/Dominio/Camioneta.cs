using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Camioneta : Vehiculo
    {
        public Camioneta(int cantPuertas, string colorChasis) : base(cantPuertas, colorChasis)
        {
        }

        public override void Encender()
        {
            Console.WriteLine("Encenciendo camioneta con" + " " + $"{CantPuertas}" + " " + "puertas" + " " + "y color de chasis" + " " + $"{ColorChasis}");
        }
    }
}
