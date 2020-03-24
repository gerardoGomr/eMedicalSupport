using Citas.Domain.Aggregates;
using Citas.Domain.Exceptions;
using System;
using Xunit;

namespace Citas.Test
{
    public class CitaTest
    {
        private readonly DateTime _fecha;
        private readonly Cita _cita;

        public CitaTest()
        {
            _fecha = DateTime.Now;
            var paciente = new Paciente(new Nombre("Gerardo", "Gomez", "Ruiz"));
            _cita = Cita.Agendar(_fecha, paciente);
        }

        [Fact(DisplayName = "Debería existir cita con datos mínimos")]
        public void DeberiaExistirCita()
        {
            // Assert
            Assert.NotNull(_cita);
        }

        [Fact(DisplayName = "Se crea una cita con estado 'Agendada'")]
        public void SeCreaUnaCitaConEstadoAgendada()
        {
            // Assert
            Assert.True(_cita.EstaAgendada());
        }

        [Fact(DisplayName = "Se crea una cita con ID válido")]
        public void SeCreaUnaCitaConIDValido()
        {
            // Assert
            Assert.NotEqual(Guid.Empty, _cita.Id);
        }

        [Fact(DisplayName = "Se especifica una cita con una fecha válida")]
        public void SeEspecificaUnaCitaConFechaHoraValilda()
        {
            // Assert
            Assert.Equal(_fecha, _cita.Fecha);
        }

        [Fact(DisplayName = "Se confirma una cita con éxito")]
        public void SeConfirmaUnaCitaConExito()
        {
            // Act
            _cita.Confirmar();

            // Assert
            Assert.True(_cita.EstaConfirmada());
        }

        [Fact(DisplayName = "Ocurre un error al confirmar una cita cuando su estado no es 'Agendada'")]
        public void OcurreUnErrorAlConfirmarUnaCitaCuandoSuEstadoNoEsAgendada()
        {
            // Arrange
            _cita.Confirmar();

            // Act
            // Assert
            Assert.Throws<DominioException>(() => _cita.Confirmar());
        }

        [Fact(DisplayName = "Se marca una cita con estado 'En Espera de Atencion'")]
        public void SeMarcaCitaEnEsperaDeAtencion()
        {
            // Arrange
            _cita.Confirmar();

            // Act
            _cita.EnEsperaDeAtencion();

            // Assert
            Assert.True(_cita.EstaEnEsperaDeAtencion());
        }

        [Fact(DisplayName = "Ocurre un error al marcar 'En Espera' a una cita cuando su estado no es 'Confirmada'")]
        public void OcurreUnErrorAlMarcarCitaAEnEsperaCuandoSuEstadoNoEsConfirmada()
        {
            // Act
            // Assert
            Assert.Throws<DominioException>(() => _cita.EnEsperaDeAtencion());
        }

        [Fact(DisplayName = "Se agenda cita para el paciente 'Gerardo Gomez' exitósamente")]
        public void SeAgendaCitaParaUnPacienteExitosamente()
        {
            // Assert
            Assert.NotNull(_cita.Paciente);
        }
    }
}
