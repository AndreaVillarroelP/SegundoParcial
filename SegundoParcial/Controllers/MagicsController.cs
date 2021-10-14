using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SegundoParcial.Data;
using SegundoParcial.Models;

namespace SegundoParcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MagicsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MagicsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Magics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Magic>>> GetMagic()
        {
            return await _context.Magic.ToListAsync();
        }

        // GET: api/Magics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Magic>> GetMagic(string id)
        {
            var magic = await _context.Magic.FindAsync(id);

            if (magic == null)
            {
                return NotFound();
            }

            return magic;
        }

        // PUT: api/Magics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMagic(string id, Magic magic)
        {
            if (id != magic.FuturoId)
            {
                return BadRequest();
            }

            _context.Entry(magic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MagicExists(id))
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

        // POST: api/Magics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Magic>> PostMagic(Magic magic)
        {
            _context.Magic.Add(magic);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MagicExists(magic.FuturoId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMagic", new { id = magic.FuturoId }, magic);
        }

        // DELETE: api/Magics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMagic(string id)
        {
            var magic = await _context.Magic.FindAsync(id);
            if (magic == null)
            {
                return NotFound();
            }

            _context.Magic.Remove(magic);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MagicExists(string id)
        {
            return _context.Magic.Any(e => e.FuturoId == id);
        }
    }
}
