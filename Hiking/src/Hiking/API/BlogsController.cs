using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Hiking.Services;
using Hiking.Models;
using Hiking.ViewModels.Blogs;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Hiking.API
{
    [Route("api/[controller]")]
    public class BlogsController : Controller
    {
        IBlogService service;

        public BlogsController(IBlogService _service)
        {
            this.service = _service;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var list = service.GetBlogList();
            return Ok(list);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            service.IncreaseViews(id);
            var blog = service.GetBlog(id);
            return Ok(blog);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Blog value)
        {
            if (value.ID == 0)
            {
                var blog = new NewBlogViewModel
                {
                    Title = value.Title,
                    Message = value.Message,
                    UserID = value.UserID,
                };
                service.AddBlog(blog);
            }
            else
            {
                service.UpdateBlog(value);
            }
            return Ok();
        }

        [HttpPost("{id}")]
        [Route("view")]
        public IActionResult IncreaseView(int id)
        {
            service.IncreaseViews(id);
            return Ok();
        }

        [HttpPost]
        [Route("comment")]
        public IActionResult AddComment([FromBody] NewCommentViewModel data)
        {
            service.AddComment(data);
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            service.DeleteBlog(id);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Route("deleteComment")]
        public IActionResult DeleteComment(int id)
        {
            service.DeleteComment(id);
            return Ok();
        }
    }
}
