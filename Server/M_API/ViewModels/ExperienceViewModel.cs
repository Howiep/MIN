using M_Data.models;
using M_Data.Models;
using M_Data.Models.Shift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M_API.ViewModels
{
    public class ExperienceViewModel 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public bool EU { get; set; }
        public int EUCount { get; set; }
        public int Semester { get; set; }
        public ExperienceCategoryViewModel ExperienceCategory { get; set; }
        public IList<ExperienceGroupRelation> ExperienceGroups { get; set; }
        public IList<ShiftExperiencesRelation> ShiftExperiences { get; set; }
    }
}
