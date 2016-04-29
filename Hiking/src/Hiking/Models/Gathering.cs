using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hiking.Models
{
    public class Gathering
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }
        public ICollection<GatheringUsers> GatheringUsers { get; set; }
        public string OwnerId { get; set; }
        public string TrailName { get; set; }
        public int TrailId { get; set; }
    }
}
