using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M_API.ViewModels;
using M_Core.Data;
using M_Data.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public IQueryable<ExperienceViewModel> Get()
        {
            var experiences = _context.Experiences
                .Select(e => new ExperienceViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Desc = e.Desc,
                    Semester = e.Semester,
                    EUCount = e.EUCount,
                    ExperienceCategory  =  e.ExperienceCategory
                });

            return experiences;
        }

        // GET: api/Experiences/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Experiences
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Experiences/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
