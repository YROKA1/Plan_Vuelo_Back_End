using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Plan_aereo.Models;
using RADER.ModelView;

namespace Plan_aereo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasajeroesController : ControllerBase
    {
        private readonly PlanAereoContext _context;

        public PasajeroesController(PlanAereoContext context)
        {
            _context = context;
        }

        // GET: api/Pasajeroes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pasajero>>> GetPasajeros()
        {
            return await _context.Pasajeros.ToListAsync();
        }
		// GET LOGIN FRONT - BACK
		[HttpGet("/api/Usuarios/{user}/{password}")]
		public async Task<ActionResult<IEnumerable<usuarioView>>> GetLogIn(string user, string password)
		{
			var query = (from e in _context.Pasajeros
						 where e.UsuarioPasajero == user && e.ClavePasajero == password
						 select new usuarioView
						 {
							 
							 Clave_Usuario = password,
							 Nombre_Usuario = user

						 }).ToArrayAsync();
			return await query;
		}

		// GET: api/Pasajeroes/5
		[HttpGet("{id}")]
        public async Task<ActionResult<Pasajero>> GetPasajero(int id)
        {
            var pasajero = await _context.Pasajeros.FindAsync(id);

            if (pasajero == null)
            {
                return NotFound();
            }

            return pasajero;
        }

        // PUT: api/Pasajeroes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPasajero(int id, Pasajero pasajero)
        {
            if (id != pasajero.IdPasajero)
            {
                return BadRequest();
            }

            _context.Entry(pasajero).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PasajeroExists(id))
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

        // POST: api/Pasajeroes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pasajero>> PostPasajero(Pasajero pasajero)
        {
            _context.Pasajeros.Add(pasajero);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPasajero", new { id = pasajero.IdPasajero }, pasajero);
        }

        // DELETE: api/Pasajeroes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePasajero(int id)
        {
            var pasajero = await _context.Pasajeros.FindAsync(id);
            if (pasajero == null)
            {
                return NotFound();
            }

            _context.Pasajeros.Remove(pasajero);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PasajeroExists(int id)
        {
            return _context.Pasajeros.Any(e => e.IdPasajero == id);
        }
    }
}
