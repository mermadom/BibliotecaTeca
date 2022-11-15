using BibliotecaTeca.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoTeca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmprestimoController : ControllerBase
    {
        private readonly DataContext _context;

        public EmprestimoController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Emprestimo
        [HttpGet]
        public async Task<ActionResult<List<Emprestimo>>> Get()
        {
            return Ok(await _context.Emprestimos.ToListAsync());
        }

        // GET: api/Emprestimo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Emprestimo>> GetEmprestimo(int id)
        {
            var Emprestimo = await _context.Emprestimos.FindAsync(id);

            if (Emprestimo == null)
            {
                return BadRequest("Emprestimo Não Achada");
            }

            return Ok(Emprestimo);
        }

        // PUT: api/Emprestimo/5
        [HttpPut]
        public async Task<ActionResult<List<Emprestimo>>> UpdateEmprestimo(Emprestimo request)
        {
            var Emprestimo = await _context.Emprestimos.FindAsync(request.Id);
            if (Emprestimo == null)
                return BadRequest("Emprestimo Não Achada");
            Emprestimo.livro = request.livro;
            Emprestimo.Usuario = request.Usuario;
            await _context.SaveChangesAsync();
            return Ok(await _context.Emprestimos.ToListAsync());
        }

        // POST: api/Emprestimo
        [HttpPost]
        public async Task<ActionResult<List<Emprestimo>>> AddEmprestimos(Emprestimo Emprestimo)
        {
            _context.Emprestimos.Add(Emprestimo);
            await _context.SaveChangesAsync();
            return Ok(await _context.Emprestimos.ToListAsync());
        }

        // DELETE: api/Emprestimo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Emprestimo>>> DeleteEmprestimo(int id)
        {
            var Emprestimo = await _context.Emprestimos.FindAsync(id);
            if (Emprestimo == null)
                return BadRequest("Emprestimo Não Achada");
            _context.Emprestimos.Remove(Emprestimo);
            await _context.SaveChangesAsync();
            return Ok(await _context.Emprestimos.ToListAsync());
        }
    }
}
