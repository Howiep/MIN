using System;
using System.Collections.Generic;
using System.Text;

namespace M_Data
{
    public class GroupExperiences
    {
        public int GroupID { get; set; }
        public Group Group { get; set; }
        public int ExperienceID { get; set; }
        public Experience Experience { get; set; }


        public GroupExperiences()
        {

        }

        public GroupExperiences(int groupID, int experienceID)
        {
            ExperienceID = experienceID;
            GroupID = groupID;
        }

        public GroupExperiences(Experience experience, Group group)
        {
            Experience = experience;
            Group = group;
        }

    }
}
