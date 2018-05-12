using System;
using System.Collections.Generic;
using System.Text;

namespace M_Data
{
    public class Experience
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<ExperienceCategoryExperience> ExperienceCategoryExperience { get; set; }

        public Experience()
        {
            
        }

        public Experience(string name)
        {
            Name = name;
        }
          
    }
}
