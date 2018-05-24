using System;
using System.Collections.Generic;
using System.Text;

namespace M_Data
{
    public class Shift
    {
        public int ShiftID { get; set; }
        public DateTime Date { get; set; }
        public ApplicationUser User { get; set; }
        public string Note { get; set; }
        //WIP Varighed/period? How long does the midwife take a Shift?
        public ICollection<ShiftExperiences> ShiftExperiences { get; set; }

        public Shift()
        {

        }

        public Shift(ApplicationUser user, string note, DateTime date)
        {
            User = user;
            Note = note;
            Date = date;
        }
    }
}
