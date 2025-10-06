//! 24. Polimorfismo con clases abstractas

// En la POO existe algo llamado polimorfismo que es una cualidad que se tiene en los objetos para tener comportamientos distintos dependiendo ciertas circunstancias.

// Anteriormente ya vimos algo de polimorfismo cuando se vio la sobrecarga de métodos, porque vimos que dependiendo del tipo de entrada se van a comportar de una u otra forma. También la sobreescritura de métodos es un tipo de polimorfismo.

// Con las clases abstractas también se puede aplicar otro tipo de polimorfismo con la cual definiendo el tipo de objeto derivado de esta vamos a definir su comportamiento

namespace ObjectOrientedProgramming.Business
{
    public class Wine : Drink
    {
        private const string Category = "Vino";

        public Wine(int quantity) : base(quantity)
        {
            
        }

        public override string GetCategory() => Category;
    }
}
