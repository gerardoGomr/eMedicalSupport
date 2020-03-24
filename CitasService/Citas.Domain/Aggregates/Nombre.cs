using System.Collections.Generic;
using Citas.Domain.Exceptions;
using Citas.Domain.SeedWork;

namespace Citas.Domain.Aggregates
{
    public class Nombre : ValueObject
    {
        private const string EMPTY_VALUE = "";
        public string Nombres { get; private set; }
        public string Paterno { get; private set; }
        public string Materno { get; private set; }
        public string NombreCompleto
        {
            get
            {
                var materno = !string.IsNullOrWhiteSpace(Materno)
                    ? $" {Materno}"
                    : EMPTY_VALUE;

                return $"{Nombres} {Paterno}{materno}";
            }
        }

        public Nombre(string nombres, string paterno, string materno = null)
        {
            Nombres = nombres ?? throw new DominioException("El/los nombre(s) es/son incorrecto(s)");
            Paterno = paterno ?? throw new DominioException("El apellido paterno es incorrecto");
            Materno = materno;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Nombres;
            yield return Paterno;
            yield return Materno;
        }
    }
}
