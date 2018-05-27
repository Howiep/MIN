using System.Collections.Generic;
using M_Data.Models.InternshipLocation;
using M_Data.Models.Shift;
using Microsoft.AspNetCore.Identity;


namespace M_Data.models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Shift> Shifts { get; set; }
        public virtual InternshipLocation Location { get; set; }
    }
}