using M_Data.models;
using M_Data.Models.InternshipLocation;
using System;
using System.Collections.Generic;
using System.Text;

namespace M_Data.Models.Shift
{
    public class Shift
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public ApplicationUser Student { get; set; }
        public virtual ICollection<Experience> Experiences { get; set; }
        public virtual ICollection<Child> Children { get; set; }
    }
}
