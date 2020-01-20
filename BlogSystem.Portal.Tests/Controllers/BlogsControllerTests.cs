using System;
using System.Collections.Generic;
using System.Linq;
using BlogSystem.Business.Domain;
using BlogSystem.Business.Exceptions;
using BlogSystem.Business.Interface;
using BlogSystem.Portal.Controllers;
using BlogSystem.Portal.RequestModles;
using BlogSystem.Portal.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using AutoMapper;

namespace BlogSystem.Portal.Tests.Controllers
{
    public class BlogsControllerTests
    {
        private Mock<IBlogService> mockService;
        private Mock<IMapper> mockMapper;
        private BlogsController controller;

        public BlogsControllerTests()
        {
            mockService = new Mock<IBlogService>();
            mockMapper = new Mock<IMapper>();
            controller = new BlogsController(mockService.Object, mockMapper.Object);
        }

        private Blog blogForTest = new Blog
        {
            Id = 1,
            Title = "foo",
            Content = "bar",
            LastUpdateTime = new DateTime()
        };

        private ModifyBlogRequest modifyBlog = new ModifyBlogRequest
        {
            Id = 1,
            Title = "foo",
            Content = "bar",
            LastUpdateTime = new DateTime()
        };

        [Fact]
        public void GetBlogs_Should_Return_BlogResponse_List()
        {
            mockService.Setup(service => service.GetBlogs())
                .Returns(GetTestBlogs());
            mockMapper.Setup(mapper => mapper.Map<BlogResponse>(It.IsAny<Blog>()))
                .Returns(new BlogResponse());

            var result = controller.GetBlogs();

            var blogs = Assert.IsAssignableFrom<IEnumerable<BlogResponse>>(result.Value);
            Assert.Equal(2, blogs.ToList().Count);
        }

        [Fact]
        public void GetBlog_Should_Return_Assigned_Blog()
        {
            mockService.Setup(service => service.GetBlog(1))
                .Returns(blogForTest);
            mockMapper.Setup(mapper => mapper.Map<BlogResponse>(It.IsAny<Blog>()))
                .Returns(new BlogResponse{ Id = 1});

            var result = controller.GetBlog(1);

            var blog = Assert.IsAssignableFrom<BlogResponse>(result.Value);
            Assert.Equal(1, blog.Id);
        }

        [Fact]
        public void GetBlog_Should_Return_NotFound_When_Blog_Is_Not_Exist()
        {
            mockService.Setup(service => service.GetBlog(1))
                .Throws(new NoSuchBlogException());

            var result = controller.GetBlog(1);

            Assert.IsAssignableFrom<NotFoundResult>(result.Result);
        }

        [Fact]
        public void PostBlog_Should_Return_Created()
        {
            mockService.Setup(service => service.CreateBlog(It.IsAny<Blog>()))
                .Returns(blogForTest);

            var result = controller.PostBlog(new CreateBlogRequest());

            var action = Assert.IsAssignableFrom<CreatedAtActionResult>(result.Result);
        }

        [Fact]
        public void PutBlog_Should_Return_No_Content()
        {
            var result = controller.PutBlog(1, modifyBlog);

            var action = Assert.IsAssignableFrom<NoContentResult>(result);
            mockService.Verify(x => x.ModifyBlog(It.IsAny<Blog>()), Times.Once());
        }

        [Fact]
        public void PutBlog_Should_Return_Bad_Request_When_Id_Is_Not_Consistent()
        {
            var result = controller.PutBlog(1, new ModifyBlogRequest());

            var action = Assert.IsAssignableFrom<BadRequestResult>(result);
        }

        [Fact]
        public void PutBlog_Should_Return_Not_Found_When_Assigned_Blog_Is_Not_Exist()
        {
            mockService.Setup(service => service.ModifyBlog(It.IsAny<Blog>()))
                .Throws(new NoSuchBlogException());

            var result = controller.PutBlog(1, modifyBlog);

            var action = Assert.IsAssignableFrom<NotFoundResult>(result);
        }

        [Fact]
        public void DeleteBlog_Should_Return_Ok()
        {
            mockService.Setup(service => service.DeleteBlog(1))
                .Returns(blogForTest);
            mockMapper.Setup(mapper => mapper.Map<BlogResponse>(It.IsAny<Blog>()))
                .Returns(new BlogResponse{Id = 1});

            var result = controller.DeleteBlog(1);

            var blogResult = Assert.IsAssignableFrom<ActionResult<BlogResponse>>(result);
            Assert.Equal(1, blogResult.Value.Id);
        }

        [Fact]
        public void DeleteBlog_Should_Return_Not_Found_When_Assigned_Blog_Is_Not_Exist()
        {
            mockService.Setup(service => service.DeleteBlog(1))
                .Throws(new NoSuchBlogException());

            var result = controller.DeleteBlog(1);

            Assert.IsAssignableFrom<NotFoundResult>(result.Result);
        }

        private List<Blog> GetTestBlogs()
        {
            var blogList = new List<Blog>();
            blogList.Add(new Blog
            {
                Id = 1,
                Title = "foo",
                Content = "bar",
                LastUpdateTime = new DateTime()
            });
            blogList.Add(new Blog
            {
                Id = 2,
                Title = "foo2",
                Content = "bar2",
                LastUpdateTime = new DateTime()
            });

            return blogList;
        }
    }
}