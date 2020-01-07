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
            List<Blog> blogs = await _blogService.GetBlogsAsync();
            List<BlogResponse> blogResponses = new List<BlogResponse>();

            blogs.ForEach(blog => blogResponses.Add(blog.ToBlogResponse()));

            return blogResponses;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BlogResponse>> GetBlog(long id)
        {
            Blog blog = await _blogService.GetBlogAsync(id);
            if (blog == null)
                return NotFound();

            return blog.ToBlogResponse();
        }

        [HttpPost]
        public async Task<ActionResult<Blog>> PostBlog(BlogRequest blogRequest)
        {
            Blog savedBlog = await _blogService.CreateBlogAsync(blogRequest.ToBlog());

            return CreatedAtAction(nameof(GetBlog), new { id = savedBlog.Id }, savedBlog);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlog(long id, BlogRequest blogRequest)
        {
            if (id != blogRequest.Id)
                return BadRequest();

            try
            {
                await _blogService.ModifyBlogAsync(blogRequest.ToBlog());
            }
            catch (NoSuchBlogException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BlogResponse>> DeleteBlog(long id)
        {
            Blog blog = await _blogService.DeleteBlogAsync(id);
            if (blog == null)
                return NotFound();

            return blog.ToBlogResponse();
        }
    }
}
