using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M_API.ViewModels
{
    //inspired by https://www.codeproject.com/articles/790720/asp-net-identity-customizing-users-and-roles
    public class UpdateUserViewModel
    {
        //also the email
        public string username { get; set; }
        public string newEmail { get; set; }
        public string phoneNumber { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }

    }
}
