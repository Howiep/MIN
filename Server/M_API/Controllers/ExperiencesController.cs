using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M_API.ViewModels;
using M_Core.Data;
using M_Data.models;
using M_Data.Models;
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
                    ExperienceCategory = new ExperienceCategoryViewModel
                    {
                        Id = e.ExperienceCategory.Id,
                        Name = e.ExperienceCategory.Name,
                        EUCount = e.ExperienceCategory.EUCount

                    },
                    ExperienceGroups = e.ExperienceGroups
                });

            return experiences;
        }

        //// GET: api/Experiences/groups
        [HttpGet("groups")]
        public List<ExperienceGroup> GetGroups()
        {
            var experienceGroups = _context.ExperienceGroups
                .Select(e => new ExperienceGroup
                {
                    Id = e.Id,
                    Name = e.Name,
                    GroupExperiences = e.GroupExperiences.Select(x => new ExperienceGroupRelation()
                    {
                        ExperienceId = x.Experience.Id,
                        Experience = new Experience
                        {
                            Name = x.Experience.Name
                        }
                    }).ToList()
                }).ToList();

            return experienceGroups;
        }

        // GET: api/Experiences/categories
        [HttpGet("categories")]
        public IQueryable<ExperienceCategory> GetCategories()
        {
            var experienceCategories = _context.ExperienceCategories
                .Where(e => e.Experiences.Any())
                .Select(e => new ExperienceCategory
                {
                    Id = e.Id,
                    Name = e.Name,
                    EUCount = e.EUCount
                });

            return experienceCategories;
        }

        // GET: api/Experiences/actions
        [HttpGet("actions")]
        public IQueryable<Experience> GetActions()
        {
            var actions = _context.Experiences
                .Select(e => new Experience
                {
                    Id = e.Id,
                    Name = e.Name
                });

            return actions;
        }
    }
}
