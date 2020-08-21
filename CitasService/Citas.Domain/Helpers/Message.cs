namespace Citas.Domain.Helpers
{
    public static class Message
    {
        public const string FechaValida = "Debe especificar una fecha mayor o igual {0}";
        public const string PacienteRequerido = "Se debe indicar al paciente para agendar la cita";
        public const string CitaNoAgendada = "Solo es posible confirmar citas agendadas";
        public const string CitaNoConfirmada = "Solo es posible marca a En Espera a citas confirmadas";
        public const string NombreIncorrecto = "El/los nombre(s) es/son incorrecto(s)";
        public const string PaternoIncorrecto = "El apellido paterno es incorrecto";

        public static string GetMessage(string message, string replacement) => string.Format(message, replacement);
    }
}
