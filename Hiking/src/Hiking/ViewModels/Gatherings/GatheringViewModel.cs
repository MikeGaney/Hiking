using Hiking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hiking.ViewModels.Gatherings
{
    public class GatheringViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }
        public ICollection<GatheringUserViewModel> Users { get; set; }
        public string OwnerId { get; set; }
    }
}
