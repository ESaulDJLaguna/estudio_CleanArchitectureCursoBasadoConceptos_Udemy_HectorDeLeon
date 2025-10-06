//! 25. Interfaces

// Las interfaces son la base de la arquitectura de software.

// Una interfaz es una entidad la cual nos permite categorizar las clases. Un problema con la herencia en C#, es que no podemos heredar de distintas clases, para esto podemos utilizar las interfaces. Pero las interfaces tienen otro propósito. Una interfaz es un contrato, que al implementarlo, estamos obligados a realizar ciertas cosas que están dentro de la interfaz, estas pueden ser propiedades, métodos y el objetivo de esto es que cuando estamos trabajando con arquitectura de software, es conveniente depender de abstracciones (una abstracción en programación es enfocarnos simplemente en qué es lo que hace y no cómo se hace internamente). Enfocarse en qué es lo que se hace, hará que no esté acoplado fuertemente a los elementos, por lo cual, si se necesita cambiar un elemento, no se necesita mover tanto código.
namespace ObjectOrientedProgramming.Business
{
    // Tenemos una clase llamada "Cerveza" la cual me gustaría darle cierta categorización, es decir, los objetos que sean cervezas quiero que sean algo que se pueda vender y algo que se pueda enviar. No´sabemos cómo se van a vender ni cómo se van a enviar, pero queremos que tenga esas dos acciones.
    internal interface ISalable
    {
        // Algo que sea vendible tiene que tener sí o sí un método que obtenga el precio.
        // No nos importa cómo se hará intermante el GetPrice, solamente incamos que tendremos un método GetPrice, que devolverá un decimal como resultado y que no recibe nada
        public decimal GetPrice();
    }
}
