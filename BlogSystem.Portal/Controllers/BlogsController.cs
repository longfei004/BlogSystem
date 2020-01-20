using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BlogSystem.Business.Interface;
using BlogSystem.Business.Domain;
using BlogSystem.Business.Exceptions;
using BlogSystem.Portal.ResponseModels;
using BlogSystem.Portal.RequestModles;
using System.Linq;
using AutoMapper;

namespace BlogSystem.Portal.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private IBlogService _blogService;
        private readonly IMapper _mapper;

        public BlogsController(IBlogService blogService, IMapper mapper)
        {
            _blogService = blogService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BlogResponse>> GetBlogs()
        {
            List<Blog> blogs = _blogService.GetBlogs();
            return blogs.Select(blog => _mapper.Map<BlogResponse>(blog)).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<BlogResponse> GetBlog(long id)
        {
            try
            {
                Blog blog = _blogService.GetBlog(id);
                return _mapper.Map<BlogResponse>(blog);
            }
            catch(NoSuchBlogException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<Blog> PostBlog(CreateBlogRequest blogRequest)
        {
            Blog savedBlog = _blogService.CreateBlog(_mapper.Map<Blog>(blogRequest));

            return CreatedAtAction(nameof(GetBlog), new { id = savedBlog.Id }, savedBlog);
        }

        [HttpPut("{id}")]
        public IActionResult PutBlog(long id, ModifyBlogRequest blogRequest)
        {
            if (id != blogRequest.Id)
                return BadRequest();

            try
            {
                _blogService.ModifyBlog(_mapper.Map<Blog>(blogRequest));
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
                return _mapper.Map<BlogResponse>(_blogService.DeleteBlog(id));
            }
            catch (NoSuchBlogException)
            {
                return NotFound();
            }
        }
    }
}
