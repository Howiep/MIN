using System.Collections.Generic;
using System.Linq;
using M_Data.models;

namespace M_Core.Data
{
    public class DbSeeder
    {
        public static void SeedExperiences(DataContext context)
    {
        if (!context.Experiences.Any())
        {
            var experiences = new List<Experience>
            {
				new Experience { Name = "Afghanistan" },
				new Experience { Name = "Albania" },
				new Experience { Name = "Algeria" },
				new Experience { Name = "Andorra" },
				new Experience { Name = "Angola" },
				new Experience { Name = "Antigua and Barbuda" },
				new Experience { Name = "Argentina" },
				new Experience { Name = "Armenia" },
				new Experience { Name = "Aruba" },
				new Experience { Name = "Australia" },
				new Experience { Name = "Austria" },
				new Experience { Name = "Azerbaijan" }
            };
            context.AddRange(experiences);
            context.SaveChanges();
        }
    }
    }
}