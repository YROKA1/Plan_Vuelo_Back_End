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
    public class AerolineasController : ControllerBase
    {
        private readonly PlanAereoContext _context;

        public AerolineasController(PlanAereoContext context)
        {
            _context = context;
        }

        // GET: api/Aerolineas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aerolinea>>> GetAerolineas()
        {
            return await _context.Aerolineas.ToListAsync();
        }

        // GET: api/Aerolineas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aerolinea>> GetAerolinea(int id)
        {
            var aerolinea = await _context.Aerolineas.FindAsync(id);

            if (aerolinea == null)
            {
                return NotFound();
            }

            return aerolinea;
        }

        // PUT: api/Aerolineas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAerolinea(int id, Aerolinea aerolinea)
        {
            if (id != aerolinea.IdAerolinea)
            {
                return BadRequest();
            }

            _context.Entry(aerolinea).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AerolineaExists(id))
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

        // POST: api/Aerolineas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Aerolinea>> PostAerolinea(Aerolinea aerolinea)
        {
            _context.Aerolineas.Add(aerolinea);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAerolinea", new { id = aerolinea.IdAerolinea }, aerolinea);
        }

        // DELETE: api/Aerolineas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAerolinea(int id)
        {
            var aerolinea = await _context.Aerolineas.FindAsync(id);
            if (aerolinea == null)
            {
                return NotFound();
            }

            _context.Aerolineas.Remove(aerolinea);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AerolineaExists(int id)
        {
            return _context.Aerolineas.Any(e => e.IdAerolinea == id);
        }
    }
}
