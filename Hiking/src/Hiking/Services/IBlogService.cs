using System.Collections.Generic;
using Hiking.Models;
using Hiking.ViewModels.Blogs;

namespace Hiking.Services
{
    public interface IBlogService
    {
        void AddBlog(NewBlogViewModel data);
        void DeleteBlog(int id);
        Blog GetBlog(int id);
        List<BlogViewModel> GetBlogList();
        void UpdateBlog(Blog data);
        void IncreaseViews(int id);
        void AddComment(NewCommentViewModel data);
        void DeleteComment(int id);
    }
}