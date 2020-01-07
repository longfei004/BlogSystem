using System;
using Xunit;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BlogSystem.Portal;
using BlogSystem.Business;

namespace BlogSystem.Portal.Tests
{
    public class BlogsControllerTests
    {
        [Fact]
        public async Task GetBlogs_Should_Return_BlogResponse_List()
        {
            var mockService = new Mock<IBlogService>();
            mockService.Setup(service => service.GetBlogsAsync())
                .ReturnsAsync(GetTestBlogs());
            var controller = new BlogsController(mockService.Object);

            var result = await controller.GetBlogs();

            var blogs = Assert.IsAssignableFrom<IEnumerable<BlogResponse>>(result.Value);
            Assert.Equal(2, blogs.ToList().Count);
        }

        [Fact]
        public async Task GetBlog_Should_Return_Assigned_Blog()
        {
            var mockService = new Mock<IBlogService>();
            mockService.Setup(service => service.GetBlogAsync(1))
                .ReturnsAsync(new Blog
                {
                    Id = 1,
                    Title = "foo",
                    Content = "bar"
                });
            var controller = new BlogsController(mockService.Object);

            var result = await controller.GetBlog(1);

            var blog = Assert.IsAssignableFrom<BlogResponse>(result.Value);
            Assert.Equal(1, blog.Id);
        }

        private List<Blog> GetTestBlogs()
        {
            var blogList = new List<Blog>();
            blogList.Add(new Blog
            {
                Id = 1,
                Title = "foo",
                Content = "bar"
            });
            blogList.Add(new Blog
            {
                Id = 2,
                Title = "foo2",
                Content = "bar2"
            });

            return blogList;
        }
    }
}
