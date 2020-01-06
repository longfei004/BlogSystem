using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogSystem.Business;

namespace BlogSystem.Portal
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
        public async Task<ActionResult<IEnumerable<BlogResponse>>> GetBlogs()
        {
            var _blogs = await _blogService.GetBlogsAsync();
            List<BlogResponse> blogs = new List<BlogResponse>();

            _blogs.ForEach(blog => blogs.Add(blog.ToBlogResponse()));

            return blogs;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BlogResponse>> GetBlog(long id)
        {
            var blog = await _blogService.GetBlogAsync(id);

            BlogResponse blogResponse = blog.ToBlogResponse();
            if (blogResponse == null)
                return NotFound();

            return blogResponse;
        }

        [HttpPost]
        public async Task<ActionResult<Blog>> PostBlog(BlogRequest blog)
        {
            var savedBlog = await _blogService.CreateBlogAsync(blog.ToBlog());

            return CreatedAtAction(nameof(GetBlog), new { id = savedBlog.Id }, savedBlog);
        }
    }
}
