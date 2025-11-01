using Microsoft.AspNetCore.Mvc;
using Pacientes_Turnos.Clases;
using Pacientes_Turnos.Services;


namespace Pacientes_Turnos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TurnosController : ControllerBase
    {
        private readonly ITurnoService _service;

        public TurnosController(ITurnoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var turno = await _service.GetById(id);
            if (turno == null) return NotFound();
            return Ok(turno);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Turno turno)
        {
            var newTurno = await _service.Add(turno);
            return CreatedAtAction(nameof(GetById), new { id = newTurno.Id }, newTurno);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Turno turno)
        {
            var updated = await _service.Update(id, turno);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.Delete(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
