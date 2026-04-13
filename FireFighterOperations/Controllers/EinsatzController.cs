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
    public class EinsatzController : ControllerBase
    {
        private readonly EinsatzContext _context;

        public EinsatzController(EinsatzContext context)
        {
            _context = context;
        }

        // GET: api/Einsatz
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Einsatz>>> GetEinsatz()
        {
            return await _context.Einsatz
                                    .Include(e => e.Fahrzeuge)
                                        .ThenInclude(ef => ef.Fahrzeug)
                                    .ToListAsync();
        }

        // GET: api/Einsatz/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Einsatz>> GetEinsatz(int id)
        {
            //var einsatz = await _context.Einsatz.FindAsync(id);

            var einsatz = await _context.Einsatz
                                    .Include(e => e.Fahrzeuge)
                                        .ThenInclude(ef => ef.Fahrzeug)
                                    .FirstOrDefaultAsync(e => e.Id == id);
            
            if (einsatz == null)
            {
                return NotFound();
            }

            return einsatz;
        }

        // PUT: api/Einsatz/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEinsatz(int id, Einsatz einsatz)
        {
            if (id != einsatz.Id)
            {
                return BadRequest();
            }
            /*
            _context.Entry(einsatz).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EinsatzExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
            */

            var existing = await _context.Einsatz
                                            .Include(e => e.Fahrzeuge)
                                                .ThenInclude(ef => ef.Fahrzeug)
                                            .FirstOrDefaultAsync(e => e.Id == id);


            existing.Typ = einsatz.Typ;
            existing.Einsatzleiter = einsatz.Einsatzleiter;
            existing.Adresse = einsatz.Adresse;
            existing.Beginn = einsatz.Beginn;
            existing.Ende = einsatz.Ende;
            existing.SonstigeInformationen = einsatz.SonstigeInformationen;

            //Damit Fahrzeuge richtig aktualisiert werden
            existing.Fahrzeuge.Clear();

            foreach (var ef in einsatz.Fahrzeuge)
            {
                var fahrzeug = await _context.Fahrzeug.FirstOrDefaultAsync(f => f.Bezeichnung == ef.Fahrzeug.Bezeichnung);

                if (fahrzeug == null)
                {
                    fahrzeug = new Fahrzeug
                    {
                        Bezeichnung = ef.Fahrzeug.Bezeichnung,
                        Sitzplätze = ef.Fahrzeug.Sitzplätze
                    };
                    _context.Fahrzeug.Add(fahrzeug);
                }

                if (ef.Manschaftsstand > fahrzeug.Sitzplätze)
                    return BadRequest($"Die Mannstärke ({ef.Manschaftsstand}) übersteigt die {fahrzeug.Sitzplätze} Sitzplätze von {fahrzeug.Bezeichnung}.");

                existing.Fahrzeuge.Add(new EingesetztesFahrzeug
                {
                    Fahrzeug = fahrzeug,
                    Manschaftsstand = ef.Manschaftsstand,
                    Gruppenkommandant = ef.Gruppenkommandant,
                    AnzahlAtemtraeger = ef.AnzahlAtemtraeger,
                    AusgeruecktAm = ef.AusgeruecktAm,
                    EinsatzortAngekommenAm = ef.EinsatzortAngekommenAm,
                    EinsatzbereitschaftwiederHergestelltAm = ef.EinsatzbereitschaftwiederHergestelltAm
                });
            }


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EinsatzExists(id))
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

        // POST: api/Einsatz
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Einsatz>> PostEinsatz(Einsatz einsatz)
        {
            /*
            _context.Einsatz.Add(einsatz);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEinsatz", new { id = einsatz.Id }, einsatz);
            */
            foreach (EingesetztesFahrzeug eingesetzesFahrzeug in einsatz.Fahrzeuge)
            {
                var fahrzeug = await _context.Fahrzeug.FirstOrDefaultAsync(f => f.Bezeichnung == eingesetzesFahrzeug.Fahrzeug.Bezeichnung);

                if (fahrzeug == null)
                {
                    fahrzeug = new Fahrzeug
                    {
                        Bezeichnung = eingesetzesFahrzeug.Fahrzeug.Bezeichnung,
                        Sitzplätze = eingesetzesFahrzeug.Fahrzeug.Sitzplätze
                    };
                    _context.Fahrzeug.Add(fahrzeug);
                    await _context.SaveChangesAsync();
                }
                if (eingesetzesFahrzeug.Manschaftsstand > fahrzeug.Sitzplätze)
                    return BadRequest($"Die Mannstärke ({eingesetzesFahrzeug.Manschaftsstand}) übersteigt die {fahrzeug.Sitzplätze} Sitzplätze von {fahrzeug.Bezeichnung}.");

                eingesetzesFahrzeug.Fahrzeug = fahrzeug;
            }

            _context.Einsatz.Add(einsatz);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEinsatz", new { id = einsatz.Id }, einsatz);
        }

        // DELETE: api/Einsatz/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEinsatz(int id)
        {
            var einsatz = await _context.Einsatz.FindAsync(id);
            if (einsatz == null)
            {
                return NotFound();
            }

            _context.Einsatz.Remove(einsatz);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EinsatzExists(int id)
        {
            return _context.Einsatz.Any(e => e.Id == id);
        }

        /////////////////////////////////////////////////////////////////////////
        /// Erweiterungen
        
        // GET: api/Einsatz/typ/B2
        [HttpGet("typ/{typ}")]
        public async Task<ActionResult<IEnumerable<Einsatz>>> GetEinsatzByTyp(string typ)
        {
            var einsaetze = await _context.Einsatz
                                            .Include(e => e.Fahrzeuge)
                                                .ThenInclude(ef => ef.Fahrzeug)
                                            .Where(e => e.Typ == typ)
                                            .ToListAsync();

            if (!einsaetze.Any()) return NotFound($"Keine Einsätze vom Typ '{typ}' gefunden.");

            return einsaetze;
        }

        // DELETE: api/Einsatz/olderthan/2025-01-01
        [HttpDelete("olderthan/{datum}")]
        public async Task<IActionResult> DeleteEinsatzOlderThan(DateTime datum)
        {
            var einsaetze = await _context.Einsatz.Where(e => e.Ende < datum).ToListAsync();

            if (!einsaetze.Any())
                return NotFound($"Keine Einsätze gefunden die älter als '{datum:dd.MM.yyyy}' sind.");

            _context.Einsatz.RemoveRange(einsaetze);
            await _context.SaveChangesAsync();

            return Ok($"{einsaetze.Count} Einsatz/Einsätze älter als '{datum:dd.MM.yyyy}' wurden gelöscht.");
        }
    }
}
