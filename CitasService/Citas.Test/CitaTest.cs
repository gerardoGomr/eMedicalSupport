using Citas.Domain.Aggregates;
using Citas.Domain.Exceptions;
using System;
using Xunit;

namespace Citas.Test
{
    public class CitaTest
    {
        [Fact(DisplayName = "Debería existir cita con datos mínimos")]
        public void DeberiaCrearseUnaCitaSiPacienteYFechaSonCorrectos()
        {
            // Arrange
            var fecha = DateTime.Now;
            var paciente = new Paciente(new Nombre("Gerardo", "Gomez", "Ruiz"));

            // Act
            var cita = Agendar(paciente, fecha);

            // Assert
            Assert.NotNull(cita);
            Assert.True(cita.EstaAgendada());
            Assert.NotEqual(Guid.Empty, cita.Id);
            Assert.Equal(fecha, cita.Fecha);
        }

        [Fact(DisplayName = "Se confirma una cita con éxito")]
        public void SeConfirmaUnaCitaConExito()
        {
            // Arrange
            var fecha = DateTime.Now;
            var paciente = new Paciente(new Nombre("Gerardo", "Gomez", "Ruiz"));
            var cita = Agendar(paciente, fecha);

            // Act
            cita.Confirmar();

            // Assert
            Assert.True(cita.EstaConfirmada());
        }

        [Fact(DisplayName = "Ocurre un error al confirmar una cita cuando su estado no es 'Agendada'")]
        public void OcurreUnErrorAlConfirmarUnaCitaCuandoSuEstadoNoEsAgendada()
        {
            // Arrange
            var fecha = DateTime.Now;
            var paciente = new Paciente(new Nombre("Gerardo", "Gomez", "Ruiz"));
            var cita = Agendar(paciente, fecha);

            // Act
            cita.Confirmar();

            // Assert
            Assert.Throws<DominioException>(() => cita.Confirmar());
        }

        [Fact(DisplayName = "Se marca una cita con estado 'En Espera de Atencion'")]
        public void SeMarcaCitaEnEsperaDeAtencion()
        {
            // Arrange
            var fecha = DateTime.Now;
            var paciente = new Paciente(new Nombre("Gerardo", "Gomez", "Ruiz"));
            var cita = Agendar(paciente, fecha);
            cita.Confirmar();

            // Act
            cita.EnEsperaDeAtencion();

            // Assert
            Assert.True(cita.EstaEnEsperaDeAtencion());
        }

        [Fact(DisplayName = "Ocurre un error al marcar 'En Espera' a una cita cuando su estado no es 'Confirmada'")]
        public void OcurreUnErrorAlMarcarCitaAEnEsperaCuandoSuEstadoNoEsConfirmada()
        {
            // Arrange
            var fecha = DateTime.Now;
            var paciente = new Paciente(new Nombre("Gerardo", "Gomez", "Ruiz"));
            var cita = Agendar(paciente, fecha);

            // Act
            // Assert
            Assert.Throws<DominioException>(() => cita.EnEsperaDeAtencion());
        }

        private Cita Agendar(Paciente paciente, DateTime fecha) => Cita.Agendar(fecha, paciente);
    }
}
