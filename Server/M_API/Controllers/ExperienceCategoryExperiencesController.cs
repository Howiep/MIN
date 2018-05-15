using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using M_Core.Data;
using M_Data;
using M_API.ViewModels;

namespace M_API.Controllers
{
    [Produces("application/json")]
    [Route("api/ExperienceCategoryExperiences")]
    public class ExperienceCategoryExperiencesController : Controller
    {
        private readonly DataContext _context;

        public ExperienceCategoryExperiencesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ExperienceCategoryExperiences
        [HttpGet]
        public IEnumerable<ExperienceCategoryExperience> GetExperienceCategoryExperience()
        {
            return _context.ExperienceCategoryExperience;
        }

        // GET: api/ExperiencesWithCategories
        [HttpGet]
        [Route("GetExperiencesWithCategories")]
        public IEnumerable<ExperienceCategoryViewModel> GetExperiencesWithCategories()
        {
            var experiencesWithCategories = new List<ExperienceCategoryViewModel>();

            var allExperiencesAndCategories = _context.ExperienceCategoryExperience
                .Include(ece => ece.Experience)
                .Include(ece => ece.ExperienceCategory).ToList();

            foreach (ExperienceCategoryExperience aeacc in allExperiencesAndCategories)
            {

                ExperienceCategoryViewModel ecvm = new ExperienceCategoryViewModel();
                ecvm.Experiences = new List<Experience>();
                if(aeacc.Experience != null)
                {
                    ecvm.Experiences.Add(aeacc.Experience);
                }
                experiencesWithCategories.Add(ecvm);
            }

            return experiencesWithCategories;
        }


        // GET: api/ExperienceCategoryExperiences/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExperienceCategoryExperience([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var experienceCategoryExperience = await _context.ExperienceCategoryExperience.SingleOrDefaultAsync(m => m.ExperienceCategoryID == id);

            if (experienceCategoryExperience == null)
            {
                return NotFound();
            }

            return Ok(experienceCategoryExperience);
        }

        // PUT: api/ExperienceCategoryExperiences/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExperienceCategoryExperience([FromRoute] int id, [FromBody] ExperienceCategoryExperience experienceCategoryExperience)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != experienceCategoryExperience.ExperienceCategoryID)
            {
                return BadRequest();
            }

            _context.Entry(experienceCategoryExperience).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExperienceCategoryExperienceExists(id))
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

        // POST: api/ExperienceCategoryExperiences
        [HttpPost]
        public async Task<IActionResult> PostExperienceCategoryExperience([FromBody] ExperienceCategoryExperience experienceCategoryExperience)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ExperienceCategoryExperience.Add(experienceCategoryExperience);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ExperienceCategoryExperienceExists(experienceCategoryExperience.ExperienceCategoryID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetExperienceCategoryExperience", new { id = experienceCategoryExperience.ExperienceCategoryID }, experienceCategoryExperience);
        }

        // DELETE: api/ExperienceCategoryExperiences/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExperienceCategoryExperience([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var experienceCategoryExperience = await _context.ExperienceCategoryExperience.SingleOrDefaultAsync(m => m.ExperienceCategoryID == id);
            if (experienceCategoryExperience == null)
            {
                return NotFound();
            }

            _context.ExperienceCategoryExperience.Remove(experienceCategoryExperience);
            await _context.SaveChangesAsync();

            return Ok(experienceCategoryExperience);
        }

        private bool ExperienceCategoryExperienceExists(int id)
        {
            return _context.ExperienceCategoryExperience.Any(e => e.ExperienceCategoryID == id);
        }
    }
}