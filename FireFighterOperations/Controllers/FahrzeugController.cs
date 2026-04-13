using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FireFighterOperations.Models;

namespace FireFighterOperations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FahrzeugController : ControllerBase
    {
        private readonly EinsatzContext _context;

        public FahrzeugController(EinsatzContext context)
        {
            _context = context;
        }

        // GET: api/Fahrzeug
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fahrzeug>>> GetFahrzeug()
        {
            return await _context.Fahrzeug.ToListAsync();
        }

        // GET: api/Fahrzeug/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fahrzeug>> GetFahrzeug(string id)
        {
            var fahrzeug = await _context.Fahrzeug.FindAsync(id);

            if (fahrzeug == null)
            {
                return NotFound();
            }

            return fahrzeug;
        }

        // PUT: api/Fahrzeug/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFahrzeug(string id, Fahrzeug fahrzeug)
        {
            if (id != fahrzeug.Bezeichnung)
            {
                return BadRequest();
            }

            _context.Entry(fahrzeug).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FahrzeugExists(id))
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

        // POST: api/Fahrzeug
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fahrzeug>> PostFahrzeug(Fahrzeug fahrzeug)
        {
            _context.Fahrzeug.Add(fahrzeug);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FahrzeugExists(fahrzeug.Bezeichnung))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFahrzeug", new { id = fahrzeug.Bezeichnung }, fahrzeug);
        }

        // DELETE: api/Fahrzeug/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFahrzeug(string id)
        {
            var fahrzeug = await _context.Fahrzeug.FindAsync(id);
            if (fahrzeug == null)
            {
                return NotFound();
            }

            _context.Fahrzeug.Remove(fahrzeug);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FahrzeugExists(string id)
        {
            return _context.Fahrzeug.Any(e => e.Bezeichnung == id);
        }
    }
}
