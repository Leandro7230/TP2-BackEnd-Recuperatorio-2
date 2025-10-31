using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pacientes_Turnos.Clases;
using Pacientes_Turnos.Data;
using Pacientes_Turnos.DTO;

namespace Pacientes_Turnos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TurnosController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TurnosController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TurnoDTO>>> GetTurnos()
        {
            var turnos = await _context.Turnos.Include(t => t.Paciente).ToListAsync();
            return Ok(_mapper.Map<IEnumerable<TurnoDTO>>(turnos));
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TurnoDTO>> GetTurno(int id)
        {
            var turno = await _context.Turnos.FindAsync(id);
            if (turno == null) return NotFound();

            return Ok(_mapper.Map<TurnoDTO>(turno));
        }

        
        [HttpPost]
        public async Task<ActionResult<TurnoDTO>> PostTurno(TurnoDTO turnoDto)
        {
            var turno = _mapper.Map<Turno>(turnoDto);
            _context.Turnos.Add(turno);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTurno), new { id = turno.Id }, _mapper.Map<TurnoDTO>(turno));
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTurno(int id, TurnoDTO turnoDto)
        {
            if (id != turnoDto.Id) return BadRequest();

            var turno = await _context.Turnos.FindAsync(id);
            if (turno == null) return NotFound();

            _mapper.Map(turnoDto, turno);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTurno(int id)
        {
            var turno = await _context.Turnos.FindAsync(id);
            if (turno == null) return NotFound();

            _context.Turnos.Remove(turno);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
