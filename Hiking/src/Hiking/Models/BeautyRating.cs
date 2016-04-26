using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hiking.Models
{
    public class BeautyRating
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int Rating { get; set; }
    }
}
