using System.Threading.Tasks;
using BlogSystem.Business.Implements;
using BlogSystem.DataAccess.DataContext;
using BlogSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using BlogSystem.Business.Domain;
using BlogSystem.Business.Exceptions;
using Xunit;

namespace BlogSystem.Business.Tests.Implements
{
    public class BlogServiceTests
    {
        private DbContextOptions<BlogContext> options;

        public BlogServiceTests()
        {
            this.options = new DbContextOptionsBuilder<BlogContext>()
                .UseInMemoryDatabase(databaseName: "TestBlogsDb")
                .Options;
        }

        private void InsertSeedDatas()
        {
            using (var context = new BlogContext(options))
            {
                context.Blogs.Add(new BlogEntity { Id = 1, Title = "aaa" });
                context.Blogs.Add(new BlogEntity { Id = 2, Title = "bbb" });
                context.Blogs.Add(new BlogEntity { Id = 3, Title = "ccc" });
                context.SaveChanges();
            }
        }

        private void ClearAllDataItems()
        {
            using (var context = new BlogContext(options))
            {
                foreach(var blog in context.Blogs)
                    context.Blogs.Remove(blog);
                context.SaveChanges();
            }
        }

        [Fact]
        public async Task GetBlogsAsync_Should_Return_BlogList()
        {
            this.InsertSeedDatas();

            using (var context = new BlogContext(options))
            {
                var service = new BlogService(context);
                var result = await service.GetBlogsAsync();
                Assert.Equal(3, result.Count);
            }

            this.ClearAllDataItems();
        }

        [Fact]
        public async Task GetBlogAsync_Should_Return_Assigned_Blog()
        {
            this.InsertSeedDatas();

            using (var context = new BlogContext(options))
            {
                var service = new BlogService(context);
                var blog = await service.GetBlogAsync(2);
                Assert.Equal("bbb", blog.Title);
            }

            this.ClearAllDataItems();
        }

        [Fact]
        public async Task ModifyBlogAsync_Should_Throw_NoSuchBlogException_When_Assigned_Blog_Is_Not_Exist()
        {
            using (var context = new BlogContext(options))
            {
                var service = new BlogService(context);
                await Assert.ThrowsAsync<NoSuchBlogException>(() => service.ModifyBlogAsync(new Blog()));
            }
        }

        [Fact]
        public async Task DeleteBlogAsync_Should_Return_Null_When_Assigned_Blog_Is_Not_Exist()
        {
            using (var context = new BlogContext(options))
            {
                var service = new BlogService(context);
                var blog = await service.DeleteBlogAsync(1);
                Assert.Null(blog);
            }
        }
    }
}