using M_Data.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace M_Data.Models
{
    public class ExperienceGroupRelation
    {

        [Key, ForeignKey("ExperienceGroup"), Column(Order = 1)]
        public int ExperienceGroupId  { get; set; }
        public virtual ExperienceGroup ExperienceGroup { get; set; }

        [Key, ForeignKey("Experience"), Column(Order = 2)]
        public int ExperienceId { get; set; }
        public virtual Experience Experience { get; set; }
    }
}
