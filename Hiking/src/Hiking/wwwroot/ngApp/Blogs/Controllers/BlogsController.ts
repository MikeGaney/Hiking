namespace Hiking.Controllers
{
    export class BlogsController
    {
        public blogs;

        constructor(private blogService: Hiking.Services.BlogService)
        {
            //console.log("blogs controller");
            this.blogs = this.blogService.ListBlogs();
        }
    }
}