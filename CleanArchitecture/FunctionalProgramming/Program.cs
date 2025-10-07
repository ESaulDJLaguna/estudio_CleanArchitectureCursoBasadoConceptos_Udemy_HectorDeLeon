//!-------------------------------------------------------------------------------- "29. Función Pura"
using ObjectOrientedProgramming.Business;

Console.WriteLine("-------------------------------------------------------------------------------- '29. Función Pura'");
//! Función NO pura porque dependiendo de cuándo se ejecute, dará un resultado diferente (los segundos)
Console.WriteLine(Tomorrow());
//! Función pura porque siempre devolverá el mismo resultado
Console.WriteLine(TomorrowPure(new DateTime(2024, 05, 01, 00, 00, 00)));

var beer = new Beer("Heineken", 10, 5, 10);

//! Función NO pura porque modifica el objeto original
//Console.WriteLine(ToUpper(beer).Name);
//! Función pura porque NO modifica el objeto original
Console.WriteLine(ToUpperPure(beer).Name);
Console.WriteLine(beer.Name);

// Funciones NO puras:
DateTime Tomorrow()
{
    // No es pura porque regresa un valor difererente sin importar cuándo se ejecute, ya que los segundos siempre serán diferentes.
    return DateTime.Now.AddDays(1);
}

Beer ToUpper(Beer beer)
{
    // No es pura porque está modificando el objeto original
    beer.Name = beer.Name.ToUpper();
    return beer;
}

// Funciones pura:
DateTime TomorrowPure(DateTime date)
{
    // Es pura porque siempre va a recibir el mismo valor y por lo tanto, siempre va a devolver el mismo resultado
    return date.AddDays(1);
}

Beer ToUpperPure(Beer beer)
{
    // Es pura porque NO se modifica el objeto original, sino que se crea uno nuevo
    var beer2 = new Beer(beer.Name.ToUpper(), beer.GetPrice(), beer.Alcohol, beer.Quantity);

    return beer2;
}




//!-------------------------------------------------------------------------------- "30. Función primera clase"
// Las funciones que se tratan como variables son llamadas 'Funciones de primera clase'
Console.WriteLine("-------------------------------------------------------------------------------- '30. Función primera clase'");

// Si a una función se le agregan los paréntesis, la estaríamos ejecutando, en este caso, solo se está guardando la referencia
var t = TomorrowPure;

Console.WriteLine(t(new DateTime(2024, 05, 01, 0, 0, 0)));




//!-------------------------------------------------------------------------------- "31. Tipo Action"
Console.WriteLine("-------------------------------------------------------------------------------- '31. Tipo Action'");
//! En C# existe algo llamado delegados. Un delegado es un tipo que tiene una especificación a una función, este tipo va a especificar qué parámetros se tiene de entrada y qué valor se tiene de salida.

//! En C# ya se tiene identificados tipos definidos de delegados, uno de ellos es "Action", el cuál se utiliza para toda función que recibe parámetros pero NO retorna nada o también puede ser una función que no reciba parámetros, pero NO RETORNA NUNCA NADA.
// Utiliza Generics para especificar los parámetros de entrada
Action<string> show = Console.WriteLine;
show("Hola");




//!-------------------------------------------------------------------------------- "32. Expresión Lambda"
Console.WriteLine("-------------------------------------------------------------------------------- '32. Expresión Lambda'");
// En otros lenguajes son conocidas como funciones flecha y permiten crear funciones anónimas, es decir, funciones que NO tengan nombre.
// 'name' es el parámetro que se recibe, porque recordemos que el Action está indicando que recibe un string pero NUNCA devolverá nada
Action<string> hi = name => Console.WriteLine($"Hola {name}");

hi("Usuario");

// En versiones anteriores de C# el tipo de parámetros se tenía que definir antes de a y b, es decir, debía hacerse: (int a, int b) => 
Action<int, int> add = (a, b) => show((a + b).ToString());
add(5, 10);




//!-------------------------------------------------------------------------------- "33. Tipo Func"
Console.WriteLine("-------------------------------------------------------------------------------- '33. Tipo Func'");
//! Func tiene como propósito definir funciones que siempre van a devolver algo. Los primeros n elementos, son la entrada de información y el último SIEMPRE será el tipo de dato que retornará. Func podría NO recibir nada, por lo tanto, su único tipo sería el valor de retorno
Func<int, int, int> mul = (a, b) => a * b;

show(mul(3, 5).ToString());

Func<int, int, string> mulString = (a, b) =>
{
    var res = a * b;
    return res.ToString();
};

show(mulString(8, 8));




//!-------------------------------------------------------------------------------- "34. Función de orden superior"
Console.WriteLine("-------------------------------------------------------------------------------- '34. Función de orden superior'");
//! Una función de orden superior puede recibir funciones como parámetros. Recordemos que las funciones de primera clase pueden ser guardadas en variables, por lo cual, pueden ser enviadas como parámetros. También una función de orden superior puede retornar una función como resultado.

List<int> numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
//! number => number % 2 == 0: SOLO ES LA FUNCIÓN QUE SE ESTÁ ENVIANDO COMO PARÁMETRO A OTRA FUNCIÓN, ES DECIR, PARA MÍ number NO REPRESENTA NADA DE FUERA, ESE NUMBER SE LE PASARÁ COMO PARÁMETRO DENTRO DE LA FUNCIÓN
var numbers2 = Filter(numbers, number => number % 2 == 0);
// La ventaja que se tiene con este tipo de mecanismos, es que puedo hacer distintas condiciones y no se tiene que programar la función una y otra vez
var numbers3 = Filter(numbers, number => number > 5);

foreach (var number in numbers2)
{
    Console.WriteLine(number);
}

//! Filter es una función que recibe como parámetros una lista de enteros y una variable la cual especifíca una función que recibe un entero y regresa un booleano, es decir, recibimos como parámetro un número y retornamos un true o un false. Lo que hará la función es filtrar elementos a partir de la función que le mandemos
//List<int> Filter(List<int> list, Func<int, bool> condition)
// Si se cambia Func por Predicate, nos ahorramos tener que decir que devuelve un booleano
List<int> Filter(List<int> list, Predicate<int> condition)
{
    var resultsList = new List<int>();

    foreach (var element in list)
    {
        if (condition(element))
        {
            resultsList.Add(element);
        }
    }

    return resultsList;
}




//!-------------------------------------------------------------------------------- "35. Tipo Predicate"
Console.WriteLine("-------------------------------------------------------------------------------- '35. Tipo Predicate'");
//! Un predicado es un tipo de delegado como Func y Action, pero este delegado tiene como particularidad que solo puede recibir UN PARÁMETRO y SIEMPRE va a regresar un booleano (true o false)
Predicate<int> condition1 = x => x % 2 == 0;
Predicate<int> condition2 = x => x > 5;

var numbers4 = Filter(numbers, condition1);
var numbers5 = Filter(numbers, condition2);
