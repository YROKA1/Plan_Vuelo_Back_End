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
    public class BancoesController : ControllerBase
    {
        private readonly PlanAereoContext _context;

        public BancoesController(PlanAereoContext context)
        {
            _context = context;
        }

        // GET: api/Bancoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Banco>>> GetBancos()
        {
            return await _context.Bancos.ToListAsync();
        }

        // GET: api/Bancoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Banco>> GetBanco(int id)
        {
            var banco = await _context.Bancos.FindAsync(id);

            if (banco == null)
            {
                return NotFound();
            }

            return banco;
        }

        // PUT: api/Bancoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBanco(int id, Banco banco)
        {
            if (id != banco.IdBanco)
            {
                return BadRequest();
            }

            _context.Entry(banco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BancoExists(id))
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

        // POST: api/Bancoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Banco>> PostBanco(Banco banco)
        {
            _context.Bancos.Add(banco);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBanco", new { id = banco.IdBanco }, banco);
        }

        // DELETE: api/Bancoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBanco(int id)
        {
            var banco = await _context.Bancos.FindAsync(id);
            if (banco == null)
            {
                return NotFound();
            }

            _context.Bancos.Remove(banco);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BancoExists(int id)
        {
            return _context.Bancos.Any(e => e.IdBanco == id);
        }
    }
}
