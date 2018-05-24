using System;
using System.Collections.Generic;
using System.Text;

namespace M_Data
{
    public class ShiftExperiences
    {
        public int ShiftID { get; set; }
        public int ExperienceID { get; set; }

        public Shift Shift { get; set; }
        public Experience Experience { get; set; }


        public ShiftExperiences()
        {

        }

        public ShiftExperiences(int shiftID, int experienceID)
        {
            ExperienceID = experienceID;
            ShiftID = shiftID;
        }

        public ShiftExperiences(Experience experience, Shift shift)
        {
            Experience = experience;
            Shift = shift;
        }

    }
}
