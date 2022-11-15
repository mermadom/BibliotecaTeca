using BibliotecaTeca.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaTeca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly DataContext context;

        public UsuarioController(DataContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            return Ok(await context.Usuarios.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> Get( int id)
        {
            var user =  await context.Usuarios.FindAsync(id);
            if (user == null)
                return BadRequest("User not Found");

            return Ok(user);
        }



        [HttpPost]
        public async Task<ActionResult<List<Usuario>>> AddUsuarios(Usuario user)
        {
            context.Usuarios.Add(user);
            await context.SaveChangesAsync();
            return Ok(await context.Usuarios.ToListAsync());
        }


        [HttpPut]
        public async Task<ActionResult<List<Usuario>>> UpdateUsuario(Usuario request)
        {
            var user = await context.Usuarios.FindAsync(request.Id);
            if (user == null)
                return BadRequest("User not Found");
            user.Name = request.Name;
            user.Email = request.Email;
            user.Administrador = request.Administrador;
            await context.SaveChangesAsync();
            return Ok(await context.Usuarios.ToListAsync());
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Usuario>>> DeleteUsuario(int id)
        {
            var user = await context.Usuarios.FindAsync(id);
            if (user == null)
                return BadRequest("User not Found");
            context.Usuarios.Remove(user);
            await context.SaveChangesAsync();
            return Ok(await context.Usuarios.ToListAsync());
        }





    }
}
