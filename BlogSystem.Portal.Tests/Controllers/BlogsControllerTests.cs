using Moq;
using Xunit;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogSystem.Business.Interface;
using BlogSystem.Business.Domain;
using BlogSystem.Portal.Controllers;
using BlogSystem.Portal.ResponseModels;
using BlogSystem.Portal.RequestModles;
using BlogSystem.Business.Exceptions;


namespace BlogSystem.Portal.Tests.Controllers
{
    public class BlogsControllerTests
    {
        private Blog blogForTest = new Blog
        {
            Id = 1,
            Title = "foo",
            Content = "bar"
        };

        [Fact]
        public async Task GetBlogs_Should_Return_BlogResponse_List ()
        {
            var mockService = new Mock<IBlogService> ();
            mockService.Setup (service => service.GetBlogsAsync ())
                .ReturnsAsync (GetTestBlogs ());
            var controller = new BlogsController (mockService.Object);

            var result = await controller.GetBlogs ();

            var blogs = Assert.IsAssignableFrom<IEnumerable<BlogResponse>> (result.Value);
            Assert.Equal (2, blogs.ToList ().Count);
        }

        [Fact]
        public async Task GetBlog_Should_Return_Assigned_Blog ()
        {
            var mockService = new Mock<IBlogService> ();
            mockService.Setup (service => service.GetBlogAsync (1))
                .ReturnsAsync (blogForTest);
            var controller = new BlogsController (mockService.Object);

            var result = await controller.GetBlog (1);

            var blog = Assert.IsAssignableFrom<BlogResponse> (result.Value);
            Assert.Equal (1, blog.Id);
        }

        [Fact]
        public async Task GetBlog_Should_Return_NotFound_When_Blog_Is_Not_Exist ()
        {
            var mockService = new Mock<IBlogService> ();
            mockService.Setup (service => service.GetBlogAsync (1))
                .ReturnsAsync (() => null);
            var controller = new BlogsController (mockService.Object);

            var result = await controller.GetBlog (1);

            Assert.IsAssignableFrom<NotFoundResult> (result.Result);
        }

        [Fact]
        public async Task PostBlog_Should_Return_Created_With_Loacation ()
        {
            var mockService = new Mock<IBlogService> ();
            mockService.Setup (service => service.CreateBlogAsync(It.IsAny<Blog>()))
                .ReturnsAsync (blogForTest);
            var controller = new BlogsController (mockService.Object);

            var result = await controller.PostBlog(new BlogRequest());

            var action = Assert.IsAssignableFrom<CreatedAtActionResult> (result.Result);
        }

        [Fact]
        public async Task PutBlog_Should_Return_No_Content ()
        {
            var mockService = new Mock<IBlogService> ();
            var controller = new BlogsController (mockService.Object);

            var result = await controller.PutBlog(1, new BlogRequest
            {
                Id = 1,
                Title = "foo",
                Content = "bar"
            });

            var action = Assert.IsAssignableFrom<NoContentResult> (result);
            mockService.Verify(x => x.ModifyBlogAsync(It.IsAny<Blog>()), Times.Once());
        }

        [Fact]
        public async Task PutBlog_Should_Return_Bad_Request_When_Id_Is_Not_Consistent ()
        {
            var mockService = new Mock<IBlogService> ();
            var controller = new BlogsController (mockService.Object);

            var result = await controller.PutBlog(1, new BlogRequest());

            var action = Assert.IsAssignableFrom<BadRequestResult> (result);
        }

        [Fact]
        public async Task PutBlog_Should_Return_Not_Found_When_Assigned_Blog_Is_Not_Exist ()
        {
            var mockService = new Mock<IBlogService> ();
            mockService.Setup(service => service.ModifyBlogAsync(It.IsAny<Blog>()))
                .ThrowsAsync(new NoSuchBlogException());
            var controller = new BlogsController (mockService.Object);

            var result = await controller.PutBlog(1, new BlogRequest
            {
                Id = 1,
                Title = "foo",
                Content = "bar"
            });

            var action = Assert.IsAssignableFrom<NotFoundResult> (result);
        }

        [Fact]
        public async Task DeleteBlog_Should_Return_Ok ()
        {
            var mockService = new Mock<IBlogService> ();
            mockService.Setup(service => service.DeleteBlogAsync(1))
                .ReturnsAsync(blogForTest);
            var controller = new BlogsController (mockService.Object);

            var result = await controller.DeleteBlog(1);

            var blogResult = Assert.IsAssignableFrom<ActionResult<BlogResponse>> (result);
            Assert.Equal(1, blogResult.Value.Id);
        }

        [Fact]
        public async Task DeleteBlog_Should_Return_Not_Found_When_Assigned_Blog_Is_Not_Exist ()
        {
            var mockService = new Mock<IBlogService> ();
            mockService.Setup(service => service.DeleteBlogAsync(1))
                .ReturnsAsync(() => null);
            var controller = new BlogsController (mockService.Object);

            var result = await controller.DeleteBlog(1);

            Assert.IsAssignableFrom<NotFoundResult> (result.Result);
        }

        private List<Blog> GetTestBlogs ()
        {
            var blogList = new List<Blog> ();
            blogList.Add (new Blog
            {
                Id = 1,
                Title = "foo",
                Content = "bar"
            });
            blogList.Add (new Blog
            {
                Id = 2,
                Title = "foo2",
                Content = "bar2"
            });

            return blogList;
        }
    }
}