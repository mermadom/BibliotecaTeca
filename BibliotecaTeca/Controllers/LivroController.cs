using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BibliotecaTeca.Data;
using BibliotecaTeca.Models;

namespace BibliotecaTeca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly DataContext _context;

        public LivroController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Livro
        [HttpGet]
        public async Task<ActionResult<List<Livro>>> Get()
        {
            return Ok(await _context.Livros.ToListAsync());
        }

        // GET: api/Livro/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Livro>> GetLivro(int id)
        {
            var livro = await _context.Livros.FindAsync(id);

            if (livro == null)
            {
                return BadRequest("Livro Não Achado");
            }

            return Ok(livro);
        }

        // PUT: api/Livro/5
        [HttpPut]
        public async Task<ActionResult<List<Livro>>> UpdateLivro(Livro request)
        {
            var livro = await _context.Livros.FindAsync(request.Id);
            if (livro == null)
                return BadRequest("Livro Não Achado");
            livro.Name = request.Name;
            livro.Descricao = request.Descricao;
            livro.Emprestado = request.Emprestado;
            await _context.SaveChangesAsync();
            return Ok(await _context.Livros.ToListAsync());
        }

        // POST: api/Livro
        [HttpPost]
        public async Task<ActionResult<List<Livro>>> AddLivros(Livro livro)
        {
            _context.Livros.Add(livro);
            await _context.SaveChangesAsync();
            return Ok(await _context.Livros.ToListAsync());
        }

        // DELETE: api/Livro/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Livro>>> DeleteLivro(int id)
        {
            var livro = await _context.Livros.FindAsync(id);
            if (livro == null)
                return BadRequest("Livro Não Achado");
            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();
            return Ok(await _context.Livros.ToListAsync());
        }

    }
}
