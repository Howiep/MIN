using System;
using M_Data.Models.Shift;
using System.Collections.Generic;
using System.Text;

namespace M_Data.Models.InternshipLocation
{
    public class Child
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }
        public string Title { get; set; }
        public DateTime BirthDay { get; set; }
        public virtual InternshipLocation Location { get; set; }
        public virtual Shift.Shift Shift { get; set; }
    }
}
