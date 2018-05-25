using System.Collections.Generic;
using System.Linq;
using M_Data.models;

namespace M_Core.Data
{
    public class DbSeeder
    {
        public static void SeedExperiences(DataContext context)
        {
            if (!context.ExperienceCategories.Any())
            {
                var categories = new List<ExperienceCategory>
                {
                    new ExperienceCategory { Id = 0, Name = "Svangreomsorg for kvinder med komplikationer" },
                    new ExperienceCategory { Id = 1, Name = "Svangreomsorg generelt" },
                    new ExperienceCategory { Id = 2, Name = "Anden svangreomsorg" },
                    new ExperienceCategory { Id = 3, Name = "Fødselsomsorg generelt" },
                    new ExperienceCategory { Id = 4, Name = "Fødselsomsorg for kvinder med komplikationer" },
                    new ExperienceCategory { Id = 5, Name = "Anden fødselsomsorg" },
                    new ExperienceCategory { Id = 6, Name = "Barselsomsorg generelt " },
                    new ExperienceCategory { Id = 7, Name = "Barselsomsorg for kvinder med komplikationer" },
                    new ExperienceCategory { Id = 8, Name = "Anden barselsomsorg" },
                    new ExperienceCategory { Id = 9, Name = "Omsorg for nyfødt med komplikationer" },
                    new ExperienceCategory { Id = 10, Name = "Omsorg for kvinder med gynækologiske komplikationer" },
                    new ExperienceCategory { Id = 11, Name = "Intensiv omsorg for kvinder med obstetriske og gynækologiske komplikationer" }
                };
                context.AddRange(categories);
                context.SaveChanges();
            }

            if (!context.ExperienceGroups.Any())
            {
                var groups = new List<ExperienceGroup>
                {
                    new ExperienceGroup { Id = 0, Name = "Fødsel" },
                    new ExperienceGroup { Id = 1, Name = "Konsultation" },
                    new ExperienceGroup { Id = 2, Name = "Modtagelse af familie" }
                };
                context.AddRange(groups);
                context.SaveChanges();
            }

            if (!context.Experiences.Any())
            {
                var experiences = new List<Experience>
                {
                    new Experience { Name = "optage anamnese", Semester = 2,  },
                    new Experience { Name = "identificere ressourcer og belastninger hos kvinden/familien", Semester = 2 },
                    new Experience { Name = "inddrage viden om kvinden/familiens mål og behov i omsorgen", Semester = 2 },
                    new Experience { Name = "samtale om erfaringer med og forventninger til amning", Semester = 2 },
                    new Experience { Name = "samtale om livsstil i graviditeten, herunder KRAM", Semester = 2 },
                    new Experience { Name = "samtale om forventninger til familiedannelsesprocessen", Semester = 2 },
                    new Experience { Name = "samtale om forventning til fødslen", Semester = 2 },
                    new Experience { Name = "samtale om forventning til efterfødselsperioden", Semester = 2 },
                    new Experience { Name = "udføre udvendig undersøgelse - inspektion", Semester = 2 },
                    new Experience { Name = "udføre udvendig undersøgelse - palpation", Semester = 2 },
                    new Experience { Name = "udføre udvendig undersøgelse - auskultation", Semester = 2 },
                    new Experience { Name = "lytte hjertelyd med træstetoskop", Semester = 2 },
                    new Experience { Name = "måle BT og puls", Semester = 2 },
                    new Experience { Name = "foretage urin undersøgelse", Semester = 2 },
                    new Experience { Name = "observere vægt, højde og udregne BMI", Semester = 2 },
                };
                context.AddRange(experiences);
                context.SaveChanges();
            }
        }
    }
}