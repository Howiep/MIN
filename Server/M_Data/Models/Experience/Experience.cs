using System;
using System.Collections.Generic;
using System.Text;

namespace M_Data.models
{
    public class Experience
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public Boolean EU { get; set; }
        public int EUCount { get; set; }
        public int ExperienceCategoryId { get; set; }
        public ExperienceCategory ExperienceCategory { get; set; }
        public ExperienceGroup ExperienceGroup { get; set; }
        public int Semester { get; set; }
    }
}
