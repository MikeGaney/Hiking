namespace Hiking.Controllers
{
    export class BlogDetailsController
    {
        public blog;
        public comment;

        constructor(private blogService: Hiking.Services.BlogService, private $stateParams: ng.ui.IStateParamsService,
                    private accountService: Hiking.Services.AccountService, private $uibModal: ng.ui.bootstrap.IModalService)
        {
            this.GetBlog();
            this.comment = {};
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

        AddComment()
        {
            this.comment.userID = this.accountService.getUserId();
            this.comment.blogID = this.$stateParams["id"];
            //console.log(this.comment);
            this.blogService.AddComment(this.comment).then(() =>
            {
                this.GetBlog();
                this.comment.message = "";
            });
        }

        DeleteBlog()
        {
            console.log("You sure you want to delete the blog?");
        }

        public showDeleteConfirmationModal()
        {
            console.log("Showing register modal");
            this.$uibModal.open({
                templateUrl: '/ngApp/Blogs/Views/deleteBlog.html',
                controller: Hiking.Controllers.DeleteBlogController,
                controllerAs: 'controller',
                //size: "sm"
                resolve: {
                    id: () => this.$stateParams["id"]
                }
            });
        }

        public showDeleteCommentConfirmationModal(id)
        {
            console.log("Showing register modal");
            this.$uibModal.open({
                templateUrl: '/ngApp/Blogs/Views/deleteComment.html',
                controller: Hiking.Controllers.DeleteCommentController,
                controllerAs: 'controller',
                //size: "sm"
                resolve: {
                    id: () => id,
                    blogID: () => this.$stateParams["id"]
                }
            });
        }

    }

    export class DeleteBlogController
    {
        constructor(private blogService: Hiking.Services.BlogService, private $location: ng.ILocationService,
                    private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance, private id, private $state: ng.ui.IStateService)
        {
            console.log(this.id);
        }

        public OK()
        {
            this.blogService.DeleteBlog(this.id).then(() =>
            {
                this.$state.go('blogs');
            });
        }

        public Cancel()
        {
            this.$uibModalInstance.close();
        }
    }

    export class DeleteCommentController
    {
        constructor(private blogService: Hiking.Services.BlogService, private $location: ng.ILocationService, private blogID,
            private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance, private id, private $state: ng.ui.IStateService)
        {
            console.log(this.id);
        }

        public OK()
        {
            this.blogService.DeleteComment(this.id).then(() =>
            {
                this.$state.reload();
                this.$uibModalInstance.close();
            });
        }

        public Cancel()
        {
            this.$uibModalInstance.close();
        }
    }

}