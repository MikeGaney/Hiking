using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hiking.ViewModels.Profile
{
    public class EditProfileViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string ProfilePic { get; set; }
        public int Expertise { get; set; }
        public string Bio { get; set; }
        public string DisplayName { get; set; }
    }
}
