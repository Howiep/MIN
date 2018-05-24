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
    [Route("api/ShiftExperiences")]
    public class ShiftExperiencesController : Controller
    {
        private readonly DataContext _context;

        public ShiftExperiencesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ShiftExperiences
        [HttpGet]
        public IEnumerable<ShiftExperiences> GetShiftExperiences()
        {
            return _context.ShiftExperiences;
        }

        // GET: api/ShiftExperiences/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetShiftExperiences([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ShiftExperiences = await _context.ShiftExperiences.SingleOrDefaultAsync(m => m.ExperienceID == id);

            if (ShiftExperiences == null)
            {
                return NotFound();
            }

            return Ok(ShiftExperiences);
        }

        // PUT: api/ShiftExperiences/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShiftExperiences([FromRoute] int id, [FromBody] ShiftExperiences ShiftExperiences)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ShiftExperiences.ExperienceID)
            {
                return BadRequest();
            }

            _context.Entry(ShiftExperiences).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShiftExperiencesExists(id))
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

        // POST: api/ShiftExperiences
        [HttpPost]
        public async Task<IActionResult> PostShiftExperiences([FromBody] ShiftExperiences ShiftExperiences)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ShiftExperiences.Add(ShiftExperiences);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ShiftExperiencesExists(ShiftExperiences.ExperienceID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetShiftExperiences", new { id = ShiftExperiences.ExperienceID }, ShiftExperiences);
        }

        // DELETE: api/ShiftExperiences/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShiftExperiences([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ShiftExperiences = await _context.ShiftExperiences.SingleOrDefaultAsync(m => m.ExperienceID == id);
            if (ShiftExperiences == null)
            {
                return NotFound();
            }

            _context.ShiftExperiences.Remove(ShiftExperiences);
            await _context.SaveChangesAsync();

            return Ok(ShiftExperiences);
        }

        private bool ShiftExperiencesExists(int id)
        {
            return _context.ShiftExperiences.Any(e => e.ExperienceID == id);
        }
    }
}