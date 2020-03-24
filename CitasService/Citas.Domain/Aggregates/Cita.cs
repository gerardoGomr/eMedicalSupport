using Citas.Domain.Exceptions;
using Citas.Domain.SeedWork;
using System;

namespace Citas.Domain.Aggregates
{
    public class Cita : Entity
    {
        private readonly DateTime _fechaRegistro;

        public CitaEstado Estado { get; private set; }
        public DateTime Fecha { get; private set; }
        public Paciente Paciente { get; private set; }

        private Cita() : base()
        {
            Estado = CitaEstado.Agendada;
            _fechaRegistro = DateTime.Now;
        }

        private Cita AgendadaPara(DateTime fecha, Paciente paciente)
        {
            if (fecha.Equals(DateTime.MinValue) || fecha.Equals(DateTime.MaxValue))
                throw new DominioException($"Debe especificar una fecha mayor o igual {DateTime.Now.ToString("dd'/'MM'/'yyyy")}");

            Fecha = fecha;
            Paciente = paciente ?? throw new DominioException("Se debe especificar un paciente a agendarle una cita");

            return this;
        }

        public static Cita Agendar(DateTime fecha, Paciente paciente) => new Cita()
            .AgendadaPara(fecha, paciente);

        public void Confirmar()
        {
            if (!Estado.Equals(CitaEstado.Agendada))
                throw new DominioException("Solo es posible confirmar citas agendadas");

            Estado = CitaEstado.Confirmada;
        }

        public bool EstaAgendada() => Estado.Equals(CitaEstado.Agendada);

        public bool EstaConfirmada() => Estado.Equals(CitaEstado.Confirmada);

        public bool EstaEnEsperaDeAtencion() => Estado.Equals(CitaEstado.EnEsperaDeAtencion);

        public void EnEsperaDeAtencion()
        {
            if (!Estado.Equals(CitaEstado.Confirmada))
                throw new DominioException("Solo es posible marca a En Espera a citas confirmadasss");

            Estado = CitaEstado.EnEsperaDeAtencion;
        }
    }
}
