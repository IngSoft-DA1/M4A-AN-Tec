namespace Dominio
{
    public class Vehiculo
    {
        public int CantPuertas {  get; set; }
        public string ColorChasis { get; set; }

        public Vehiculo(int cantPuertas, string colorChasis)
        {
            CantPuertas = cantPuertas;
            ColorChasis = colorChasis;
        }

        public virtual void Encender() { }

    }
}
