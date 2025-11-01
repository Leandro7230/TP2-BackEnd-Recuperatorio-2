using Pacientes_Turnos.Clases;

namespace Pacientes_Turnos.Services
{
    public interface ITurnoService
    {
        Task<IEnumerable<Turno>> GetAll();
        Task<Turno?> GetById(int id);
        Task<Turno> Add(Turno turno);
        Task<Turno?> Update(int id, Turno turno);
        Task<bool> Delete(int id);
    }
}
