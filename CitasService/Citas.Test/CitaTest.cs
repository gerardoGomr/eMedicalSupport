using Citas.Domain;
using System;
using Xunit;

namespace Citas.Test
{
    public class CitaTest
    {
        [Fact(DisplayName = "Debería existir Cita con Datos Mínimos")]
        public void DeberiaExistirCita()
        {
            // Arrange

            // Act
            var cita = Cita.Agendar(DateTime.Now);

            // Assert
            Assert.NotNull(cita);
        }

        [Fact]
        public void SeCreaUnaCitaConEstadoAgendada()
        {
            var cita = Cita.Agendar(DateTime.Now);
            Assert.Equal(1, cita.Estado);
        }

        [Fact]
        public void SeCreaUnaCitaConIDValido()
        {
            var cita = Cita.Agendar(DateTime.Now);
            Assert.NotEqual(Guid.Empty, cita.Id);
        }

        [Fact]
        public void SeEspecificaUnaCitaConFechaHoraValilda()
        {
            var cita = Cita.Agendar(DateTime.Now);
            Assert.Equal(DateTime.Today, cita.Fecha.Date);
        }
    }
}
