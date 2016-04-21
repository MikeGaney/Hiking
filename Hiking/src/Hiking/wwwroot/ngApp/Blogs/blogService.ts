namespace Hiking.Services
{
    export class BlogService
    {
        private BlogResource;

        constructor(private $resource: ng.resource.IResourceService)
        {
            this.BlogResource = this.$resource("/api/blogs/:id");
        }

        public ListBlogs()
        {
            return this.BlogResource.query();
        }

        public GetBlog(id)
        {
            return this.BlogResource.get({ id: id }).$promise;
        }

        public SaveBlog(blogToCreate)
        {
            return this.BlogResource.save(blogToCreate).$promise;
        }

        public DeleteBlog(id)
        {
            return this.BlogResource.delete({ id: id }).$promise;
        }

        public IncreaseViewCount(id)
        {
            console.log(id);
            var viewResource = this.$resource("/api/blogs/view");
            return viewResource.save({ id: id }).$promise;
        }

        public AddComment(comment)
        {
            var commentResource = this.$resource("/api/blogs/comment");
            return commentResource.save(comment).$promise;
        }

        public DeleteComment(id)
        {
            var deleteResource = this.$resource("/api/blogs/deleteComment");
            return deleteResource.delete({ id: id }).$promise;
        }
    }
    angular.module("Hiking").service("blogService", BlogService);
}