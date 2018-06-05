using M_Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace M_Data.models
{
    public class ExperienceGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<ExperienceGroupRelation> GroupExperiences { get; set; }

    }
}
