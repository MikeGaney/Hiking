using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hiking.ViewModels.Blogs
{
    public class NewCommentViewModel
    {
        public int BlogID { get; set; }
        public string UserID { get; set; }
        public string Message { get; set; }
    }
}
