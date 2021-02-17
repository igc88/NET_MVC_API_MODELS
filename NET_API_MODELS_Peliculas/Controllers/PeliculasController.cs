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
    public class PeliculasController : ControllerBase
    {
        private readonly APIContext _context;

        public PeliculasController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Peliculas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pelicula>>> GetFabricantes()
        {
            return await _context.Fabricantes.ToListAsync();
        }

        // GET: api/Peliculas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pelicula>> GetPelicula(int id)
        {
            var pelicula = await _context.Fabricantes.FindAsync(id);

            if (pelicula == null)
            {
                return NotFound();
            }

            return pelicula;
        }

        // PUT: api/Peliculas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPelicula(int id, Pelicula pelicula)
        {
            if (id != pelicula.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(pelicula).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeliculaExists(id))
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

        // POST: api/Peliculas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Pelicula>> PostPelicula(Pelicula pelicula)
        {
            _context.Fabricantes.Add(pelicula);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPelicula", new { id = pelicula.Codigo }, pelicula);
        }

        // DELETE: api/Peliculas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pelicula>> DeletePelicula(int id)
        {
            var pelicula = await _context.Fabricantes.FindAsync(id);
            if (pelicula == null)
            {
                return NotFound();
            }

            _context.Fabricantes.Remove(pelicula);
            await _context.SaveChangesAsync();

            return pelicula;
        }

        private bool PeliculaExists(int id)
        {
            return _context.Fabricantes.Any(e => e.Codigo == id);
        }
    }
}
