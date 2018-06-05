using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M_API.ViewModels.Shift;
using M_Core.Data;
using M_Data.models;
using M_Data.Models.Shift;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace M_API.Controllers {
    [Produces ("application/json")]
    [Route ("api/Shifts")]
    public class ShiftsController : Controller {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly DataContext _context;

        public ShiftsController(DataContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        public async Task<List<Shift>> GetAsync()
        {
            var user = await GetCurrentUserAsync();

            var shifts = _context.Shifts
                .Select(e => new Shift
                {
                    Id = e.Id,
                    Note = e.Note,
                    Date = e.Date,
                    Student = e.Student,
                    ShiftExperiences = e.ShiftExperiences.Select(x => new ShiftExperiencesRelation()
                    {
                        ExperienceId = x.Experience.Id,
                        Experience = new Experience
                        {
                            Name = x.Experience.Name
                        }
                    }).ToList()
                  }).Where(u => u.Student.Id == user.Id).ToList();

            return shifts;
        }

        [HttpGet("getall")]
        public List<Shift> GetAll()
        {
            var shifts = _context.Shifts
                .Select(e => new Shift
                {
                    Id = e.Id,
                    Note = e.Note,
                    Date = e.Date,
                    ShiftExperiences = e.ShiftExperiences.Select(x => new ShiftExperiencesRelation()
                    {
                        ExperienceId = x.Experience.Id,
                        Experience = new Experience
                        {
                            Name = x.Experience.Name
                        }
                    }).ToList()
                }).ToList();

            return shifts;

        }

        //[HttpGet ("{Id}")]
        //public Shift Get (int id) {
        //    var data = _context.Shifts
        //        .Select (i => new ShiftViewModel () {
        //            Id = i.Id,
        //            Note = i.Note,
        //            Experiences = i.ShiftExperiences
        //                .Select (x => new Experience () {
        //                    x.Id = x.Experience.id,
        //                    x.Name = x.Experience.Name
        //                })
        //                .ToList ()
        //        })
        //        .FirstOrDefault (i => i.Id == id);

        //    return data;
        //}


        // POST: api/Shifts
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ShiftViewModel model) {

            var experiences = model.Experiences;
            var user = await GetCurrentUserAsync();

            var shift = new Shift () {
                Note = model.Note,
                Date = model.Date,
                Student = user,
                ShiftExperiences = experiences
                .Select (i => new ShiftExperiencesRelation () {
                    ExperienceId = i.Id
                 }).ToList ()
            };

            _context.Shifts.Add (shift);
            _context.SaveChanges ();

            return Ok("Success, vagten er blevet tilføjet");
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

    }
}