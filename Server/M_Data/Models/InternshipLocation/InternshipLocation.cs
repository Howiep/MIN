using M_Data.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace M_Data.Models.InternshipLocation
{
    public class InternshipLocation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Child> Children { get; set; }
        public virtual ICollection<ApplicationUser> Student { get; set; }
    }
}
