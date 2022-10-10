using BibliotecaTeca.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaTeca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BibliotecaController : ControllerBase
    {
        private readonly DataContext _context;

        public BibliotecaController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Biblioteca
        [HttpGet]
        public async Task<ActionResult<List<Biblioteca>>> Get()
        {
            return Ok(await _context.Bibliotecas.ToListAsync());
        }

        // GET: api/Biblioteca/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Biblioteca>> GetBiblioteca(int id)
        {
            var Biblioteca = await _context.Bibliotecas.FindAsync(id);

            if (Biblioteca == null)
            {
                return BadRequest("Biblioteca Não Achada");
            }

            return Ok(Biblioteca);
        }

        // PUT: api/Biblioteca/5
        [HttpPut]
        public async Task<ActionResult<List<Biblioteca>>> UpdateBiblioteca(Biblioteca request)
        {
            var Biblioteca = await _context.Bibliotecas.FindAsync(request.Id);
            if (Biblioteca == null)
                return BadRequest("Biblioteca Não Achada");
            Biblioteca.Name = request.Name;
            Biblioteca.Livros = request.Livros;
            Biblioteca.Emprestimos = request.Emprestimos;
            await _context.SaveChangesAsync();
            return Ok(await _context.Bibliotecas.ToListAsync());
        }

        // POST: api/Biblioteca
        [HttpPost]
        public async Task<ActionResult<List<Biblioteca>>> AddBibliotecas(Biblioteca Biblioteca)
        {
            _context.Bibliotecas.Add(Biblioteca);
            await _context.SaveChangesAsync();
            return Ok(await _context.Bibliotecas.ToListAsync());
        }

        // DELETE: api/Biblioteca/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Biblioteca>>> DeleteBiblioteca(int id)
        {
            var Biblioteca = await _context.Bibliotecas.FindAsync(id);
            if (Biblioteca == null)
                return BadRequest("Biblioteca Não Achada");
            _context.Bibliotecas.Remove(Biblioteca);
            await _context.SaveChangesAsync();
            return Ok(await _context.Bibliotecas.ToListAsync());
        }
    }
}
