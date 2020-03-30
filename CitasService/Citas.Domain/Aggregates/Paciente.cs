using Citas.Domain.SeedWork;

namespace Citas.Domain.Aggregates
{
    public class Paciente : Entity
    {
        public Nombre Nombre { get; private set; }
        public bool EsPrimeraVez { get; set; }
        public bool TieneExpediente { get; set; }    

        public Paciente(Nombre nombre) : base()
        {
            Nombre = nombre;
            EsPrimeraVez = true;
            TieneExpediente = false;
        }
    }
}
