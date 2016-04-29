using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hiking.Models
{
    public class GatheringUsers
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int GatheringID { get; set; }
        public Gathering Gathering { get; set; }
    }
}
