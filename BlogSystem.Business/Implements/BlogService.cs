using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlogSystem.DataAccess;

namespace BlogSystem.Business
{
    public class BlogService : IBlogService
    {
        private readonly BlogContext _context;

        public BlogService(BlogContext context)
        {
            _context = context;
        }

        public async Task<List<Blog>> GetBlogsAsync()
        {
            List<BlogEntity> _blogs = await _context.Blogs.ToListAsync();
            List<Blog> blogs = new List<Blog>();

            _blogs.ForEach(_blog => blogs.Add(_blog.ToBlog()));

            return blogs;
        }

        public async Task<Blog> GetBlogAsync(long id)
        {
            BlogEntity _blog = await _context.Blogs.FindAsync(id);

            return _blog.ToBlog();
        }

        public async Task<Blog> CreateBlogAsync(BlogRequest blog)
        {
            BlogEntity _blog = blog.ToBlogEntity();

            _context.Blogs.Add(_blog);
            await _context.SaveChangesAsync();

            return _blog.ToBlog();
        }
    }
}