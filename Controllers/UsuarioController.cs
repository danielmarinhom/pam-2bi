using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pam.Data;
using pam.Models;
using Pam.Data;

namespace pam.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly DataContext _context;

        public UsuarioController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> GetAll()
        {
            return await _context.TB_USUARIO
                .Include(u => u.Sugestoes)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetById(int id)
        {
            var usuario = await _context.TB_USUARIO
                .Include(u => u.Sugestoes)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (usuario == null)
                return NotFound();

            return usuario;
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> Create(Usuario usuario)
        {
            _context.TB_USUARIO.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Usuario usuario)
        {
            if (id != usuario.Id)
                return BadRequest();

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await UsuarioExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        //api/usuario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _context.TB_USUARIO.FindAsync(id);

            if (usuario == null)
                return NotFound();

            _context.TB_USUARIO.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> UsuarioExists(int id)
        {
            return await _context.TB_USUARIO.AnyAsync(u => u.Id == id);
        }
    }
}
