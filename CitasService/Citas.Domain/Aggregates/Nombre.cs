using System.Collections.Generic;
using Citas.Domain.Exceptions;
using Citas.Domain.SeedWork;
using Citas.Domain.Helpers;

namespace Citas.Domain.Aggregates
{
    public class Nombre : ValueObject
    {
        private const string EmptyValue = "";
        public string Nombres { get; private set; }
        public string Paterno { get; private set; }
        public string Materno { get; private set; }
        public string NombreCompleto
        {
            get
            {
                var materno = !string.IsNullOrWhiteSpace(Materno)
                    ? $" {Materno}"
                    : EmptyValue;

                return $"{Nombres} {Paterno}{materno}";
            }
        }

        public Nombre(string nombres, string paterno, string materno = null)
        {
            Nombres = nombres ?? throw new DominioException(Message.NombreIncorrecto);
            Paterno = paterno ?? throw new DominioException(Message.PaternoIncorrecto);
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
