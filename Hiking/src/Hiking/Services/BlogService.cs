using Hiking.Models;
using Hiking.Repositories;
using Hiking.ViewModels.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hiking.Services
{
    public class BlogService : IBlogService
    {
        private IGenericRepository repo;

        public BlogService(IGenericRepository _repo)
        {
            this.repo = _repo;
        }

        public List<BlogViewModel> GetBlogList()
        {
            var list = repo.Query<Blog>().Select(b => new BlogViewModel {
                ID = b.ID,
                CreationDate = b.CreationDate,
                Message = b.Message,
                Title = b.Title,
                UserID = b.UserID,
                Views = b.Views,
                CommentCount = b.Comments.Count
            }).ToList();
            return list;
        }

        public Blog GetBlog(int id)
        {
            var blog = repo.Query<Blog>().Where(b => b.ID == id).Include(b => b.Comments).FirstOrDefault();
            return blog;
        }

        public void AddBlog(NewBlogViewModel data)
        {
            var blog = new Blog {
                Title = data.Title,
                Message = data.Message,
                UserID = data.UserID,
                CreationDate = DateTime.Now,
                Views = 0
            };
            repo.Add(blog);
            return;
        }

        public void UpdateBlog(Blog data)
        {
            var blog = repo.Query<Blog>().Where(b => b.ID == data.ID).FirstOrDefault();
            blog.Message = data.Message;
            blog.Title = data.Title;
            repo.SaveChanges();
            return;
        }

        public void DeleteBlog(int id)
        {
            var blog = repo.Query<Blog>().Where(b => b.ID == id).Include(b => b.Comments).FirstOrDefault();
            blog.Comments.Clear();
            repo.SaveChanges();
            repo.Delete(blog);
            repo.SaveChanges();
            return;
        }

        public void IncreaseViews(int id)
        {
            var blog = repo.Query<Blog>().Where(b => b.ID == id).FirstOrDefault();
            blog.Views += 1;
            repo.SaveChanges();
            return;
        }

        public void AddComment(NewCommentViewModel data)
        {
            var blog = repo.Query<Blog>().Where(b => b.ID == data.BlogID).Include(b => b.Comments).FirstOrDefault();
            var comment = new Comment
            {
                CreationDate = DateTime.Now,
                Message = data.Message,
                UserID = data.UserID
            };
            blog.Comments.Add(comment);
            repo.SaveChanges();
            return;
        }

        public void DeleteComment(int id)
        {
            var comment = repo.Query<Comment>().Where(c => c.ID == id).FirstOrDefault();
            repo.Delete(comment);
            repo.SaveChanges();
            return;
        }
    }
}
