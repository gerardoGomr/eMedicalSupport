using Citas.Domain.Exceptions;
using Citas.Domain.SeedWork;
using Citas.Domain.Helpers;
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
                throw new DominioException(Message.GetMessage(Message.FechaValida, DateTime.Now.ToString("dd'/'MM'/'yyyy")));

            Fecha = fecha;
            Paciente = paciente ?? throw new DominioException(Message.PacienteRequerido);

            return this;
        }

        public static Cita Agendar(DateTime fecha, Paciente paciente) => new Cita()
            .AgendadaPara(fecha, paciente);

        public void Confirmar()
        {
            if (!Estado.Equals(CitaEstado.Agendada))
                throw new DominioException(Message.CitaNoAgendada);

            Estado = CitaEstado.Confirmada;
        }

        public bool EstaAgendada() => Estado.Equals(CitaEstado.Agendada);

        public bool EstaConfirmada() => Estado.Equals(CitaEstado.Confirmada);

        public bool EstaEnEsperaDeAtencion() => Estado.Equals(CitaEstado.EnEsperaDeAtencion);

        public void EnEsperaDeAtencion()
        {
            if (!Estado.Equals(CitaEstado.Confirmada))
                throw new DominioException(Message.CitaNoConfirmada);

            Estado = CitaEstado.EnEsperaDeAtencion;
        }
    }
}
