using Citas.Domain.Exceptions;
using Citas.Domain.SeedWork;
using System;

namespace Citas.Domain.Aggregates
{
    public class Cita : Entity
    {
        private const int AGENDADA = 1;
        private const int CONFIRMADA = 2;
        private DateTime _fecha;
        private int _estado;

        public int Estado { get => _estado; }
        public DateTime Fecha { get => _fecha; }

        private Cita() : base() => _estado = AGENDADA;

        private Cita AgendadaPara(DateTime fecha)
        {
            _fecha = fecha;

            return this;
        }

        public static Cita Agendar(DateTime fecha) => new Cita()
            .AgendadaPara(fecha);

        public void Confirmar()
        {
            if (Estado != AGENDADA)
                throw new DominioException("Solo es posible confirmar citas agendadas");

            _estado = CONFIRMADA;
        }

        public bool EstaConfirmada() => Estado == CONFIRMADA;
    }
}
