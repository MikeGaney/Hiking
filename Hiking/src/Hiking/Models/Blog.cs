using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hiking.Models
{
    public class Blog
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string UserID { get; set; }
        public int Views { get; set; }
        public DateTime CreationDate { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
