using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Auto : Vehiculo
    {
        public Auto(int cantPuertas, string colorChasis) : base(cantPuertas, colorChasis)
        {
        }

        public override void Encender()
        {
            Console.WriteLine("Encenciendo auto con"+" "+ $"{CantPuertas}"+" "+"puertas"+" "+"y color de chasis"+" "+$"{ColorChasis}");
        }
    }
}
