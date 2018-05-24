using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using M_Core.Data;
using M_Data;

namespace M_API.Controllers
{
    [Produces("application/json")]
    [Route("api/Shiftes")]
    public class ShiftesController : Controller
    {
        private readonly DataContext _context;

        public ShiftesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Shiftes
        [HttpGet]
        public IEnumerable<Shift> GetShift()
        {
            return _context.Shift;
        }

        // GET: api/Shiftes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetShift([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Shift = await _context.Shift.SingleOrDefaultAsync(m => m.ShiftID == id);

            if (Shift == null)
            {
                return NotFound();
            }

            return Ok(Shift);
        }

        // PUT: api/Shiftes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShift([FromRoute] int id, [FromBody] Shift shift)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shift.ShiftID)
            {
                return BadRequest();
            }

            _context.Entry(shift).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShiftExists(id))
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

        // POST: api/Shiftes
        [HttpPost]
        public async Task<IActionResult> PostShift([FromBody] Shift Shift)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Shift.Add(Shift);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShift", new { id = Shift.ShiftID }, Shift);
        }

        // DELETE: api/Shiftes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShift([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Shift = await _context.Shift.SingleOrDefaultAsync(m => m.ShiftID == id);
            if (Shift == null)
            {
                return NotFound();
            }

            _context.Shift.Remove(Shift);
            await _context.SaveChangesAsync();

            return Ok(Shift);
        }

        private bool ShiftExists(int id)
        {
            return _context.Shift.Any(e => e.ShiftID == id);
        }
    }
}