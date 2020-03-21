using Citas.Domain.Aggregates;
using Citas.Domain.Exceptions;
using System;
using Xunit;

namespace Citas.Test
{
    public class CitaTest
    {
        [Fact(DisplayName = "Debería existir cita con datos mínimos")]
        public void DeberiaExistirCita()
        {
            // Act
            var cita = Cita.Agendar(DateTime.Now);

            // Assert
            Assert.NotNull(cita);
        }

        [Fact(DisplayName = "Se crea una cita con estado 'Agendada'")]
        public void SeCreaUnaCitaConEstadoAgendada()
        {
            // Act
            var cita = Cita.Agendar(DateTime.Now);

            // Assert
            Assert.True(cita.EstaAgendada());
        }

        [Fact(DisplayName = "Se crea una cita con ID válido")]
        public void SeCreaUnaCitaConIDValido()
        {
            // Act
            var cita = Cita.Agendar(DateTime.Now);

            // Assert
            Assert.NotEqual(Guid.Empty, cita.Id);
        }

        [Fact(DisplayName = "Se especifica una cita con una fecha válida")]
        public void SeEspecificaUnaCitaConFechaHoraValilda()
        {
            // Arrange
            var fecha = DateTime.Now;

            // Act
            var cita = Cita.Agendar(fecha);

            // Assert
            Assert.Equal(fecha, cita.Fecha);
        }

        [Fact(DisplayName = "Se confirma una cita con éxito")]
        public void SeConfirmaUnaCitaConExito()
        {
            // Arrange
            var cita = Cita.Agendar(DateTime.Now);

            // Act
            cita.Confirmar();

            // Assert
            Assert.True(cita.EstaConfirmada());
        }

        [Fact(DisplayName = "Ocurre un error al confirmar una cita cuando su estado no es 'Agendada'")]
        public void OcurreUnErrorAlConfirmarUnaCitaCuandoSuEstadoNoEsAgendada()
        {
            // Arrange
            var cita = Cita.Agendar(DateTime.Now);
            cita.Confirmar();

            // Act
            // Assert
            Assert.Throws<DominioException>(() => cita.Confirmar());
        }

        [Fact(DisplayName = "Se marca una cita con estado 'En Espera de Atencion'")]
        public void SeMarcaCitaEnEsperaDeAtencion()
        {
            // Arrange
            var cita = Cita.Agendar(DateTime.Now);
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
            var cita = Cita.Agendar(DateTime.Now);

            // Act
            // Assert
            Assert.Throws<DominioException>(() => cita.EnEsperaDeAtencion());
        }
    }
}
