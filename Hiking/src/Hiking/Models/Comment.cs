using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hiking.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public string Message { get; set; }
        public string UserID { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
