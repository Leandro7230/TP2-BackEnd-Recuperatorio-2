using Microsoft.EntityFrameworkCore;
using Pacientes_Turnos.Clases;
using Pacientes_Turnos.Data;
using Pacientes_Turnos.Services;


namespace Pacientes_Turnos.Services
{
    public class TurnoService : ITurnoService
    {
        private readonly AppDbContext _context;

        public TurnoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Turno>> GetAll()
        {
            return await _context.Turnos.Include(t => t.Paciente).ToListAsync();
        }

        public async Task<Turno?> GetById(int id)
        {
            return await _context.Turnos.Include(t => t.Paciente)
                                        .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Turno> Add(Turno turno)
        {
            _context.Turnos.Add(turno);
            await _context.SaveChangesAsync();
            return turno;
        }

        public async Task<Turno?> Update(int id, Turno turno)
        {
            var existing = await _context.Turnos.FindAsync(id);
            if (existing == null) return null;

            existing.Fecha = turno.Fecha;
            existing.Hora = turno.Hora;
            existing.Especialidad = turno.Especialidad;
            existing.PacienteId = turno.PacienteId;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> Delete(int id)
        {
            var turno = await _context.Turnos.FindAsync(id);
            if (turno == null) return false;

            _context.Turnos.Remove(turno);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
