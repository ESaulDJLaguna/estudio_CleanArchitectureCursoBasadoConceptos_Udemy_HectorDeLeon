//! 23. Clases abstractas
// La abstracción en la programación es enfocarnos en lo que hacen las cosas y no cómo las hacen. Por ejemplo, cuando se utiliza una biblioteca para realizar operaciones matemáticas, solamente se invoca la función que realiza una operación, pero no nos preocupamos de cómo se hace internamente, eso es la abstracción, es decir, que sepamos que existe algo que hace algo pero no cómo lo hace.

// Gracias a las clases abstractas y otros elementos que tiene la POO podemos hacer ese tipo de abstracciones en la programación para poder tener nuestras funcionalidades encapsuladas en métodos y simplemente enfocarnos en que existe un método que retorna X y recibe Y, pero sin preocuparnos que hay internamente, pero yo puedo reutilizar esos métodos.

// Las clases abstractas son clases comúnes y corrientes, pero tienen la peculiaridad de que no puden utilizarse para crear objetos. Una clase abstracta ayuda a organizar el código. Tenemos que hacer las clases abstractas de lo más básico que NO va a cambiar. En nuestros ejemplos de Cerveza, lo más básico o que nunca va a cambiar, es que una cerveza es un líquido

namespace ObjectOrientedProgramming.Business
{
    public abstract class Drink
    {
        public int Quantity { get; set; }

        // Las clases abstractas pueden tener constructores a pesar de que no sirvan para crear objetos, porque los que herende de este constructor, van a tener que enviar esa información a la clase de que la questán heredando (la clase abstracta)
        public Drink(int quantity)
        {
            this.Quantity = quantity;
        }

        // También pueden tener métodos para poder reutilizarlos
        public string GetQuantity()
        {
            return $"{Quantity} ml";
        }

        // Otra particularidad que tienen es que se pueden crear métodos que no tengan un funcionamiento, simplemente se específica que este método tiene que existir en quien hereda
        public abstract string GetCategory();
    }
}
