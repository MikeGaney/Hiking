namespace Hiking.Controllers
{
    export class BlogsController
    {
        public blogs;

        constructor(private blogService: Hiking.Services.BlogService)
        {
            this.blogs = this.blogService.ListBlogs();
        }
    }
}