using Citas.Domain.SeedWork;

namespace Citas.Domain.Aggregates
{
    public class MedioContacto : Entity
    {
        public TipoMedioContacto TipoMedio { get; private set; }
        public string Valor;
    }
}
