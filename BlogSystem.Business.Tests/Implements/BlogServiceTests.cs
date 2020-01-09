using System.Threading.Tasks;
using BlogSystem.Business.Implements;
using BlogSystem.DataAccess.DataContext;
using BlogSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace BlogSystem.Business.Tests.Implements
{
    public class BlogServiceTests
    {
        [Fact]
        public async Task GetBlogsAsync_Should_Return_BlogList()
        {
            var options = new DbContextOptionsBuilder<BlogContext>()
                .UseInMemoryDatabase(databaseName: "TestBlogsDb")
                .Options;

            using (var context = new BlogContext(options))
            {
                context.Blogs.Add(new BlogEntity { Id = 1, Title = "aaa" });
                context.Blogs.Add(new BlogEntity { Id = 2, Title = "bbb" });
                context.Blogs.Add(new BlogEntity { Id = 3, Title = "ccc" });
                context.SaveChanges();
            }

            using (var context = new BlogContext(options))
            {
                var service = new BlogService(context);
                var result = await service.GetBlogsAsync();
                Assert.Equal(3, result.Count);
            }
        }
    }
}