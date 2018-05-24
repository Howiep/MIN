using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M_Data;

namespace M_API.ViewModels
{
    public class ExperienceCategoryViewModel
    {
        public int Semester { get; set; }
        public string Name { get; set; }
        public List<string> Experiences { get; set; }
    }
}
