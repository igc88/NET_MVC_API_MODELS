using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NET_API_MODELS_Almacenes.Models;

namespace NET_API_MODELS_Almacenes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlmacenesController : ControllerBase
    {
        private readonly APIContext _context;

        public AlmacenesController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Almacenes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Almacen>>> Getalmacenes()
        {
            return await _context.almacenes.ToListAsync();
        }

        // GET: api/Almacenes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Almacen>> GetAlmacen(int id)
        {
            var almacen = await _context.almacenes.FindAsync(id);

            if (almacen == null)
            {
                return NotFound();
            }

            return almacen;
        }

        // PUT: api/Almacenes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlmacen(int id, Almacen almacen)
        {
            if (id != almacen.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(almacen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlmacenExists(id))
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

        // POST: api/Almacenes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Almacen>> PostAlmacen(Almacen almacen)
        {
            _context.almacenes.Add(almacen);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlmacen", new { id = almacen.Codigo }, almacen);
        }

        // DELETE: api/Almacenes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Almacen>> DeleteAlmacen(int id)
        {
            var almacen = await _context.almacenes.FindAsync(id);
            if (almacen == null)
            {
                return NotFound();
            }

            _context.almacenes.Remove(almacen);
            await _context.SaveChangesAsync();

            return almacen;
        }

        private bool AlmacenExists(int id)
        {
            return _context.almacenes.Any(e => e.Codigo == id);
        }
    }
}
