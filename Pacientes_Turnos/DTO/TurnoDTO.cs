namespace Pacientes_Turnos.DTO
{
    public class TurnoDTO
    {
        public int Id { get; set; }
        public string Fecha { get; set; } = string.Empty;
        public string Hora { get; set; } = string.Empty;
        public string Especialidad { get; set; } = string.Empty;
        public int PacienteId { get; set; }
    }
}
