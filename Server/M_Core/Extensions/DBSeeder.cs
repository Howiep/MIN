using M_Core.Data;
using M_Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M_Core.Extensions
{
    public class DBSeeder
    {

        //inspired by: https://www.locktar.nl/programming/net-core/seed-database-users-roles-dotnet-core-2-0-ef/

        public static async Task Initialize(DataContext context, UserManager<ApplicationUser> userManager,
       RoleManager<IdentityRole> roleManager, ILogger<DBSeeder> logger)
        {
            // example from https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-2.1
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Group.Any())
            {
                return;   // DB has been seeded
            }

            //Experiences
            var experiences = ExampleExperiences();
            foreach (Experience e in experiences)
            {
                context.Experiences.Add(e);
            }
            context.SaveChanges();

            //ExperienceCategories
            var experienceCategories = ExampleExperienceCategories();
            foreach (ExperienceCategory ec in experienceCategories)
            {
                context.ExperienceCategories.Add(ec);
            }
            context.SaveChanges();

            //The joint between the previous above.
            var experienceCategoriesExperience = ExampleExperienceCategoryExperiences();
            foreach (ExperienceCategoryExperience ece in experienceCategoriesExperience)
            {
                context.ExperienceCategoryExperience.Add(ece);
            }
            context.SaveChanges();


            //Users 
            IdentityResult result = await ExampleUsers(userManager);


            //Groups
            var groups = ExampleGroups();
            foreach (Group g in groups)
            {
                context.Group.Add(g);
            }
            context.SaveChanges();


            //Groups
            var groupExperiences = ExampleGroupExperiences();
            foreach (GroupExperiences ge in groupExperiences)
            {
                context.ExperienceGroups.Add(ge);
            }
            context.SaveChanges();


            //Shiftes. Needs to have a user attached to it. Use the created before
            ApplicationUser studentUser = await userManager.FindByNameAsync("Student");

            var Shiftes = ExampleShiftes(studentUser);
            foreach (Shift w in Shiftes)
            {
                context.Shift.Add(w);
            }
            context.SaveChanges();


            //Groups
            var ShiftExperiences = ExampleShiftExperiences();
            foreach (ShiftExperiences we in ShiftExperiences)
            {
                context.ShiftExperiences.Add(we);
            }
            

            context.SaveChanges();
        }
        #region examplemethods
        public static List<Experience> ExampleExperiences()
        {

            return new List<Experience>()
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
                new Experience("Observation og vejledning omkring lokkier"),
                new Experience("Interview og mærk på maven"),
                new Experience("Observation af fosterhjertelyd med trærør"),
                new Experience("Indrage partneren"),
                new Experience("Varetage dele af samtalen"),
                new Experience("Utralydscanning")

            };
            
        }

        public static List<ExperienceCategory> ExampleExperienceCategories()
        {

            return new List<ExperienceCategory>()
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
        }

        public static List<ExperienceCategoryExperience> ExampleExperienceCategoryExperiences()
        {

            return new List<ExperienceCategoryExperience>()
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
        }


        //notice that I only return 1 user, because that user is being used in other datas.
        public static async Task<IdentityResult> ExampleUsers(UserManager<ApplicationUser> userManager)
        {
            IdentityResult identityResult = new IdentityResult();

            ApplicationUser Admin = new ApplicationUser { UserName = "Admin", Email = "admintesteren@gmail.dk" };
            ApplicationUser Teacher = new ApplicationUser { UserName = "Teacher", Email = "teachertesteren@gmail.dk" };
            ApplicationUser Student = new ApplicationUser { UserName = "Student", Email = "studenttesteren@gmail.dk" };
            
            identityResult = await userManager.CreateAsync(Admin, "AdminKoden123!");
            identityResult = await userManager.CreateAsync(Teacher, "TeacherKoden123!");
            identityResult = await userManager.CreateAsync(Student, "StudentKoden123!");
            if (identityResult.Succeeded)
            {
                Console.Write($"Created default user successfully");
            }
            else
            {
                var exception = new ApplicationException($"Default user cannot be created");
                Console.Write(identityResult.Errors);
                throw exception;
            }
            
           
            return identityResult;
            
        }


        public static List<Group> ExampleGroups()
        {

            return new List<Group>()
            {
                new Group("forældre konsultation"),
                new Group("forældre øvelser"),
                new Group("vejledning af børnepasning")
            };
        }


        public static List<GroupExperiences> ExampleGroupExperiences()
        {

            return new List<GroupExperiences>()
            {
                new GroupExperiences(1,13),
                new GroupExperiences(1,14),
                new GroupExperiences(1,15),
                new GroupExperiences(1,16),
                new GroupExperiences(1,17)

            };
        }


        public static List<Shift> ExampleShiftes(ApplicationUser user)
        {
            return new List<Shift>()
            {
                new Shift(user, "Jeg lægger godt mærke til hvordan apperatet bliver indsat i kvinden", DateTime.Now),
                new Shift(user, "Brug apparatet sammen med manden", DateTime.Now),
                new Shift(user, "Manden skal sørge for at berolige kvinden", DateTime.Now)
            };
        }


        public static List<ShiftExperiences> ExampleShiftExperiences()
        {

            return new List<ShiftExperiences>()
            {
                new ShiftExperiences(1,13),
                new ShiftExperiences(2,14),
                new ShiftExperiences(3,15),
                new ShiftExperiences(1,16),
                new ShiftExperiences(1,17)

            };
        }



        /*   
             * Shift
             * ShiftExperiences
         * 
         * 
         * 
         */
        #endregion examplemethods
    }
}

