using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniWay_API.Models;
using UniWay_API.Models.DTO.Reserva;

namespace UniWay_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {
        private readonly UniWayAPIContext _context;

        public ReservasController(UniWayAPIContext context)
        {
            _context = context;
        }

        // GET: api/Reservas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservaDTO>>> GetReserva()
        {
            var reservas = await _context.Reserva.ToListAsync();

            var reservasDTO = reservas.Select(r => new ReservaDTO
            {
                Id = r.Id,
                Estado = r.Estado,
                MetodoPago = r.MetodoPago,
                ViajeId = r.ViajeId,
                PasajeroId = r.PasajeroId
            });

            return Ok(reservasDTO);
        }

        // GET: api/Reservas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReservaDTO>> GetReserva(int id)
        {
            var r = await _context.Reserva.FindAsync(id);

            if (r == null)
                return NotFound();

            var reservaDTO = new ReservaDTO
            {
                Id = r.Id,
                Estado = r.Estado,
                MetodoPago = r.MetodoPago,
                ViajeId = r.ViajeId,
                PasajeroId = r.PasajeroId
            };

            return Ok(reservaDTO);
        }

        // PUT: api/Reservas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReserva(int id, ReservaUpdateDTO dto)
        {
            var reserva = await _context.Reserva.FindAsync(id);
            if (reserva == null)
                return NotFound();

            reserva.Estado = dto.Estado;
            reserva.MetodoPago = dto.MetodoPago;

            _context.Entry(reserva).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservaExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // POST: api/Reservas
        [HttpPost]
        public async Task<ActionResult<ReservaDTO>> PostReserva(ReservaCreateDTO dto)
        {
            var reserva = new Reserva
            {
                Estado = dto.Estado,
                MetodoPago = dto.MetodoPago,
                ViajeId = dto.ViajeId,
                PasajeroId = dto.PasajeroId
            };

            _context.Reserva.Add(reserva);
            await _context.SaveChangesAsync();

            var reservaDTO = new ReservaDTO
            {
                Id = reserva.Id,
                Estado = reserva.Estado,
                MetodoPago = reserva.MetodoPago,
                ViajeId = reserva.ViajeId,
                PasajeroId = reserva.PasajeroId
            };

            return CreatedAtAction(nameof(GetReserva), new { id = reserva.Id }, reservaDTO);
        }

        
        // DELETE: api/Reservas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReserva(int id)
        {
            var reserva = await _context.Reserva.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }

            _context.Reserva.Remove(reserva);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool ReservaExists(int id)
        {
            return _context.Reserva.Any(e => e.Id == id);
        }
    }
}
