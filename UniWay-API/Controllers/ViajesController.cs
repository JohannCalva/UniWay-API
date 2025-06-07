using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniWay_API.Models;
using UniWay_API.Models.DTO.Viaje;

namespace UniWay_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViajesController : ControllerBase
    {
        private readonly UniWayAPIContext _context;

        public ViajesController(UniWayAPIContext context)
        {
            _context = context;
        }

        // GET: api/Viajes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViajeReadDTO>>> GetViaje()
        {
            var viajes = await _context.Viaje
                .ToListAsync();

            var viajeDTOs = viajes.Select(v => new ViajeReadDTO
            {
                Id = v.Id,
                Origen = v.Origen,
                Destino = v.Destino,
                FechaHoraSalida = v.FechaHoraSalida,
                Precio = v.Precio,
                AsientosDisponibles = v.AsientosDisponibles,
                ConductorId = v.ConductorId,
            }).ToList();

            return Ok(viajeDTOs);
        }

        // GET: api/Viajes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ViajeReadDTO>> GetViaje(int id)
        {
            var viaje = await _context.Viaje
                .FirstOrDefaultAsync(v => v.Id == id);

            if (viaje == null)
            {
                return NotFound();
            }

            var dto = new ViajeReadDTO
            {
                Id = viaje.Id,
                Origen = viaje.Origen,
                Destino = viaje.Destino,
                FechaHoraSalida = viaje.FechaHoraSalida,
                Precio = viaje.Precio,
                AsientosDisponibles = viaje.AsientosDisponibles,
                ConductorId = viaje.ConductorId,
            };

            return Ok(dto);
        }

        // PUT: api/Viajes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutViaje(int id, ViajeUpdateDTO viajeDTO)
        {
            var viaje = await _context.Viaje.FindAsync(id);
            if (viaje == null)
            {
                return NotFound();
            }

            // Manualmente actualizar los campos (excepto el ConductorId)
            viaje.Origen = viajeDTO.Origen;
            viaje.Destino = viajeDTO.Destino;
            viaje.FechaHoraSalida = viajeDTO.FechaHoraSalida;
            viaje.Precio = viajeDTO.Precio;
            viaje.AsientosDisponibles = viajeDTO.AsientosDisponibles;

            _context.Entry(viaje).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViajeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Viajes
        [HttpPost]
        public async Task<ActionResult<ViajeReadDTO>> PostViaje(ViajeCreateDTO viajeDTO)
        {
            var viaje = new Viaje
            {
                Origen = viajeDTO.Origen,
                Destino = viajeDTO.Destino,
                FechaHoraSalida = viajeDTO.FechaHoraSalida,
                Precio = viajeDTO.Precio,
                AsientosDisponibles = viajeDTO.AsientosDisponibles,
                ConductorId = viajeDTO.ConductorId
            };

            _context.Viaje.Add(viaje);
            await _context.SaveChangesAsync();

            var viajeReadDTO = new ViajeReadDTO
            {
                Id = viaje.Id,
                Origen = viaje.Origen,
                Destino = viaje.Destino,
                FechaHoraSalida = viaje.FechaHoraSalida,
                Precio = viaje.Precio,
                AsientosDisponibles = viaje.AsientosDisponibles,
                ConductorId = viaje.ConductorId
            };

            return CreatedAtAction("GetViaje", new { id = viaje.Id }, viajeReadDTO);
        }

        // DELETE: api/Viajes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteViaje(int id)
        {
            var viaje = await _context.Viaje.FindAsync(id);
            if (viaje == null)
            {
                return NotFound();
            }

            _context.Viaje.Remove(viaje);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ViajeExists(int id)
        {
            return _context.Viaje.Any(e => e.Id == id);
        }
    }
}
