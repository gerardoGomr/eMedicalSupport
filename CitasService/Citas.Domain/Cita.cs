using System;

namespace Citas.Domain
{
    public class Cita : Entity
    {
        private const int AGENDADA = 1;

        public int Estado { get; }
        public DateTime Fecha { get; set; }

        private Cita() => Estado = AGENDADA;

        private Cita AgendadaPara(DateTime fecha)
        {
            Fecha = fecha;

            return this;
        }

        public static Cita Agendar(DateTime fecha) => new Cita()
            .AgendadaPara(fecha);
    }
}
