using Pacientes_Turnos.Clases;

namespace Pacientes_Turnos.Service
{
    public interface IPacienteService
    {
        Task<IEnumerable<Paciente>> GetAll();
        Task<Paciente?> GetById(int id);
        Task<Paciente> Add(Paciente paciente);
        Task<Paciente?> Update(int id, Paciente paciente);
        Task<bool> Delete(int id);
    }
}
