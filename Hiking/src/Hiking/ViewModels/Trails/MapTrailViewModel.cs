using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hiking.ViewModels.Trails
{
    public class MapTrailViewModel
    {
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Name { get; set; }
        public Object Options { get; set; }
    }
}
