// Otro objetivo de las interfaces es tener clases que no tenga una relación alguna en su compotamiento, pueden ser clases distintas, puede que se envíe una por correo, otra por sms, otra por radiofrecuencia, etc., pero el punto es que abstractamente sabemos que se envían y ese es el objetivo de las abstracciones, minimizar solamente a que el programador sepa que existe el método enviar y no le importe cómo se envíe. Es como cuando se utiliza una biblioteca, sabemos que tiene ciertos métodos que hacen cierta tarea, pero no sabemos internamente qué pasa o cómo lo están haciendo.

namespace ObjectOrientedProgramming.Business
{
    // Algo vendible es un servicio, por ejemplo, cuando va el plomero a la casa
    public class Service : ISalable
    {
        private decimal _amount;
        private decimal _tax;

        public Service(decimal amount, decimal tax)
        {
            _amount = amount;
            _tax = tax;
        }

        public decimal GetPrice() => _amount + _tax;
    }
}
