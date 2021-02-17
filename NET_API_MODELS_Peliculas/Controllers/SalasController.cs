using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NET_API_MODELS_Peliculas.Models;

namespace NET_API_MODELS_Peliculas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalasController : ControllerBase
    {
        private readonly APIContext _context;

        public SalasController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Salas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sala>>> GetArticulos()
        {
            return await _context.Articulos.ToListAsync();
        }

        // GET: api/Salas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sala>> GetSala(int id)
        {
            var sala = await _context.Articulos.FindAsync(id);

            if (sala == null)
            {
                return NotFound();
            }

            return sala;
        }

        // PUT: api/Salas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSala(int id, Sala sala)
        {
            if (id != sala.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(sala).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalaExists(id))
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

        // POST: api/Salas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Sala>> PostSala(Sala sala)
        {
            _context.Articulos.Add(sala);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSala", new { id = sala.Codigo }, sala);
        }

        // DELETE: api/Salas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sala>> DeleteSala(int id)
        {
            var sala = await _context.Articulos.FindAsync(id);
            if (sala == null)
            {
                return NotFound();
            }

            _context.Articulos.Remove(sala);
            await _context.SaveChangesAsync();

            return sala;
        }

        private bool SalaExists(int id)
        {
            return _context.Articulos.Any(e => e.Codigo == id);
        }
    }
}
