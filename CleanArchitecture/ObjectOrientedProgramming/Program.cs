//!-------------------------------------------------------------------------------- "15. Clases y objetos" y "16. Método Constructor"
/*
//! 15. Clases y objetos
Beer erdingerBeer = new Beer()
{
    Name = "Erdinger",
    Price = 3,
};
var coronaBeer = new Beer("Corona", 1.5m);

Console.WriteLine(erdingerBeer.Name);
Console.WriteLine($"{coronaBeer.Name} ${coronaBeer.Price}");
Console.WriteLine(erdingerBeer.GetInfo());

public class Beer
{
    // { get; set; }: significa que públicamente cualquier entidad fuera de esta clase pueda acceder a esa información y pueda darle información. Esto nos permite proteger información.
    public string Name { get; set; }
    public decimal Price { get; set; }

    //! 16. Método Constructor
    public Beer(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public Beer() { }

    public string GetInfo()
    {
        return $"Nombre: {Name}, Precio: ${Price}";
    }
}
*/




//!-------------------------------------------------------------------------------- "17. Campos y propiedades"
/*
//! 17. Campos y propiedades
Beer erdingerBeer = new Beer("Erdinger", 3, -2);

Console.WriteLine(erdingerBeer.GetInfo());
Console.WriteLine(erdingerBeer.SAlcohol);

public class Beer
{
    // Un campo NO tiene los accesos get y set. Una convención dicta que los campos privados llevan guion bajo al inicio. Un capo sirve para almacenar información.
    // ¿Por qué existen campos y propiedades? Una propiedad es una manera de almacenar información con une extra de flexibilidad. Ese extra de flexibilidad es poder evaluar los valores antes de retornarlos y antes de asignarlos.
    // Los campos pueden tener una propiedad de respaldo, en este caso su propiedad de respaldo sería Alcohol (por convención debe tener el mismo nombre, pero iniciando con mayúscula y sin guion bajo)
    private decimal _alcohol;
    public string Name { get; set; }
    public decimal Price { get; set; }
    // ¿Cuál es la diferencia entre la propiedad Alcohol y Name o Price? Como podemos observar, 'Name' y 'Price' NO tienen un campo de respaldo, porque los que hicieron C#, vieron que a veces era innecesario crear un campo de respaldo cuando simplemente se necesitaba guardar información sin transformarla, entonces, lo que se hizo fue crear unas propiedades llamadas "Implementadas automáticamente", las cuales nos ahorra poner el campo
    public decimal Alcohol
    {
        // Se regresa directamente el campo
        get { return _alcohol; }
        set
        {
            // Cuando se quiere asignar se va a evaluar algo. Existe una palabra clave que permite identificar cuál es el valor antes de ser asignado, la cual es value.
            if (value < 0)
            {
                value = 0;
            }
            _alcohol = value;
        }
    }
    // Es una propiedad que representaría la transformación del elemento pero sin modificar el elemento como tal, es decir, solo nos permite darle un formato. Como NO tiene un set, no permite modificar el campo
    public string SAlcohol
    {
        get
        {
            return "Alcohol: " + _alcohol.ToString();
        }
    }

    public Beer(string name, decimal price, decimal alcohol)
    {
        Name = name;
        Price = price;
        Alcohol = alcohol;
    }

    public string GetInfo()
    {
        return $"Nombre: {Name}, Precio: ${Price}, Alcohol: {Alcohol}";
    }
}
*/




//!-------------------------------------------------------------------------------- "18. Espacios de nombres (Namespace)"
//! 18. Espacios de nombres (Namespace)
// Los namespace permiten encapsular (organizar) un conjunto de clases en un paquete y de esa manera cuando se necesite la clase, se tiene que asignar el paquete. Además que es una manera muy práctica para no tener tanto código en un mismo archivo.
// Para crear un namespace en C# basta con crear una nueva carpeta y darle un nombre
using ObjectOrientedProgramming.Business;

Beer erdingerBeer = new Beer("Erdinger", 3, -2, 1000);
Console.WriteLine(erdingerBeer.GetInfo());




