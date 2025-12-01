//! Esta biblioteca es la representación de un componente que tiene funcionalidades en común. Esto representará un componente que se puede reutilizar en varios proyectos
namespace OperationComponent
{
    public class Operations
    {
        public decimal Mul(decimal a, decimal b) => a * b;// a + b;

        public decimal Add(decimal a, decimal b) => a + b;

        public decimal Sub(decimal a, decimal b) => a - b;
    }
}
