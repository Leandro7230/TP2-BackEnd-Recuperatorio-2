using Microsoft.EntityFrameworkCore;
using Pacientes_Turnos.Clases;

namespace Pacientes_Turnos.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Turno> Turnos { get; set; } 
    }
}
