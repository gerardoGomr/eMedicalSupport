using Citas.Domain.Aggregates;
using Xunit;

namespace Citas.Test
{
    public class NombreTest
    {
        [Fact(DisplayName = "Se obtiene nombre completo correctamente")]
        public void SeObtieneNombreCompletoCorrectamente()
        {
            // Arrange
            var nombre = new Nombre("Gerardo", "Gomez");

            // Assert
            Assert.Equal("Gerardo Gomez", nombre.NombreCompleto);
        }

        [Fact(DisplayName = "Se compara igualdad de nombre exitosamente")]
        public void SeComparaIgualdadNombreExitosamente()
        {
            // Arrange
            var nombre1 = new Nombre("Gerardo", "Gomez");
            var nombre2 = new Nombre("Gerardo", "Gomez", "Ruiz");

            // Assert
            Assert.True(!nombre1.Equals(nombre2));
        }
    }
}
