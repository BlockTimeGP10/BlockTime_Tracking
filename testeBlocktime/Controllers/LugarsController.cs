using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testeBlocktime.Contexts;
using testeBlocktime.Domains;

namespace testeBlocktime.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LugarsController : ControllerBase
    {
        private readonly testeContext _context;

        public LugarsController(testeContext context)
        {
            _context = context;
        }

        // GET: api/Lugars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lugar>>> GetLugars()
        {
            return await _context.Lugars.ToListAsync();
        }

        // GET: api/Lugars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lugar>> GetLugar(int id)
        {
            var lugar = await _context.Lugars.FindAsync(id);

            if (lugar == null)
            {
                return NotFound();
            }

            return lugar;
        }

        // PUT: api/Lugars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLugar(int id, Lugar lugar)
        {
            if (id != lugar.IdLugar)
            {
                return BadRequest();
            }

            _context.Entry(lugar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LugarExists(id))
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

        // POST: api/Lugars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Lugar>> PostLugar(Lugar lugar)
        {
            _context.Lugars.Add(lugar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLugar", new { id = lugar.IdLugar }, lugar);
        }

        // DELETE: api/Lugars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLugar(int id)
        {
            var lugar = await _context.Lugars.FindAsync(id);
            if (lugar == null)
            {
                return NotFound();
            }

            _context.Lugars.Remove(lugar);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LugarExists(int id)
        {
            return _context.Lugars.Any(e => e.IdLugar == id);
        }
    }
}
