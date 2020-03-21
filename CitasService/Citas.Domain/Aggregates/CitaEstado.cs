using Citas.Domain.SeedWork;

namespace Citas.Domain.Aggregates
{
    public class CitaEstado : Enumeration
    {
        public static readonly CitaEstado Agendada = new CitaEstado(1, "Agendada");
        public static readonly CitaEstado Confirmada = new CitaEstado(2, "Confirmada");
        public static readonly CitaEstado EnEsperaDeAtencion = new CitaEstado(3, "En Espera de Atencion");

        public CitaEstado(int id, string name) : base(id, name) { }
    }
}
