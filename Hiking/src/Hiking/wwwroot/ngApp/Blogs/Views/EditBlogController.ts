namespace Hiking.Controllers
{
    export class EditBlogController
    {
        public blog;

        constructor(private blogService: Hiking.Services.BlogService, private $stateParams: ng.ui.IStateParamsService,
                    private $state: ng.ui.IStateService, private $uibModal: ng.ui.bootstrap.IModalService)
        {
            this.blog = {};
            this.GetBlog();
        }

        GetBlog()
        {
            let blogID = this.$stateParams["id"];
            this.blogService.GetBlog(blogID).then((data) =>
            {
                //console.log(data);
                this.blog = data;
            });
        }

        SaveBlog()
        {
            this.blogService.SaveBlog(this.blog).then(() =>
            {
                let blogID = this.$stateParams["id"];
                this.$state.go("blogDetails", { 'id': this.blog.id });
            });
        }
    }
}