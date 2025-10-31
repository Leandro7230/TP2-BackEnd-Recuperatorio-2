using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pacientes_Turnos.Clases
{
    public class Turno
    {
        [Key]
        public int Id { get; set; }

        public string Fecha { get; set; } = string.Empty;
        public string Hora { get; set; } = string.Empty;
        public string Especialidad { get; set; } = string.Empty;

        [ForeignKey("Paciente")]
        public int PacienteId { get; set; }

        public Paciente? Paciente { get; set; }
    }
}
