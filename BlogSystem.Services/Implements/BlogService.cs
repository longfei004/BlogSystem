using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlogSystem.DataAccess;
using BlogSystem.Models;

namespace BlogSystem.Services
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
            return await _context.Blogs.ToListAsync();
        }

        public async Task<Blog> GetBlogAsync(long id)
        {
            return await _context.Blogs.FindAsync(id);
        }

        public async Task<Blog> CreateBlogAsync(Blog blog)
        {
            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();

            return blog;
        }
    }
}