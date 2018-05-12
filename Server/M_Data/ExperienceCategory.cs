using System;
using System.Collections.Generic;
using System.Text;

namespace M_Data
{
    public class ExperienceCategory
    {
        public int ID { get; set; }
        public int Semester { get; set; }
        public string Name { get; set; }
        public ICollection<ExperienceCategoryExperience> ExperienceCategoryExperience { get; set; }

        public ExperienceCategory()
        {

        }

        public ExperienceCategory(int semester, string name)
        {
            Semester = semester;
            Name = name;
        }

    }
}
