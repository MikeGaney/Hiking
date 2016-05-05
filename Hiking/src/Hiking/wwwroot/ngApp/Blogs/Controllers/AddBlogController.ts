namespace Hiking.Controllers
{
    export class AddBlogController
    {
        public blogToAdd;

        constructor(private blogService: Hiking.Services.BlogService, private $state: ng.ui.IStateService)
        {
            this.blogToAdd = {};
        }

        AddBlog()
        {
            this.blogService.SaveBlog(this.blogToAdd).then(() =>
            {
                this.$state.go('blogs');
            });
        }
    }
}