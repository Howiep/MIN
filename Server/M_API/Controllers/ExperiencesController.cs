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
    [Route("api/Experiences")]
    public class ExperiencesController : Controller
    {
        private readonly DataContext _context;

        public ExperiencesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Experiences
        [HttpGet]
        public IEnumerable<Experience> GetExperiences()
        {
            return _context.Experiences;
        }

        // GET: api/Experiences/GetExperienceNames
        [HttpGet]
        [Route("GetExperienceNames")]
        public IEnumerable<string> GetExperienceNames()
        {
            List<string> experienceNames = new List<string>();
            List<Experience> experiences = _context.Experiences.ToList();

            foreach (Experience e in experiences) 
            {
                experienceNames.Add(e.Name);
            }

            return experienceNames;
        }

        // GET: api/Experiences/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExperience([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var experience = await _context.Experiences.SingleOrDefaultAsync(m => m.ID == id);

            if (experience == null)
            {
                return NotFound();
            }

            return Ok(experience);
        }

        // PUT: api/Experiences/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExperience([FromRoute] int id, [FromBody] Experience experience)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != experience.ID)
            {
                return BadRequest();
            }

            _context.Entry(experience).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExperienceExists(id))
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

        // POST: api/Experiences
        [HttpPost]
        public async Task<IActionResult> PostExperience([FromBody] Experience experience)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Experiences.Add(experience);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExperience", new { id = experience.ID }, experience);
        }

        // DELETE: api/Experiences/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExperience([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var experience = await _context.Experiences.SingleOrDefaultAsync(m => m.ID == id);
            if (experience == null)
            {
                return NotFound();
            }

            _context.Experiences.Remove(experience);
            await _context.SaveChangesAsync();

            return Ok(experience);
        }

        private bool ExperienceExists(int id)
        {
            return _context.Experiences.Any(e => e.ID == id);
        }
    }
}