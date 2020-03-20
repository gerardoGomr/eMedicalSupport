using Citas.Domain.Exceptions;
using Citas.Domain.SeedWork;
using System;

namespace Citas.Domain.Aggregates
{
    public class Cita : Entity
    {
        private const int AGENDADA = 1;
        private const int CONFIRMADA = 2;
        private const int EN_ESPERA_DE_ATENCION = 3;

        private DateTime _fecha;
        private readonly DateTime _fechaRegistro;
        private int _estado;

        public int Estado => _estado;
        public DateTime Fecha => _fecha;

        private Cita() : base()
        {
            _estado = AGENDADA;
            _fechaRegistro = DateTime.Now;
        }

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

        public void EnEsperaDeAtencion()
        {
            _estado = EN_ESPERA_DE_ATENCION;
        }
    }
}
