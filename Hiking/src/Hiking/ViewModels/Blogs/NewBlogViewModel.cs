using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hiking.ViewModels.Blogs
{
    public class NewBlogViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string UserID { get; set; }
    }
}
