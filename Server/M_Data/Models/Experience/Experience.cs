using M_Data.Models.InternshipLocation;
using M_Data.Models.Shift;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace M_Data.models
{
    public class Experience
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public bool EU { get; set; }
        public int EUCount { get; set; }
        public int Semester { get; set; }
        [ForeignKey("ExperienceCategory")]
        public int ExperienceCategoryId { get; set; }
        public ExperienceCategory ExperienceCategory { get; set; }
        [ForeignKey("ExperienceGroup")]
        public int ExperienceGroupId { get; set; }
        public ExperienceGroup ExperienceGroup { get; set; }
        public virtual ICollection<Shift> Shifts { get; set; }
    }
} 
