using Microsoft.EntityFrameworkCore;

namespace BlogSystem.DataAccess
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
        }

        public DbSet<BlogEntity> Blogs { get; set; }
    }
}