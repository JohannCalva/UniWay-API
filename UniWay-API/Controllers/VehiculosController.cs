using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniWay_API.Models;
using UniWay_API.Models.DTO.Vehiculo;

namespace UniWay_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculosController : ControllerBase
    {
        private readonly UniWayAPIContext _context;

        public VehiculosController(UniWayAPIContext context)
        {
            _context = context;
        }

        // GET: api/Vehiculos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehiculoDTO>>> GetVehiculo()
        {
            var vehiculos = await _context.Vehiculo.ToListAsync();

            var vehiculoDTOs = vehiculos.Select(v => new VehiculoDTO
            {
                Id = v.Id,
                Marca = v.Marca,
                Modelo = v.Modelo,
                Color = v.Color,
                Placa = v.Placa,
                ConductorId = v.ConductorId
            });

            return Ok(vehiculoDTOs);
        }

        // GET: api/Vehiculos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehiculoDTO>> GetVehiculo(int id)
        {
            var vehiculo = await _context.Vehiculo.FindAsync(id);

            if (vehiculo == null)
            {
                return NotFound();
            }

            var dto = new VehiculoDTO
            {
                Id = vehiculo.Id,
                Marca = vehiculo.Marca,
                Modelo = vehiculo.Modelo,
                Color = vehiculo.Color,
                Placa = vehiculo.Placa,
                ConductorId = vehiculo.ConductorId
            };

            return Ok(dto);
        }

        // PUT: api/Vehiculos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehiculo(int id, VehiculoUpdateDTO dto)
        {
            var vehiculo = await _context.Vehiculo.FindAsync(id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            // Mapear campos desde el DTO
            vehiculo.Marca = dto.Marca;
            vehiculo.Modelo = dto.Modelo;
            vehiculo.Color = dto.Color;
            vehiculo.Placa = dto.Placa;

            _context.Entry(vehiculo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehiculoExists(id))
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

        // POST: api/Vehiculos
        [HttpPost]
        public async Task<ActionResult<VehiculoDTO>> PostVehiculo(VehiculoCreateDTO dto)
        {
            var vehiculo = new Vehiculo
            {
                Marca = dto.Marca,
                Modelo = dto.Modelo,
                Color = dto.Color,
                Placa = dto.Placa,
                ConductorId = dto.ConductorId
            };

            _context.Vehiculo.Add(vehiculo);
            await _context.SaveChangesAsync();

            var resultDto = new VehiculoDTO
            {
                Id = vehiculo.Id,
                Marca = vehiculo.Marca,
                Modelo = vehiculo.Modelo,
                Color = vehiculo.Color,
                Placa = vehiculo.Placa,
                ConductorId = vehiculo.ConductorId
            };

            return CreatedAtAction("GetVehiculo", new { id = vehiculo.Id }, resultDto);
        }

        // DELETE: api/Vehiculos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehiculo(int id)
        {
            var vehiculo = await _context.Vehiculo.FindAsync(id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            _context.Vehiculo.Remove(vehiculo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VehiculoExists(int id)
        {
            return _context.Vehiculo.Any(e => e.Id == id);
        }
    }
}
