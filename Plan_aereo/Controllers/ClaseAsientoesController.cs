using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Plan_aereo.Models;

namespace Plan_aereo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaseAsientoesController : ControllerBase
    {
        private readonly PlanAereoContext _context;

        public ClaseAsientoesController(PlanAereoContext context)
        {
            _context = context;
        }

        // GET: api/ClaseAsientoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClaseAsiento>>> GetClaseAsientos()
        {
            return await _context.ClaseAsientos.ToListAsync();
        }

        // GET: api/ClaseAsientoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClaseAsiento>> GetClaseAsiento(int id)
        {
            var claseAsiento = await _context.ClaseAsientos.FindAsync(id);

            if (claseAsiento == null)
            {
                return NotFound();
            }

            return claseAsiento;
        }

        // PUT: api/ClaseAsientoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClaseAsiento(int id, ClaseAsiento claseAsiento)
        {
            if (id != claseAsiento.IdClase)
            {
                return BadRequest();
            }

            _context.Entry(claseAsiento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClaseAsientoExists(id))
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

        // POST: api/ClaseAsientoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClaseAsiento>> PostClaseAsiento(ClaseAsiento claseAsiento)
        {
            _context.ClaseAsientos.Add(claseAsiento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClaseAsiento", new { id = claseAsiento.IdClase }, claseAsiento);
        }

        // DELETE: api/ClaseAsientoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClaseAsiento(int id)
        {
            var claseAsiento = await _context.ClaseAsientos.FindAsync(id);
            if (claseAsiento == null)
            {
                return NotFound();
            }

            _context.ClaseAsientos.Remove(claseAsiento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClaseAsientoExists(int id)
        {
            return _context.ClaseAsientos.Any(e => e.IdClase == id);
        }
    }
}
