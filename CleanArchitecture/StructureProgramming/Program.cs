/*
//! Variables
int number = 15;
number = 20;
float dec = 12.3232f;
bool thereIsBeer = false;
string name = "User";
char character = 'a';
var num = 15;
var secondName = "Juan";



//! Arrays
int[] numbers = new int[5];
numbers[0] = 0;
numbers[1] = 1;
numbers[2] = 2;
numbers[3] = 3;
numbers[4] = 4;

var initialNumbers = new int[5] { 1, 2, 3, 4, 5 };
Console.WriteLine(initialNumbers[2]);



//! Sentencias condicionales
var age = 12;

if(age > 60)
{
    Console.WriteLine("if(age > 60): Es de la tercera edad");
}
else if(age > 18)
{
    Console.WriteLine("else if(age > 18): Es mayor de edad");
}
else
{
    Console.WriteLine("else: Es menor de edad");
}

switch (age)
{
    case < 18:
        Console.WriteLine("case < 18: Es menor de edad");
        break;
    case < 60:
        Console.WriteLine("case < 60: Es mayor de edad");
        break;
    default:
        Console.WriteLine("default: Es de la tercera edad");
        break;
}



//! Sentencias de iteración
var names = new string[3] { "Héctor", "Juan", "Pedro" };
int counter = 0;
do
{
    Console.WriteLine("do-while: " + names[counter++]);
}
while (counter < names.Length);

counter = 0;
while (counter < names.Length)
{
    Console.WriteLine("while: " + names[counter++]);
}

for (int i = 0; i < names.Length; i++)
{
    Console.WriteLine("for: " + names[i]);
}

foreach (var item in names)
{
    Console.WriteLine("foreach: " + item);
}



//! Funciones
int res1 = 30 * 30;
int res2 = 20 * 20;
int res3 = Area(30);

Console.WriteLine(res1);
Console.WriteLine(res2);
Console.WriteLine(res3);
Show("Arquitectura Limpia");
Bye();

int Area(int s)
{
    int res = s * s;
    return res;
}

void Show(string message)
{
    Console.WriteLine(message);
}

void Bye()
{
    Show("Adiós");
}
*/

//! La desventaja de la programación estructurada es que entre más crece el programa más largo se va haciendo el archivo y después depurarlo es más complicado.
int limit = 3;
var beers = new string[limit];
int iBeers = 0;
int op = 0;

do
{
    Console.Clear();
    ShowMenu();
    op = int.Parse(Console.ReadLine());

    switch (op)
    {
        case 1:
            if(iBeers < limit)
            {
                Console.Clear();
                Console.WriteLine("Escribe un nombre de cerveza: ");
                var beer = Console.ReadLine();
                beers[iBeers] = beer;
                iBeers++;
            }
            else
            {
                Console.WriteLine("Ya no caben cervezas");
            }
                break;
        case 2:
            ShowBeer(beers, iBeers);
            break;
        case 3:
            Console.WriteLine("Adiós");
            break;
        default:
            Console.WriteLine("Opción no válida");
            break;
    }
} while (op != 3);

void ShowMenu()
{
    Console.WriteLine("1. Agregar nombre");
    Console.WriteLine("2. Mostrar nombres");
    Console.WriteLine("3. Salir");
}

void ShowBeer(string[] beers, int iBeers)
{
    Console.Clear();
    Console.WriteLine("------ Cervezas ------");
    for (int i = 0; i < iBeers; i++)
    {
        Console.WriteLine(beers[i]);
    }
    Console.WriteLine("Presione una tecla para continuar");
    Console.ReadLine();
}