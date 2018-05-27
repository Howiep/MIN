using M_Data.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace M_Data.Models.Shift
{
    public class ShiftExperiencesRelation
    {
        [Key, ForeignKey("Shift"), Column(Order = 1)]
        public int ShiftId { get; set; }
        public virtual Shift Shift { get; set; }

        [Key, ForeignKey("Experience"), Column(Order = 2)]
        public int ExperienceId { get; set; }
        public virtual Experience Experience { get; set; }
    }
}
