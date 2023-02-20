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
    public class AvionsController : ControllerBase
    {
        private readonly PlanAereoContext _context;

        public AvionsController(PlanAereoContext context)
        {
            _context = context;
        }

        // GET: api/Avions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Avion>>> GetAvions()
        {
            return await _context.Avions.ToListAsync();
        }

        // GET: api/Avions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Avion>> GetAvion(int id)
        {
            var avion = await _context.Avions.FindAsync(id);

            if (avion == null)
            {
                return NotFound();
            }

            return avion;
        }

        // PUT: api/Avions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAvion(int id, Avion avion)
        {
            if (id != avion.IdAvion)
            {
                return BadRequest();
            }

            _context.Entry(avion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AvionExists(id))
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

        // POST: api/Avions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Avion>> PostAvion(Avion avion)
        {
            _context.Avions.Add(avion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAvion", new { id = avion.IdAvion }, avion);
        }

        // DELETE: api/Avions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAvion(int id)
        {
            var avion = await _context.Avions.FindAsync(id);
            if (avion == null)
            {
                return NotFound();
            }

            _context.Avions.Remove(avion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AvionExists(int id)
        {
            return _context.Avions.Any(e => e.IdAvion == id);
        }
    }
}
