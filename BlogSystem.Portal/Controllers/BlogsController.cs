using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BlogSystem.Business.Interface;
using BlogSystem.Business.Domain;
using BlogSystem.Business.Exceptions;
using BlogSystem.Portal.ResponseModels;
using BlogSystem.Portal.RequestModles;
using BlogSystem.Portal.Extensions;
using System.Linq;

namespace BlogSystem.Portal.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private IBlogService _blogService;

        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BlogResponse>> GetBlogs()
        {
            List<Blog> blogs = _blogService.GetBlogs();
            return blogs.Select(blog => blog.ToBlogResponse()).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<BlogResponse> GetBlog(long id)
        {
            try
            {
                Blog blog = _blogService.GetBlog(id);
                return blog.ToBlogResponse();
            }
            catch(NoSuchBlogException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<Blog> PostBlog(BlogRequest blogRequest)
        {
            Blog savedBlog = _blogService.CreateBlog(blogRequest.ToBlog());

            return CreatedAtAction(nameof(GetBlog), new { id = savedBlog.Id }, savedBlog);
        }

        [HttpPut("{id}")]
        public IActionResult PutBlog(long id, BlogRequest blogRequest)
        {
            if (id != blogRequest.Id)
                return BadRequest();

            try
            {
                _blogService.ModifyBlog(blogRequest.ToBlog());
                return NoContent();
            }
            catch (NoSuchBlogException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<BlogResponse> DeleteBlog(long id)
        {
            try
            {
                return _blogService.DeleteBlog(id).ToBlogResponse();
            }
            catch (NoSuchBlogException)
            {
                return NotFound();
            }
        }
    }
}
