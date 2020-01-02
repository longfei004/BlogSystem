using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogSystem.Services;
using BlogSystem.Models;

namespace BlogSystemApi.Controllers
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
        public async Task<ActionResult<IEnumerable<Blog>>> GetBlogs()
        {
            return await _blogService.GetBlogsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Blog>> GetBlog(long id)
        {
            var blog = await _blogService.GetBlogAsync(id);

            if (blog == null)
            {
                return NotFound();
            }

            return blog;
        }

        //todo: The blog id can't be assigned by this method, so id need to be vaildated.
        [HttpPost]
        public async Task<ActionResult<Blog>> PostBlog(Blog blog)
        {
            var savedBlog = await _blogService.CreateBlogAsync(blog);

            return CreatedAtAction(nameof(GetBlog), new { id = savedBlog.Id }, savedBlog);
        }
    }
}
