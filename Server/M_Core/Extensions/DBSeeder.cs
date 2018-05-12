using M_Core.Data;
using M_Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M_Core.Extensions
{
    public class DBSeeder
    {
        public static void Initialize(DataContext context)
        {
            // example from https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-2.1
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Experiences.Any())
            {
                return;   // DB has been seeded
            }

            var experiences = new List<Experience>()
            {
                new Experience("Temperaturmåling"),
                new Experience("Modtagelse af familien"),
                new Experience("Samtale om og planlægning af barselsomsorgen"),
                new Experience("Vejledning i personlig hygiejne"),
                new Experience("Vejledning om kvindens fysiologiske forandringer pp"),
                new Experience("Observation af bristning og episiotomi"),
                new Experience("telefonsamtale med fødende"),
                new Experience("Forberedelse til modtagelse"),
                new Experience("modtage i modtagelse/fødegang"),
                new Experience("Vejledning ved bristning og episiotomi"),
                new Experience("Palpation af uterus p.p."),
                new Experience("Observation og vejledning omkring lokkier")
            };
                        

            foreach (Experience e in experiences)
            {
                context.Experiences.Add(e);
            }
            context.SaveChanges();

            var experienceCategories = new List<ExperienceCategory>()
            {
                new ExperienceCategory(4, "fødselshjælp"),
                new ExperienceCategory(4, "barselsomsorg"),
                new ExperienceCategory(4, "omsorg for mor med kompliceret barsel"),
                new ExperienceCategory(4, "observation og pleje af det nyfødte syge barn"),
                new ExperienceCategory(4, "pleje af barn med:"),
                new ExperienceCategory(4, "andet relevant"),
                new ExperienceCategory(4, "gynækologi"),
                new ExperienceCategory(4, "diagnoser"),
                new ExperienceCategory(4, "svangreomsorg Jordmoderkonsultation")



            };
            foreach (ExperienceCategory ec in experienceCategories)
            {
                context.ExperienceCategories.Add(ec);
            }
            context.SaveChanges();

            var experienceCategoriesExperience = new List<ExperienceCategoryExperience>()
            {
                new ExperienceCategoryExperience(1,1),
                new ExperienceCategoryExperience(2,1),
                new ExperienceCategoryExperience(3,1),
                new ExperienceCategoryExperience(4,1),
                new ExperienceCategoryExperience(5,1),
                new ExperienceCategoryExperience(6,1),
                new ExperienceCategoryExperience(7,1),
                new ExperienceCategoryExperience(8,1),
                new ExperienceCategoryExperience(9,1),
                new ExperienceCategoryExperience(10,1),
                new ExperienceCategoryExperience(11,1),
                new ExperienceCategoryExperience(12,1)
            };
            foreach (ExperienceCategoryExperience ece in experienceCategoriesExperience)
            {
                context.ExperienceCategoryExperience.Add(ece);
            }
            context.SaveChanges();
        }
    }
}

