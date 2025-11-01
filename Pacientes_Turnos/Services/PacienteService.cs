using Microsoft.EntityFrameworkCore;
using Pacientes_Turnos.Clases;
using Pacientes_Turnos.Data;
using Pacientes_Turnos.Service;


namespace Pacientes_Turnos.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly AppDbContext _context;

        public PacienteService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Paciente>> GetAll()
        {
            return await _context.Pacientes.Include(p => p.Turnos).ToListAsync();
        }

        public async Task<Paciente?> GetById(int id)
        {
            return await _context.Pacientes.Include(p => p.Turnos)
                                           .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Paciente> Add(Paciente paciente)
        {
            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();
            return paciente;
        }

        public async Task<Paciente?> Update(int id, Paciente paciente)
        {
            var existing = await _context.Pacientes.FindAsync(id);
            if (existing == null) return null;

            existing.Nombre = paciente.Nombre;
            existing.Apellido = paciente.Apellido;
            existing.Dni = paciente.Dni;
            existing.Telefono = paciente.Telefono;
            existing.Email = paciente.Email;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> Delete(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null) return false;

            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}