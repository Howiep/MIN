using System;
using System.Collections.Generic;
using System.Text;

namespace M_Data
{
    public class ExperienceCategoryExperience
    {
        public int ExperienceID { get; set; }
        public Experience Experience { get; set; }
        public int ExperienceCategoryID { get; set; }
        public ExperienceCategory ExperienceCategory { get; set; }

        public ExperienceCategoryExperience()
        {

        }

        public ExperienceCategoryExperience(int experienceID, int experienceCategoryID)
        {
            ExperienceID = experienceID;
            ExperienceCategoryID = experienceCategoryID; 
        }

        public ExperienceCategoryExperience(Experience experience, ExperienceCategory experienceCategory)
        {
            Experience = experience;
            ExperienceCategory = experienceCategory;
        }

    }
}
