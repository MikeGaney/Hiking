using Hiking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hiking.ViewModels.Profile
{
    public class ProfileViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string ProfilePic { get; set; }
        public int Expertise { get; set; }
        public string Bio { get; set; }
        public string DisplayName { get; set; }
        public ICollection<Trail> Trails { get; set; }
        public string Id { get; set; }
    }

}
