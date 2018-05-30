using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M_Data;
using M_Data.models;
using M_Data.Models;

namespace M_API.ViewModels
{
    public class ExperienceGroupViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<ExperienceGroupRelation> GroupExperiences { get; set; }

    }
}
