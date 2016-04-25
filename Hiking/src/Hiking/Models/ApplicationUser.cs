using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Hiking.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string  LastName { get; set; }
        public int Age { get; set; }
        public string ProfilePic { get; set; }
        public int Expertise { get; set; }
        public string Bio { get; set; }
        public string DisplayName { get; set; }
        public ICollection<GatheringUsers> Gatheringusers { get; set; }
        //public ICollection<Trail> UserTrails { get; set; }
    }
}
