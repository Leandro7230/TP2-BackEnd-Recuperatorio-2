using AutoMapper;
using Pacientes_Turnos.Clases;
using Pacientes_Turnos.DTO;

namespace Pacientes_Turnos.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Paciente, PacienteDTO>().ReverseMap();
            CreateMap<Turno, TurnoDTO>().ReverseMap();
        }
    }
}
