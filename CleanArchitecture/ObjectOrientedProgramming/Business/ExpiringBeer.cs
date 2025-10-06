//! 19. Herencia
namespace ObjectOrientedProgramming.Business
{
    // La herencia permite heredar toda la funcionalidad que tiene otra clase.
    // Hay ciertas reglas que se tienen que seguir con la herencia:
    //  1. Si la clase de la que se está heredando tiene un constructor, la clase que hereda de dicha clase, tiene que tener un constructor que solicite como mínimo los valores necesarios para el constructor padre
    public class ExpiringBeer : Beer
    {
        public DateTime Expiration {  get; set; }

        // Con base se le envía (invoca) al constructor "padre" la información que está recibiendo el constructor "hijo"
        public ExpiringBeer(string name, decimal price, decimal alcohol, DateTime expiration, int quantity) : base(name, price, alcohol, quantity)
        {
            Expiration = expiration;
            // Se puede acceder a Prices que es una propiedad de la clase padre porque se definió como protected, sin embargo, no puede acceder a ella desde otra clase que no herede de Beer
            var p = Price;
        }

        //! 22. Sobreescritura
        // Para que el hijo pueda sobreescribir el método del padre, se tiene que utilizar la palabra 'override'
        public override string GetInfo()
        {
            // Si se necesita la información "original" del padre, es decir, lo que en un inicio devolvía GetInfo (sin sobreescribirse), se puede llamar a base.GetInfo()
            var infoPadre = base.GetInfo();

            // IMPORTANTE: Cuando un objeto de tipo ExpiringBeer llama a alguno de los métodos que hereda del padre y estos métodos internamente hacen uso del método sobreescrito, se va a hacer uso del método sobreescrito NO el original del padre. Es decir, recordemos que la clase Beer tiene dos métodos más GetInfo() (y ambos reciben un parámetro de distinto tipo) y estos métodos internamente están haciendo uso del método GetInfo (sin parámetros y que se está sobreescribiendo), por lo tanto, cuando un objeto ExpiringBeer haga uso de cualquiera de los dos GetInfo (con un parámetro), cuando internamente utilice el método GetInfo (sin parámetros), utilizará el método que sobreescrito (este mismo). SOLAMENTE si un ExpiringBeer llama a GetInfo, los objetos de tipo Beer no se ven afectados, porque la sobreescritura se hizo en los hijos, el padre sigue funcionando igual.
            return $"Cerveza con caducidad: {Name}, Precio: ${Price}, Alcohol: {Alcohol}, Caducidad: {Expiration.Date.ToString()}";
        }
    }
}
