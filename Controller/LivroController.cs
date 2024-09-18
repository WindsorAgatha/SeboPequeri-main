using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeboPequeri.Context;
using SeboPequeri.Models;
using System.Collections.Generic;
using System.Linq;

namespace SeboPequeri.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LivroController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/livro
        [HttpGet]
        public ActionResult<IEnumerable<Livro>> GetLivros()
        {
            var livros = _context.Livros.ToList();
            return Ok(livros);
        }

        // GET: api/livro/5
        [HttpGet("{id}")]
        public ActionResult<Livro> GetLivro(int id)
        {
            var livro = _context.Livros.Find(id);

            if (livro == null)
            {
                return NotFound();
            }

            return livro;
        }

        // POST: api/livro
        [HttpPost]
        public ActionResult<Livro> PostLivro(Livro livro)
        {
            _context.Livros.Add(livro);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetLivro), new { id = livro.LivroId }, livro);
        }

        // PUT: api/livro/5
        [HttpPut("{id}")]
        public IActionResult PutLivro(int id, Livro livro)
        {
            if (id != livro.LivroId)
            {
                return BadRequest();
            }

            _context.Entry(livro).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LivroExists(id))
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

        // DELETE: api/livro/5
        [HttpDelete("{id}")]
        public IActionResult DeleteLivro(int id)
        {
            var livro = _context.Livros.Find(id);
            if (livro == null)
            {
                return NotFound();
            }

            _context.Livros.Remove(livro);
            _context.SaveChanges();

            return NoContent();
        }

        private bool LivroExists(int id)
        {
            return _context.Livros.Any(e => e.LivroId == id);
        }
    }
}
