using Citas.Domain.SeedWork;

namespace Citas.Domain.Aggregates
{
    public class Paciente : Entity
    {
        public Nombre Nombre { get; private set; }

        public Paciente(Nombre nombre) : base()
        {
            Nombre = nombre;
        }
    }
}
