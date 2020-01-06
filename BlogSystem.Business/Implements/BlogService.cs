using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
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

        public async Task<Blog> CreateBlogAsync(Blog blog)
        {
            // To prevent the blog id be assigned by over post.
            blog.Id = 0;

            BlogEntity _blog = blog.ToBlogEntity();

            _context.Blogs.Add(_blog);
            await _context.SaveChangesAsync();

            return _blog.ToBlog();
        }

        public async Task ModifyBlogAsync(Blog blog)
        {
            BlogEntity _blog = blog.ToBlogEntity();

            _context.Entry(_blog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogExists(blog.Id))
                    throw new NoSuchBlogException();
                else
                    throw;
            }
        }

        public async Task<Blog> DeleteBlog(long id)
        {
            var _blog = await _context.Blogs.FindAsync(id);
            if (_blog == null)
                return null;

            _context.Blogs.Remove(_blog);
            await _context.SaveChangesAsync();

            return _blog.ToBlog();
        }

        private bool BlogExists(long id)
        {
            return _context.Blogs.Any(e => e.Id == id);
        }
    }
}