using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hiking.ViewModels.Profile
{
    public class BackpackTrailViewModel
    {
        public int Id { get; set; }
        public string TrailImage { get; set; }
        public string Name { get; set; }
        public string Elevation { get; set; }
        public decimal Distance { get; set; }
    }
}
