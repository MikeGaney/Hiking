using Hiking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hiking.ViewModels.Profile
{
    public class UserTrailsModel
    {
        public ICollection<Trail>  Trails { get; set; }
    }
}
