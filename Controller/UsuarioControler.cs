using Microsoft.AspNetCore.Mvc;
using SeboPequeri.Context;
using SeboPequeri.Models;
using System.Collections.Generic;
using System.Linq;

namespace SeboPequeri.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Usuario
        [HttpGet("GetUsuarios")]
        public ActionResult<IEnumerable<Usuario>> GetUsuarios()
        {
            var usuarios = _context.Usuarios.ToList();

            if (!usuarios.Any())
            {
                return new JsonResult(new { Message = "Não há usuários disponíveis no momento." })
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }

            return Ok(usuarios);
        }

        // GET: api/Usuario/5
        [HttpGet("GetUsuario/{id}")]
        public ActionResult<Usuario> GetUsuario(int id)
        {
            var usuario = _context.Usuarios.Find(id);

            if (usuario == null)
            {
                return NotFound(new { Message = "Usuário não encontrado." });
            }

            return Ok(usuario);
        }

        // POST: api/Usuario
        [HttpPost("CreateUsuario")]
        public ActionResult<Usuario> CreateUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.UsuarioId }, usuario);
        }

        // PUT: api/Usuario/5
        [HttpPut("UpdateUsuario/{id}")]
        public IActionResult UpdateUsuario(int id, Usuario usuario)
        {
            if (id != usuario.UsuarioId)
            {
                return BadRequest(new { Message = "ID do usuário não corresponde." });
            }

            var usuarioExistente = _context.Usuarios.Find(id);
            if (usuarioExistente == null)
            {
                return NotFound(new { Message = "Usuário não encontrado." });
            }

            usuarioExistente.Nome = usuario.Nome;
            usuarioExistente.Cargo = usuario.Cargo;
            usuarioExistente.Telefone = usuario.Telefone;
            usuarioExistente.Email = usuario.Email;
            usuarioExistente.Senha = usuario.Senha;
            usuarioExistente.EstaAtivo = usuario.EstaAtivo;

            _context.Usuarios.Update(usuarioExistente);
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Usuario/5
        [HttpDelete("DeleteUsuario/{id}")]
        public IActionResult DeleteUsuario(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null)
            {
                return NotFound(new { Message = "Usuário não encontrado." });
            }

            // Implementação de soft delete
            usuario.EstaAtivo = false;

            _context.Usuarios.Update(usuario);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
