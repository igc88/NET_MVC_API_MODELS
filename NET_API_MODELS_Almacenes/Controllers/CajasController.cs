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
    public class CajasController : ControllerBase
    {
        private readonly APIContext _context;

        public CajasController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Cajas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Caja>>> GetCajas()
        {
            return await _context.Cajas.ToListAsync();
        }

        // GET: api/Cajas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Caja>> GetCaja(int id)
        {
            var caja = await _context.Cajas.FindAsync(id);

            if (caja == null)
            {
                return NotFound();
            }

            return caja;
        }

        // PUT: api/Cajas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCaja(int id, Caja caja)
        {
            if (id != caja.NumReferencia)
            {
                return BadRequest();
            }

            _context.Entry(caja).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CajaExists(id))
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

        // POST: api/Cajas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Caja>> PostCaja(Caja caja)
        {
            _context.Cajas.Add(caja);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCaja", new { id = caja.NumReferencia }, caja);
        }

        // DELETE: api/Cajas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Caja>> DeleteCaja(int id)
        {
            var caja = await _context.Cajas.FindAsync(id);
            if (caja == null)
            {
                return NotFound();
            }

            _context.Cajas.Remove(caja);
            await _context.SaveChangesAsync();

            return caja;
        }

        private bool CajaExists(int id)
        {
            return _context.Cajas.Any(e => e.NumReferencia == id);
        }
    }
}
