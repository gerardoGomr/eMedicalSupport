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
        private CitaEstado _estado;

        public CitaEstado Estado => _estado;
        public DateTime Fecha => _fecha;

        private Cita() : base()
        {
            _estado = CitaEstado.Agendada;
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
            if (!Estado.Equals(CitaEstado.Agendada))
                throw new DominioException("Solo es posible confirmar citas agendadas");

            _estado = CitaEstado.Confirmada;
        }

        public bool EstaAgendada() => Estado.Equals(CitaEstado.Agendada);

        public bool EstaConfirmada() => Estado.Equals(CitaEstado.Confirmada);

        public bool EstaEnEsperaDeAtencion() => Estado.Equals(CitaEstado.EnEsperaDeAtencion);

        public void EnEsperaDeAtencion()
        {
            if (!Estado.Equals(CitaEstado.Confirmada))
                throw new DominioException("Solo es posible marca a En Espera a citas confirmadasss");

            _estado = CitaEstado.EnEsperaDeAtencion;
        }
    }
}
