//!-------------------------------------------------------------------------------- "42. ¿Qué es un componente", "44. The Common Closure Principle (CCP)" y "45. The Common Reuse Principle (CRP)"
/*
// Para utilizar el componente OperationComponents, se tiene que agregar la referencia a dicho proyecto
using OperationComponent;
using BeersRepository = BeersRepositoryComponent.Beers;

var operations = new Operations();
var result = operations.Mul(2, 3);

// Para entender la utilidad de los componentes, veamos lo siguiente:
//*
//* Si se ejecuta por primera vez el proyecto "TestComponent", generará un archivo .exe en:
//*      .TestComponent/bin/Debug/net8.0
//* Aquí mismo podremos ver "OperationComponent.dll". Al ejecutar el .exe podremos notar que el resultado es la suma de los dos números, pero si a continuación se edita el método Some dentro del componente y ahora en vez de sumar, multiplicamos y esta vez compilamos OperationComponent (NO TestComponent) y reemplazamos la dll de OperationComponent dentro de: .TestComponent/bin/Debug/net8.0, veremos que al volver a ejecutar el .exe no nos dará la suma de los números, sino la multiplicación, por lo tanto, habremos cambiado el comportamiento del componente al reemplazar la versión del mismo.
Console.WriteLine(result);
Console.ReadLine();

var beers = new BeersRepository();
*/




//!-------------------------------------------------------------------------------- "46. The Acyclic Dependencies Principle (ADP)"
/*
public class C
{
    // El componente C depende de A
    //x private readonly A _a;
    private readonly IA _a; // Resolvemos el ciclo de dependencias
    //x public C(A a)
    public C(IA a)
    {
        _a = a;
    }
}

// Para resolver el problema del ciclo: C depende de A, A depende de B; B depende de C, creamos una interfaz y ahora en vez de que C dependa de A, ahora dependería de IA (una abstracción), de esta manera se puede poner al compnente A o cualquier otro componente que implemente la interfaz y ya no se tiene ese acoplamiento fuerte sino que se depende de abstracciones y de esta manera se rompe el ciclo. De esta manera cuando se envíe A ya no importará cómo se trabaje internamente, sino que lo importante es que tenga un método llamado "MethodA" que no recibe y deuelve nada.
public interface IA
{
    public void MethodA();
}

public class A : IA
{
    // El componente A depende de B
    private readonly B _b;
    public A(B b)
    {
        _b = b;
    }

    public void MethodA() { }
}

public class B
{
    // El componente B depende de C
    private readonly C _c;
    public B(C c)
    {
        _c = c;
    }
}
*/




//!-------------------------------------------------------------------------------- "47. The Stable Dependencies Principle (SDP)"
/*
IF f = new F(); // new F2();
//! La ventaja de depender de una interfaz es que si f cambia de tipo, es decir, si en vez de que sea 'new F()' sea 'new F2()', s no se verá afectado, porque no está dependiendo de una implementación, por lo tanto, ni siquiera se entería del cambio que existió.
var s = new S(f);


// Se tiene una clase que es estática y depende de una clase que es flexible (F)
public class S
{
    //x private readonly F _f;
    private readonly IF _f; // Al depender de una abstracción, este componente dependerá de cualquiera que implemente la interfaz, es decir, podría depender de F o de F2 y el componente S no se enteraría
    //x public S(F f)
    public S(IF f)
    {
        _f = f;
    }
    public void Do()
    {
        _f.Some();
    }
}

public interface IF
{
    public void Some();
}

public class F : IF
{
    public void Some()
    {
        // SE PODRÍA TENER CAMBIOS Y CADA CAMBIO REQUERIRÍA SER COMPILADO Y CADA COMPILACIÓN DE F NOS OBLIGARÍA A COMPILA S
    }
}
public class F2 : IF
{
    public void Some()
    {

    }
}
*/
