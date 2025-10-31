using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pacientes_Turnos.Clases
{
    public class Paciente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public string Apellido { get; set; } = string.Empty;

        [Required]
        public string Dni { get; set; } = string.Empty;

        public string Telefono { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public List<Turno> Turnos { get; set; } = new();
    
    }
}
