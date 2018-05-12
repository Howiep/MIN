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
    [Route("api/ExperienceCategories")]
    public class ExperienceCategoriesController : Controller
    {
        private readonly DataContext _context;

        public ExperienceCategoriesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ExperienceCategories
        [HttpGet]
        public IEnumerable<ExperienceCategory> GetExperienceCategories()
        {
            return _context.ExperienceCategories;
        }

        // GET: api/ExperienceCategories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExperienceCategory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var experienceCategory = await _context.ExperienceCategories.SingleOrDefaultAsync(m => m.ID == id);


            if (experienceCategory == null)
            {
                return NotFound();
            }

            return Ok(experienceCategory);
        }

        // PUT: api/ExperienceCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExperienceCategory([FromRoute] int id, [FromBody] ExperienceCategory experienceCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != experienceCategory.ID)
            {
                return BadRequest();
            }

            _context.Entry(experienceCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExperienceCategoryExists(id))
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

        // POST: api/ExperienceCategories
        [HttpPost]
        public async Task<IActionResult> PostExperienceCategory([FromBody] ExperienceCategory experienceCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ExperienceCategories.Add(experienceCategory);
            await _context.SaveChangesAsync();
            var test = _context.SaveChangesAsync();

            return CreatedAtAction("GetExperienceCategory", new { id = experienceCategory.ID }, experienceCategory);
        }

        // DELETE: api/ExperienceCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExperienceCategory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var experienceCategory = await _context.ExperienceCategories.SingleOrDefaultAsync(m => m.ID == id);
            if (experienceCategory == null)
            {
                return NotFound();
            }

            _context.ExperienceCategories.Remove(experienceCategory);
            await _context.SaveChangesAsync();

            return Ok(experienceCategory);
        }

        private bool ExperienceCategoryExists(int id)
        {
            return _context.ExperienceCategories.Any(e => e.ID == id);
        }
    }
}