//!-------------------------------------------------------------------------------- "19. Herencia"
// Es una forma de reutilizar algo ya hecho en una clase y poder extender ese funcionamiento
var delirium = new ExpiringBeer("Delirium", 4, 8, new DateTime(2025, 12, 1), 330);
Console.WriteLine(delirium.GetInfo());
Console.WriteLine(delirium.GetInfo("Una cerveza que caduca:"));
Console.WriteLine(delirium.GetInfo(2));

//! NO se puede crear un objeto de tipo abstracto (Drink) realizando una instancia del tipo abstracto (new Drink())...
//x Drink drink = new Drink(1000);
//! ... lo que sí se puede hacer es crear un objeto de tipo Drink a partir de una clase que hereda de Drink (new Beer()). El único inconveniente es que solamente se tendrá la funcionalidad que tiene Drink (todo lo que se trabajó dentro de Beer no podrá ser utilizado por el objeto drink)
// Drink drink = new Beer("Erdinger", 3, -2, 1000);




//!-------------------------------------------------------------------------------- "24. Polimorfismo con clases abstractas"
Drink drink = new Wine(500);
Show(drink);
// Lo que permite el polimorfismo es que el objeto ya creado (drink) se le puede cambiar a otro objeto derivado
drink = new Beer("Corona", 2, 4, 330);
Show(drink);

// Sabemos que lo que se envíe como Drink tiene un método GetCategory() porque Drink me obliga a que todo lo que herede de Drink tenga que tener un método llamado GetCategory el cual ya tenga comportamiento hecho.
void Show(Drink drink) => Console.WriteLine(drink.GetCategory());




//!-------------------------------------------------------------------------------- "25. Interfaces"
SendSome(erdingerBeer);

// NO se puede enviar 'drink', a pesar de que se esté inicializando con un 'new Beer()', esto es porque cuando se define un objeto de tipo clase abstractra (Drink), solo tendrá los comportamientos de dicha clase
//SendSome(drink);

var service = new Service(100, 10);

ISalable[] concepts = [ erdingerBeer, delirium, service ];

Console.WriteLine(GetTotal(concepts));

// Se recibirá some ("algo") que sea de la interfaz ISend. Ya sabemos que TODAS las clases que implementen ISend tienen un método llamado "Send", no sabemos qué hace internamente, pero sabemos abstractamente que tienen dicho método
void SendSome(ISend some)
{
    Console.WriteLine("Hago algo");
    // El objetivo es que cualquier objeto que tenga una clase que implemente ISend, va a tener un método llamado Send, el cual podría tener un comportamiento distinto de un objeto a otro objeto de otro tipo de clase, pero lo que me interesa es que exista esta estructura, un método que no reciba ni retorne nada, eso es lo que me interesa de la interefaz: categorizar algo.
    some.Send();
    Console.WriteLine("Hago algo más");
}

decimal GetTotal(ISalable[] concepts)
{
    decimal total = 0;

    foreach (var concept in concepts)
    {
        total += concept.GetPrice();
    }

    return total;
}




//!-------------------------------------------------------------------------------- "26. Generics"
var elements = new Collection<int>(3);
elements.Add(100);
elements.Add(150);
elements.Add(200);
elements.Add(500);

foreach (var element in elements.Get())
{
    Console.WriteLine(element);
}

var names = new Collection<string>(2);
names.Add("Héctor");
names.Add("Ana");
names.Add("Juan");

foreach (var name in names.Get())
{
    Console.WriteLine(name);
}

var beers = new Collection<Beer>(2);
beers.Add(erdingerBeer);
beers.Add(delirium);
foreach (var beer in beers.Get())
{
    Console.WriteLine(beer.GetInfo());
}




//!-------------------------------------------------------------------------------- "27. Static"
// Una propiedad estática, es una propiedad que pertence a la clase NO al objeto
Console.WriteLine($"Objetos creados de tipo {typeof(Beer).Name}: {Beer.QuantityObjets}");

// También pueden existir métodos estáticos. Esto nos permite definir método que hagan algo, pero que no necesitamos un objeto para utilizarlos porque no nos interesa que se lleve todo el ciclo de vida de un objeto
Console.WriteLine(Operations.Add(1, 2));
Console.WriteLine(Operations.Mul(10, 20));