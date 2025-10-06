//! 26. Generics

// En los lenguajes fuertemente tipados, los generics sirven bastante para que podamos reutilizar funcionamientos que no estén ligados a un tipo, por ejemplo, supongamos que tenemos una clase que maneja una colección de elementos que son números enteros, pero necesitamos ese mismo funcionamiento para elementos que son strings o elementos que son objetos, entonces para evitar tener una clase de cada tipo, utilizamos un generic: los generics nos ayudan a reutlizar código.
namespace ObjectOrientedProgramming.Business
{
    // Con '<T>' le indicamos que vamos a trabajar con un tipo genérico (se puede usar cualquier letra, pero por convención se usa T). T es un alias del tipo que estamos manejando (desconocemos el tipo de dato que se enviará)
    public class Collection<T>
    {
        private T[] _elements;
        private int _index;
        private int _limit;

        public Collection(int limit)
        {
            _index = 0;
            _limit = limit;
            _elements = new T[_limit];
        }

        public void Add(T element)
        {
            if (_index < _limit)
            {
                _elements[_index++] = element;
            }
        }

        public T[] Get() => _elements;
    }
}
