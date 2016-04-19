using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Hiking.ViewModels.Account
{
    public class UserViewModel
    {
        public string UserName { get; set; }

        public Dictionary<string, string> Claims { get; set; }
        public string UserId { get; set; }
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
