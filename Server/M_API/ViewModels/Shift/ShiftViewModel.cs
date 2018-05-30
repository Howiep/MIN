using M_Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M_API.ViewModels.Shift
{
    public class ShiftViewModel
    {
        public string Note { get; set; }
        public DateTime Start { get; set; }
        public ApplicationUser Student { get; set; }
        public List<Experience> Experiences { get; set; }
    }
}
