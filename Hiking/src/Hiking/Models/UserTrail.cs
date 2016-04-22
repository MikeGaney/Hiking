using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hiking.Models
{
    public class UserTrail
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int TrailId { get; set; }
        public Trail Trail { get; set; }
    }
}
