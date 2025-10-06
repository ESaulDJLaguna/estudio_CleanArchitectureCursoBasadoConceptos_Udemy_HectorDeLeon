//! 18. Espacios de nombres (Namespace)
namespace ObjectOrientedProgramming.Business
{
    public class Beer : Drink, ISalable, ISend
    {
        private const string Category = "Cerveza";
        private decimal _alcohol;
        public string Name { get; set; }
        //! 20. Encapsulamiento
        // Cuando algo es privado SOLAMENTE se puede acceder a esa información desde la misma clase, nisiquiera las clases que heredan de ella pueden acceder a un elemento privado
        // protected: se utiliza para que un elemento pueda ser accedido por la misma clase y las que hereden de la misma, pero no puede ser utilizado en ninguna otra clase
        protected decimal Price { get; set; }

        //! 27. Static
        // Esta propiedad pertenece a la clase y para utilizarla no se necesita un objeto. Esta nos permitirá saber cuántos objetos se han creado de la clase Beer
        public static int QuantityObjets;
        public decimal Alcohol
        {
            get { return _alcohol; }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                _alcohol = value;
            }
        }
        public string SAlcohol
        {
            get
            {
                return "Alcohol: " + _alcohol.ToString();
            }
        }

        public Beer(string name, decimal price, decimal alcohol, int quantity) : base(quantity)
        {
            Name = name;
            Price = price;
            Alcohol = alcohol;

            QuantityObjets++;
        }

        //! 22. Sobreescritura
        // Hay una cualidad que tienen los lenguajes con paradigma orientado a objetos, la cual es la sobreescritura de métodos.
        // La sobreescritura permite que un hijo (una clase que hereda de otra) puede tener un método que sobreescribe al del padre. Para que la clase padre permita que uno de sus métodos sea sobreescrito, se debe utilizar la palabra 'virtual', mientras que en el hijo se usa la palabra 'override'.
        // Solo los métodos que tengan 'virtual' podrán ser sustituidos, es decir, los otros dos GetInfo NO pueden ser sobreescritos por los hijos.
        public virtual string GetInfo()
        {
            return $"Nombre: {Name}, Precio: ${Price}, Alcohol: {Alcohol}";
        }

        //! 21. Sobrecarga
        // La sobrecarga es una característica que tienen los lenguajes de programación orientada a objetos que permite que un método pueda tener distintos comportamiento dependiendo de la entrada de información. Es decir, se puede tener un método que se llame igual pero que tenga una entrada de información distinta.
        // En la sobre carga NO importa el número de parámetros sino el tipo del mismo. Puede observarse que existen dos GetInfo que solo reciben un parámetro pero de distinto tipo.
        public string GetInfo(string message)
        {
            return message + " " + GetInfo();
        }

        public string GetInfo(int number)
        {
            return number + ".- " + GetInfo();
        }

        // La clase abstracta Drink está exigiendo que exista un método "GetCategory" y para especificar este método que tiene que ser implementado al igual que con los métodos que pueden ser sustituidos, se utiliza la palabra override
        public override string GetCategory()
        {
            return Category;
        }

        public decimal GetPrice() => Price;

        public void Send() => Console.WriteLine($"Se envía por correo: {GetInfo()}");
    }
}
