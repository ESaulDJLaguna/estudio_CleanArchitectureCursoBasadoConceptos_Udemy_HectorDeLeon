IRepository<string> beerData = new BeerData();
beerData.Add("Corona");
beerData.Add("Delirium");
beerData.Add("Erdinger");

var reportGeneratorBeer = new ReportGeneratorBeer(beerData);
var reportGeneratorHTMLBeer = new ReportGeneratorHTMLBeer(beerData);
var report = new Report();
var data = reportGeneratorBeer.Generate();
//! Para crear un reporte html NO se modificó la interaz IReportGenerator para aceptar txt o html, sino que se creó una clase nueva que implementara dicha interfaz y cumpliera con retornar el html
report.Save(reportGeneratorHTMLBeer, "cervezas.html");

Show(reportGeneratorBeer);

void Show(IReportShow report)
{
    report.Show();
}

public interface IRepository<T>
{
    public void Add(T item);
    public List<T> Get();
}    

// Indica qué hace un IReportGenerator, lo que hace es regresar un string por medio de un método llamado Generate(), es lo único que nos interesa. Esto es una abstracción, es decir, una abstracción indica que hace algo mas NO cómo lo hace. La implementación de esta abstracción indica cómo se hace y dicha implementación se hace con una clase
public interface IReportGenerator
{
    public string Generate();
}

public interface IReportShow
{
    public void Show();
}

public class BeerData: IRepository<string>
{
    protected List<string> _beers;

    public BeerData()
    {
        _beers = new List<string>();
    }

    public virtual void Add(string beer) => _beers.Add(beer);
    public List<string> Get() => _beers;
}

public class LimitedBeerData : BeerData
{
    private int _limit;
    public LimitedBeerData(int limit) => _limit = limit;

    public override void Add(string beer)
    {
        // Esto rompe Liskov porque estamos alterando el comportamiento del padre. Es decir, si definimos lo siguiente: BeerData beerData = new BeerData(); y agregamos 3 cervezas, no pasará nada, pero si ahora hacemos: BeerData beerData = new LimitedBeerData(2) enviando de nuevo las 3 cervezas, lanzará una excepción, cuando no tendría qué hacer esto ya que el padre puede almacenar n cantidad de cervezas.
        if (_beers.Count >= _limit)
        {
            throw new InvalidOperationException("Límite de cervezas alcanzado");
        }

        base.Add(beer);
    }
}

//  Una forma de solucionar el problema anterior y no romper el principio de Liskov, es utilizar una técnica llamada composición, la cual es una técnica en la cual las clases tienen objetos internos y pueden extender el funcionamiento ellas mismas sobre estos objetos internos. Es decir, ya no heredamos de la clase sino que tenemos un objeto de dicha clase
public class LimitedBeerData2
{
    //! Aquí se rompe el quinto principio SOLID porque estamos dependiendo de una clase, si en un futuro cambia el constructor y requieren algún parámetro, ahora se tendría que modificar eso en todas las clases que se utiliza, para solucionarlo, crearemos una interfaz que tenga los métodos de BeerData
    //private BeerData _beerData = new BeerData();
    private IRepository<string> _beerData;
    private int _limit;
    private int _count = 0;

    public LimitedBeerData2(int limit, IRepository<string> beerData)
    {
        _limit = limit;
        _beerData = beerData;
    }

    public void Add(string beer)
    {
        if (_count >= _limit)
        {
            throw new InvalidOperationException("Límite de cervezas alcanzado");
        }

        _beerData.Add(beer);
        _count++;
    }

    public List<string> Get() => _beerData.Get();
}

public class ReportGeneratorBeer : IReportGenerator, IReportShow
{
    //! Aquí se rompe el quinto principio SOLID porque estamos dependiendo de una clase, si en un futuro cambia el constructor y requieren algún parámetro, ahora se tendría que modificar eso en todas las clases que se utiliza, para solucionarlo, crearemos una interfaz que tenga los métodos de BeerData
    //private BeerData _beerData = new BeerData();
    private IRepository<string> _beerData;

    public ReportGeneratorBeer(IRepository<string> beerData)
    {
        _beerData = beerData;
    }

    public string Generate()
    {
        string data = "";
        foreach (var beer in _beerData.Get())
        {
            // Environment.NewLine: representa una nueva línea en un archivo de texto
            data += $"Cerveza: { beer }{ Environment.NewLine }";
        }

        return data;
    }

    public void Show()
    {
        foreach (var beer in _beerData.Get())
        {
            Console.WriteLine($"Cerveza: {beer}");
        }
    }
}

// Ahora nos solicitan generar un reporte en html. Lo que NO SE HACE, es modificar el método Generate dentro de IReportGenerator, para pasarle como parámetro el tipo de archivo a manejar, ya que estamos rompiendo el principio de abierto/cerrado
// Lo que se haría es crear una clase nueva que implemente IReportGenerator
public class ReportGeneratorHTMLBeer : IReportGenerator
{

    //! Aquí se rompe el quinto principio SOLID porque estamos dependiendo de una clase, si en un futuro cambia el constructor y requieren algún parámetro, ahora se tendría que modificar eso en todas las clases que se utiliza, para solucionarlo, crearemos una interfaz que tenga los métodos de BeerData
    //private BeerData _beerData = new BeerData();
    private IRepository<string> _beerData;

    public ReportGeneratorHTMLBeer(IRepository<string> beerData)
    {
        _beerData = beerData;

    }

    public string Generate()
    {
        string data = "<div>";

        foreach (var beer in _beerData.Get())
        {
            data += $"<b>{ beer }</b></br>";
        }

        data += "</div>";
        return data;
    }
}

// Haremos que el reporte funcione con el principio abierto cerrado
public class Report
{
    // Nos despreocupamos del tipo de dato, nos interesa saber que recibiremos clases que implementan IReportGenerator y por lo tanto, sabemos que sí o sí tendrán un método Generate que retorna un string. De esta manera estamos dependiendo de una abstracción
    public void Save(IReportGenerator reportGenerator, string filePath)
    {
        using (var writer = new StreamWriter(filePath))
        {
            //! No me interesa qué haga Generate(), lo único que me importa es que me devolverá un string y dicho string se guardará en un archivo
            string data = reportGenerator.Generate();
            writer.WriteLine(data);
        }
    }
}
