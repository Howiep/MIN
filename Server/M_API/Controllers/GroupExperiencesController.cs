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
    [Route("api/GroupExperiences")]
    public class GroupExperiencesController : Controller
    {
        private readonly DataContext _context;

        public GroupExperiencesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/GroupExperiences
        [HttpGet]
        public IEnumerable<GroupExperiences> GetExperienceGroups()
        {
            return _context.ExperienceGroups.Include(eg => eg.Experience).Include(eg => eg.Group);
        }

        // GET: api/GroupExperiences/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroupExperiences([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var groupExperiences = await _context.ExperienceGroups.SingleOrDefaultAsync(m => m.ExperienceID == id);

            if (groupExperiences == null)
            {
                return NotFound();
            }

            return Ok(groupExperiences);
        }

        // PUT: api/GroupExperiences/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupExperiences([FromRoute] int id, [FromBody] GroupExperiences groupExperiences)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != groupExperiences.ExperienceID)
            {
                return BadRequest();
            }

            _context.Entry(groupExperiences).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupExperiencesExists(id))
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

        // POST: api/GroupExperiences
        [HttpPost]
        public async Task<IActionResult> PostGroupExperiences([FromBody] GroupExperiences groupExperiences)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ExperienceGroups.Add(groupExperiences);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GroupExperiencesExists(groupExperiences.ExperienceID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGroupExperiences", new { id = groupExperiences.ExperienceID }, groupExperiences);
        }

        // DELETE: api/GroupExperiences/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroupExperiences([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var groupExperiences = await _context.ExperienceGroups.SingleOrDefaultAsync(m => m.ExperienceID == id);
            if (groupExperiences == null)
            {
                return NotFound();
            }

            _context.ExperienceGroups.Remove(groupExperiences);
            await _context.SaveChangesAsync();

            return Ok(groupExperiences);
        }

        private bool GroupExperiencesExists(int id)
        {
            return _context.ExperienceGroups.Any(e => e.ExperienceID == id);
        }
    }
}