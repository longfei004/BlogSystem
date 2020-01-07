using Microsoft.EntityFrameworkCore;
using BlogSystem.DataAccess.Entities;

namespace BlogSystem.DataAccess.DataContext
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
        }

        public DbSet<BlogEntity> Blogs { get; set; }
    }
}