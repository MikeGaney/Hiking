using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hiking.ViewModels.Gatherings
{
    public class AddGatheringViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TrailId { get; set; }
        public DateTime Time { get; set; }
        public string Description { get; set; }
        public string OwnerId { get; set; }
        public string TrailName { get; set; }

    }
}
