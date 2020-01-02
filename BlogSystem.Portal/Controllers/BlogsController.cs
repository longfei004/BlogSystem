using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    }
}
