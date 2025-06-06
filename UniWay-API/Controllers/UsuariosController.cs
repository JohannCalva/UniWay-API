using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniWay_API.Models;
using UniWay_API.Models.DTO.Usuario;

namespace UniWay_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UniWayAPIContext _context;

        public UsuariosController(UniWayAPIContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetUsuarios()
        {
            var usuarios = await _context.Usuario
                .Select(u => new UsuarioDTO
                {
                    Id = u.Id,
                    IdBanner = u.IdBanner,
                    Nombre = u.Nombre,
                    Correo = u.Correo,
                    Telefono = u.Telefono,
                    EsConductor = u.EsConductor
                }).ToListAsync();

            return usuarios;
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDTO>> GetUsuario(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            var usuarioDTO = new UsuarioDTO
            {
                Id = usuario.Id,
                IdBanner = usuario.IdBanner,
                Nombre = usuario.Nombre,
                Correo = usuario.Correo,
                Telefono = usuario.Telefono,
                EsConductor = usuario.EsConductor
            };

            return usuarioDTO;
        }

        // POST: api/Usuarios
        [HttpPost]
        public async Task<ActionResult<UsuarioDTO>> PostUsuario(UsuarioCreateDTO dto)
        {
            var usuario = new Usuario
            {
                IdBanner = dto.IdBanner,
                Nombre = dto.Nombre,
                Correo = dto.Correo,
                Telefono = dto.Telefono,
                Contrasena = dto.Contrasena,
                EsConductor = dto.EsConductor
            };

            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();

            var usuarioDTO = new UsuarioDTO
            {
                Id = usuario.Id,
                IdBanner = usuario.IdBanner,
                Nombre = usuario.Nombre,
                Correo = usuario.Correo,
                Telefono = usuario.Telefono,
                EsConductor = usuario.EsConductor
            };

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuarioDTO);
        }

        // PUT: api/Usuarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, UsuarioUpdateDTO dto)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            usuario.IdBanner = dto.IdBanner;
            usuario.Nombre = dto.Nombre;
            usuario.Correo = dto.Correo;
            usuario.Telefono = dto.Telefono;
            usuario.Contrasena = dto.Contrasena;
            usuario.EsConductor = dto.EsConductor;

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuario.Any(e => e.Id == id);
        }
    }
}
