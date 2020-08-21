using Citas.Domain.SeedWork;

namespace Citas.Domain.Aggregates
{
    public class TipoMedioContacto : Enumeration
    {
        public static readonly TipoMedioContacto Telefono = new TipoMedioContacto(1, "Teléfono");
        public static readonly TipoMedioContacto Celular = new TipoMedioContacto(2, "Celular");
        public static readonly TipoMedioContacto Email = new TipoMedioContacto(3, "E-Mail");

        public TipoMedioContacto(int id, string name) : base(id, name) { }
    }
}