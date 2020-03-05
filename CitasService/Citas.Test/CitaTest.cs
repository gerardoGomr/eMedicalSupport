using Xunit;

namespace Citas.Test
{
    public class CitaTest
    {
        [Fact(DisplayName = "Debería existir Cita con Datos Mínimos")]
        public void DeberiaExistirCitaBasica()
        {
            // Arrange

            // Act
            var cita = new Citas();

            // Assert
            Assert.NotNull(cita);
        }
    }
}
