//!-------------------------------------------------------------------------------- "44. The Common Closure Principle (CCP)"
namespace OperationComponent
{
    //! Podemos notar que esta clase Beers rompe el principio "Common Closure Principle" ya que no tiene nada que ver con la clase Operations, es decir, si se hace un cambio en Operations pero NO en Beers, tenemos que compilar ambas clases, mientras que si se tiene un cambio en Beers pero no en Operations, tendremos que compilar ambos de nuevo, para solucionar esto, se crea un nuevo componente y movemos todo lo que tenga que ver con Beers a él.
    public class Beers
    {
        private List<string> _beers;

        public Beers() => _beers = new List<string>();

        public void Add(string beer) => _beers.Add(beer);

        public List<string> Get() => _beers;
    }
}
