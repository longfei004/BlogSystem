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
    }
}